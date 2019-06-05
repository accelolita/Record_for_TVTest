using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace recsc
{
    public partial class Form1 : Form
    {
        private Process fptv;//tvtestのプロセス
        private List<Schedule> scList;
        public Settings setting;//設定クラス作成
        public Form1()
        {
            InitializeComponent();

            //dt = DateTime.Now.AddMinutes(1);
            //設定ファイル読み込み
            setting=Settings.ReadSettings();
            tsText.Text = DateTime.Now.ToString("yy/MM/dd_HH:mm:ss");
            scList = setting.scList;

            ResetGrid();
            dTP.Value = DateTime.Now.AddDays(1);

            //タイマースタート
            timer1.Start();
            //値変化のイベント登録
            this.dgvSc.CellValueChanged += new DataGridViewCellEventHandler(this.dgvSc_CellValueChanged);

        }

        private void ResetGrid()
        { 
            int count = 0;
            foreach (var item in scList)
            {
                if (dgvSc.RowCount<=count)
                {
                    dgvSc.Rows.Add();
                }               
                dgvSc[0, count].Value = item.chName;//番組名
                dgvSc[1, count].Value = Enum.GetName(typeof(Channels), item.channel);
                dgvSc[2, count].Value = item.recWeek;
                dgvSc[3, count].Value = item.recTime.ToLongTimeString();
                dgvSc[4, count].Value = EnumeExt.DisplayName(item.sycleTime);
                dgvSc[5, count].Value = item.recTime;
                dgvSc[6, count].Value = item.recSpan;
                count++;
            }
        }

        private void recStart_Click(object sender, EventArgs e)
        {
            fptv = Process.Start(setting.tvtestPath," /rec");
            btnKill.Enabled=true;
        }

        private void btnKill_Click(object sender, EventArgs e)
        {      
            try
            {
                fptv.Kill();
                fptv.Close();
                btnKill.Enabled = false;
            }
            catch (InvalidOperationException )
            {
                tsText.Text = "失敗";
            }               
        }

        private void test_Click(object sender, EventArgs e)
        {
            setting.scList = scList;
            setting.WriteSettings();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            Schedule delSc = null;
            DateTime now = DateTime.Now;
            lbTime.Text = now.ToString();
            foreach (var item in scList)
            {
                if (now.ToString()==item.recTime.AddSeconds(-30).ToString() && //十秒前      
                    item.startFlag)//起動したかどうか
                {
                    if ((int)item.channel<=9)//ch9以下　地デジ
                    {
                        item.ptv = Process.Start(setting.tvtestPath,item.ToArgOption());
                        tsText.Text += item.ptv.MainWindowTitle;
                        btnKill.Enabled = true;
                        item.startFlag = false;
                    }
                    else if(System.IO.File.Exists(setting.tvtestBsPath))//BS,CS
                    {
                        item.ptv = Process.Start(setting.tvtestBsPath, item.ToArgOption("/sid "));
                        tsText.Text += item.ptv.MainWindowTitle;
                        btnKill.Enabled = true;
                        item.startFlag = false;
                    }
                       
                    Process.Start(@"nircmd.exe", "muteappvolume /"+ item.ptv.Id.ToString()+" 1");//ミュートしてないっぽい
                }
                if (now.CompareTo(item.recTime)>0 && item.startFlag)//日付更新
                {
                    switch (item.sycleTime)
                    {
                        case SycleTime.毎週:
                            item.recTime = item.recTime.AddDays(7);
                            break;
                        case SycleTime.毎日:
                            item.recTime = item.recTime.AddDays(1);
                            break;
                        default:
                            break;
                    }         
                    if (now.CompareTo(item.recTime) < 0)
                    {
                        ResetGrid();
                    }
                }
                if (item.recTime.Add(item.recSpan).ToString() == now.ToString() &&
                    !item.startFlag)
                {
                    item.startFlag = true;
                    //終了処理一秒待機
                    Microsoft.VisualBasic.Interaction.AppActivate(item.ptv.Id);
                    SendKeys.Send("r");
                    await Task.Run(() =>
                    {
                        System.Threading.Thread.Sleep(1000);
                        do
                        {
                            item.ptv.WaitForExit(100);        
                            item.ptv.Kill();
                        } while (!item.ptv.HasExited);//終了まで繰り返す
                        
                    });
                    tsText.Text = item.chName+ "終わり";

                    if (item.sycleTime==SycleTime.一回のみ)//一回のみ＝削除
                    {
                        delSc = item;
                    }
                }
            }
            if (delSc!=null)
            {
                dgvSc.Rows.Remove(dgvSc.Rows[scList.IndexOf(delSc)]);
                scList.Remove(delSc);
                ResetGrid();
            }
        }

        /// <summary>
        /// 指定した実行ファイル名のプロセスをすべて取得する。
        /// </summary>
        /// <param name="searchFileName">検索する実行ファイル名。</param>
        /// <returns>一致したProcessの配列。</returns>
        public static Process[] GetProcessesByFileName(string searchFileName)
        {
            searchFileName = searchFileName.ToLower();
            System.Collections.ArrayList list = new System.Collections.ArrayList();

            //すべてのプロセスを列挙する
            foreach (Process p in Process.GetProcesses())
            {
                string fileName;
                try
                {
                    //メインモジュールのパスを取得する
                    fileName = p.MainModule.FileName;
                    Console.WriteLine(fileName);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    //MainModuleの取得に失敗
                    fileName = "";
                }
                if (0 < fileName.Length)
                {
                    //ファイル名の部分を取得する
                    fileName = System.IO.Path.GetFileName(fileName);
                    //探しているファイル名と一致した時、コレクションに追加
                    if (fileName.ToLower().Contains(searchFileName))
                    {
                        list.Add(p);
                    }
                }
            }
            //コレクションを配列にして返す
            return (Process[]) list.ToArray(typeof(System.Diagnostics.Process));
        }

        private int cnt = 0;
        private void dgvSc_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //エラーがうるさいから黙らせるためのイベントハンドラ
            lbTest.Text = "エラー"+ ++cnt +"\r\n"+e.ToString();
            
        }

        private void dgvSc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DateTime dt;
            for (int i = 0; i < dgvSc.RowCount; i++)
            {
                scList[i].chName = (string)dgvSc[0, i].Value;
                scList[i].channel = (Channels)Enum.Parse(typeof(Channels), (string)dgvSc[1, i].Value);
                dt = (DateTime)dgvSc[5, i].Value;//日付関係
                scList[i].recTime = dt;
                dgvSc[2, i].Value = dt.DayOfWeek;
                dgvSc[3, i].Value = dt.ToLongTimeString();
                scList[i].recWeek = dt.DayOfWeek;
                scList[i].sycleTime= EnumeExt.ToSycleTime((string)dgvSc[4, i].Value);
                scList[i].recSpan = TimeSpan.Parse(dgvSc[6, i].Value.ToString());
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ////設定保存
            //setting.scList = scList;
            //setting.WriteSettings();         
        }

        private void dgvSc_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvSc.CurrentCell == null || dgvSc.CurrentCell.ColumnIndex!=5)
            {//録画日時以外は何もしない
                return;
            }
            int row=dgvSc.CurrentCell.RowIndex;
            dTP.Value = (DateTime)dgvSc[5, row].Value;
        }

        private void dTP_ValueChanged(object sender, EventArgs e)
        {
            if (dgvSc.CurrentCell==null || dgvSc.CurrentCell.ColumnIndex != 5)
            {//録画日時以外は何もしない
                return;
            }
            int row = dgvSc.CurrentCell.RowIndex;
            dgvSc[5, row].Value = dTP.Value;
        }

        private void newCh_Click(object sender, EventArgs e)
        {//新しい表と新しい録画予約scList追加
            TimeSpan ts = recSpanPicker.Value.Subtract(new DateTime(2000,1,1));
            Schedule sc=new Schedule(tbChName.Text,
                (Channels)Enum.Parse(typeof(Channels), cbChannel.Text),
                dTP.Value, dTP.Value.DayOfWeek,ts);          
            dgvSc.Rows.Add(tbChName.Text, cbChannel.Text,dTP.Value.DayOfWeek,
                dTP.Value.ToLongTimeString(), cbSycle.Text, dTP.Value, sc.recSpan);
            scList.Add(sc);
        }

        private void dgvSc_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {//行削除処理
            if (MessageBox.Show("この予約を削除しますか", "削除の確認",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                int cnt=e.Row.Index;
                scList.Remove(scList[cnt]);
            }
        }

        private void nfiRecsec_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // フォームを表示する
            this.Visible = true;
            // 現在の状態が最小化の状態であれば通常の状態に戻す
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            // フォームをアクティブにする
            this.Activate();
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
                // フォームが最小化の状態であればフォームを非表示にする
                this.Hide();
                // トレイリストのアイコンを表示する
                nfiRecsec.Visible = true;
            }
        }

        private void recSpanPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("終了してもいいですか？", "確認",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question
                ) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void roadButton_Click(object sender, EventArgs e)
        {
            setting = Settings.ReadSettings();
            scList = setting.scList;
            ResetGrid();
        }

        private async void btnMute_Click(object sender, EventArgs e)
        {
            Process.Start(@"nircmd.exe","mutesysvolume 2");  
        }
    }
}
 