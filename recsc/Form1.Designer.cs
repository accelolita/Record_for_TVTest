namespace recsc
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.recStart = new System.Windows.Forms.Button();
            this.btnKill = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.tsText = new System.Windows.Forms.TextBox();
            this.dTP = new System.Windows.Forms.DateTimePicker();
            this.lbTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgvSc = new System.Windows.Forms.DataGridView();
            this.chName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chNum = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sycle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.recTimeAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recSpan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbTest = new System.Windows.Forms.Label();
            this.cbSycle = new System.Windows.Forms.ComboBox();
            this.cbChannel = new System.Windows.Forms.ComboBox();
            this.tbChName = new System.Windows.Forms.TextBox();
            this.newCh = new System.Windows.Forms.Button();
            this.nfiRecsec = new System.Windows.Forms.NotifyIcon(this.components);
            this.recSpanPicker = new System.Windows.Forms.DateTimePicker();
            this.roadButton = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.lbNextTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSc)).BeginInit();
            this.SuspendLayout();
            // 
            // recStart
            // 
            resources.ApplyResources(this.recStart, "recStart");
            this.recStart.Name = "recStart";
            this.recStart.UseVisualStyleBackColor = true;
            this.recStart.Click += new System.EventHandler(this.recStart_Click);
            // 
            // btnKill
            // 
            resources.ApplyResources(this.btnKill, "btnKill");
            this.btnKill.Name = "btnKill";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // btnTest
            // 
            resources.ApplyResources(this.btnTest, "btnTest");
            this.btnTest.Name = "btnTest";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.test_Click);
            // 
            // tsText
            // 
            resources.ApplyResources(this.tsText, "tsText");
            this.tsText.Name = "tsText";
            // 
            // dTP
            // 
            resources.ApplyResources(this.dTP, "dTP");
            this.dTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTP.Name = "dTP";
            this.dTP.Value = new System.DateTime(2017, 5, 28, 0, 0, 0, 0);
            this.dTP.ValueChanged += new System.EventHandler(this.dTP_ValueChanged);
            // 
            // lbTime
            // 
            resources.ApplyResources(this.lbTime, "lbTime");
            this.lbTime.Name = "lbTime";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgvSc
            // 
            this.dgvSc.AllowUserToAddRows = false;
            this.dgvSc.AllowUserToOrderColumns = true;
            this.dgvSc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chName,
            this.chNum,
            this.chWeek,
            this.chTime,
            this.sycle,
            this.recTimeAll,
            this.recSpan});
            resources.ApplyResources(this.dgvSc, "dgvSc");
            this.dgvSc.Name = "dgvSc";
            this.dgvSc.RowTemplate.Height = 21;
            this.dgvSc.CurrentCellChanged += new System.EventHandler(this.dgvSc_CurrentCellChanged);
            this.dgvSc.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSc_DataError);
            this.dgvSc.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvSc_UserDeletingRow);
            // 
            // chName
            // 
            this.chName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.chName, "chName");
            this.chName.Name = "chName";
            this.chName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chNum
            // 
            this.chNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.chNum, "chNum");
            this.chNum.Items.AddRange(new object[] {
            "NHK総合",
            "Eテレ",
            "tvk",
            "日本テレビ",
            "テレビ朝日",
            "TBS",
            "テレビ東京",
            "フジテレビジョン",
            "TOKYO_MX",
            "ＷＯＷＯＷプライム",
            "ＷＯＷＯＷライブ",
            "ＷＯＷＯＷシネマ",
            "スターチャンネル１",
            "スターチャンネル２",
            "スターチャンネル３",
            "ＢＳ１１イレブン",
            "ＢＳスカパー",
            "ＡＴＸ"});
            this.chNum.Name = "chNum";
            this.chNum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // chWeek
            // 
            this.chWeek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.chWeek, "chWeek");
            this.chWeek.Name = "chWeek";
            this.chWeek.ReadOnly = true;
            this.chWeek.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chTime
            // 
            this.chTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.chTime, "chTime");
            this.chTime.Name = "chTime";
            this.chTime.ReadOnly = true;
            this.chTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sycle
            // 
            this.sycle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            resources.ApplyResources(this.sycle, "sycle");
            this.sycle.Items.AddRange(new object[] {
            "毎週",
            "一回のみ",
            "毎日"});
            this.sycle.Name = "sycle";
            this.sycle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // recTimeAll
            // 
            this.recTimeAll.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.recTimeAll, "recTimeAll");
            this.recTimeAll.Name = "recTimeAll";
            this.recTimeAll.ReadOnly = true;
            this.recTimeAll.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // recSpan
            // 
            resources.ApplyResources(this.recSpan, "recSpan");
            this.recSpan.Name = "recSpan";
            this.recSpan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lbTest
            // 
            resources.ApplyResources(this.lbTest, "lbTest");
            this.lbTest.Name = "lbTest";
            // 
            // cbSycle
            // 
            this.cbSycle.FormattingEnabled = true;
            this.cbSycle.Items.AddRange(new object[] {
            resources.GetString("cbSycle.Items"),
            resources.GetString("cbSycle.Items1"),
            resources.GetString("cbSycle.Items2")});
            resources.ApplyResources(this.cbSycle, "cbSycle");
            this.cbSycle.Name = "cbSycle";
            // 
            // cbChannel
            // 
            this.cbChannel.FormattingEnabled = true;
            this.cbChannel.Items.AddRange(new object[] {
            resources.GetString("cbChannel.Items"),
            resources.GetString("cbChannel.Items1"),
            resources.GetString("cbChannel.Items2"),
            resources.GetString("cbChannel.Items3"),
            resources.GetString("cbChannel.Items4"),
            resources.GetString("cbChannel.Items5"),
            resources.GetString("cbChannel.Items6"),
            resources.GetString("cbChannel.Items7"),
            resources.GetString("cbChannel.Items8"),
            resources.GetString("cbChannel.Items9"),
            resources.GetString("cbChannel.Items10"),
            resources.GetString("cbChannel.Items11"),
            resources.GetString("cbChannel.Items12"),
            resources.GetString("cbChannel.Items13"),
            resources.GetString("cbChannel.Items14"),
            resources.GetString("cbChannel.Items15"),
            resources.GetString("cbChannel.Items16"),
            resources.GetString("cbChannel.Items17")});
            resources.ApplyResources(this.cbChannel, "cbChannel");
            this.cbChannel.Name = "cbChannel";
            // 
            // tbChName
            // 
            resources.ApplyResources(this.tbChName, "tbChName");
            this.tbChName.Name = "tbChName";
            // 
            // newCh
            // 
            resources.ApplyResources(this.newCh, "newCh");
            this.newCh.Name = "newCh";
            this.newCh.UseVisualStyleBackColor = true;
            this.newCh.Click += new System.EventHandler(this.newCh_Click);
            // 
            // nfiRecsec
            // 
            resources.ApplyResources(this.nfiRecsec, "nfiRecsec");
            this.nfiRecsec.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfiRecsec_MouseDoubleClick);
            // 
            // recSpanPicker
            // 
            resources.ApplyResources(this.recSpanPicker, "recSpanPicker");
            this.recSpanPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.recSpanPicker.Name = "recSpanPicker";
            this.recSpanPicker.ShowUpDown = true;
            this.recSpanPicker.Value = new System.DateTime(2000, 1, 1, 0, 30, 0, 0);
            this.recSpanPicker.ValueChanged += new System.EventHandler(this.recSpanPicker_ValueChanged);
            // 
            // roadButton
            // 
            resources.ApplyResources(this.roadButton, "roadButton");
            this.roadButton.Name = "roadButton";
            this.roadButton.UseVisualStyleBackColor = true;
            this.roadButton.Click += new System.EventHandler(this.roadButton_Click);
            // 
            // btnMute
            // 
            resources.ApplyResources(this.btnMute, "btnMute");
            this.btnMute.Name = "btnMute";
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // lbNextTime
            // 
            resources.ApplyResources(this.lbNextTime, "lbNextTime");
            this.lbNextTime.Name = "lbNextTime";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.recSpanPicker);
            this.Controls.Add(this.newCh);
            this.Controls.Add(this.tbChName);
            this.Controls.Add(this.cbChannel);
            this.Controls.Add(this.cbSycle);
            this.Controls.Add(this.lbTest);
            this.Controls.Add(this.dgvSc);
            this.Controls.Add(this.lbNextTime);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.dTP);
            this.Controls.Add(this.tsText);
            this.Controls.Add(this.roadButton);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.recStart);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ClientSizeChanged += new System.EventHandler(this.Form1_ClientSizeChanged);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button recStart;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox tsText;
        private System.Windows.Forms.DateTimePicker dTP;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dgvSc;
        private System.Windows.Forms.Label lbTest;
        private System.Windows.Forms.ComboBox cbSycle;
        private System.Windows.Forms.ComboBox cbChannel;
        private System.Windows.Forms.TextBox tbChName;
        private System.Windows.Forms.Button newCh;
        private System.Windows.Forms.NotifyIcon nfiRecsec;
        private System.Windows.Forms.DateTimePicker recSpanPicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn chName;
        private System.Windows.Forms.DataGridViewComboBoxColumn chNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn chWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTime;
        private System.Windows.Forms.DataGridViewComboBoxColumn sycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn recTimeAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn recSpan;
        private System.Windows.Forms.Button roadButton;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Label lbNextTime;
    }
}

