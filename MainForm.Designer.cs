namespace SubscriberCounterTool;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.LYTChannelID = new System.Windows.Forms.Label();
            this.TBYTChannelID = new System.Windows.Forms.TextBox();
            this.LCustomSubscriberAmount = new System.Windows.Forms.Label();
            this.NUDCustomSubscriberAmount = new System.Windows.Forms.NumericUpDown();
            this.CBUseTranslate = new System.Windows.Forms.CheckBox();
            this.CBForceChromium = new System.Windows.Forms.CheckBox();
            this.CBIsDevelopmentMode = new System.Windows.Forms.CheckBox();
            this.BtnTakeScreensshot = new System.Windows.Forms.Button();
            this.LLog = new System.Windows.Forms.Label();
            this.TBLog = new System.Windows.Forms.TextBox();
            this.LVersion = new System.Windows.Forms.Label();
            this.LWebSite = new System.Windows.Forms.Label();
            this.LLWebSite = new System.Windows.Forms.LinkLabel();
            this.CBUseClip = new System.Windows.Forms.CheckBox();
            this.CBAddTimestamp = new System.Windows.Forms.CheckBox();
            this.LCustomTimestamp = new System.Windows.Forms.Label();
            this.DTPTimestamp = new System.Windows.Forms.DateTimePicker();
            this.CBBlurBackground = new System.Windows.Forms.CheckBox();
            this.BtnRest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCustomSubscriberAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // LYTChannelID
            // 
            this.LYTChannelID.AutoSize = true;
            this.LYTChannelID.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LYTChannelID.Location = new System.Drawing.Point(12, 9);
            this.LYTChannelID.Name = "LYTChannelID";
            this.LYTChannelID.Size = new System.Drawing.Size(129, 19);
            this.LYTChannelID.TabIndex = 0;
            this.LYTChannelID.Text = "YouTube 頻道 ID";
            // 
            // TBYTChannelID
            // 
            this.TBYTChannelID.Location = new System.Drawing.Point(12, 31);
            this.TBYTChannelID.Name = "TBYTChannelID";
            this.TBYTChannelID.Size = new System.Drawing.Size(600, 27);
            this.TBYTChannelID.TabIndex = 1;
            this.TBYTChannelID.TextChanged += new System.EventHandler(this.TBYTChannelID_TextChanged);
            // 
            // LCustomSubscriberAmount
            // 
            this.LCustomSubscriberAmount.AutoSize = true;
            this.LCustomSubscriberAmount.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LCustomSubscriberAmount.Location = new System.Drawing.Point(12, 61);
            this.LCustomSubscriberAmount.Name = "LCustomSubscriberAmount";
            this.LCustomSubscriberAmount.Size = new System.Drawing.Size(159, 19);
            this.LCustomSubscriberAmount.TabIndex = 2;
            this.LCustomSubscriberAmount.Text = "自定義頻道訂閱者數量";
            // 
            // NUDCustomSubscriberAmount
            // 
            this.NUDCustomSubscriberAmount.Location = new System.Drawing.Point(12, 83);
            this.NUDCustomSubscriberAmount.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NUDCustomSubscriberAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NUDCustomSubscriberAmount.Name = "NUDCustomSubscriberAmount";
            this.NUDCustomSubscriberAmount.Size = new System.Drawing.Size(600, 27);
            this.NUDCustomSubscriberAmount.TabIndex = 3;
            this.NUDCustomSubscriberAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // CBUseTranslate
            // 
            this.CBUseTranslate.AutoSize = true;
            this.CBUseTranslate.Location = new System.Drawing.Point(618, 12);
            this.CBUseTranslate.Name = "CBUseTranslate";
            this.CBUseTranslate.Size = new System.Drawing.Size(121, 23);
            this.CBUseTranslate.TabIndex = 6;
            this.CBUseTranslate.Text = "套用中文翻譯";
            this.CBUseTranslate.UseVisualStyleBackColor = true;
            this.CBUseTranslate.CheckedChanged += new System.EventHandler(this.CBUseTranslate_CheckedChanged);
            // 
            // CBForceChromium
            // 
            this.CBForceChromium.AutoSize = true;
            this.CBForceChromium.Location = new System.Drawing.Point(618, 128);
            this.CBForceChromium.Name = "CBForceChromium";
            this.CBForceChromium.Size = new System.Drawing.Size(170, 23);
            this.CBForceChromium.TabIndex = 10;
            this.CBForceChromium.Text = "強制使用 Chromium";
            this.CBForceChromium.UseVisualStyleBackColor = true;
            this.CBForceChromium.CheckedChanged += new System.EventHandler(this.CBForceChromium_CheckedChanged);
            // 
            // CBIsDevelopmentMode
            // 
            this.CBIsDevelopmentMode.AutoSize = true;
            this.CBIsDevelopmentMode.Location = new System.Drawing.Point(618, 157);
            this.CBIsDevelopmentMode.Name = "CBIsDevelopmentMode";
            this.CBIsDevelopmentMode.Size = new System.Drawing.Size(91, 23);
            this.CBIsDevelopmentMode.TabIndex = 11;
            this.CBIsDevelopmentMode.Text = "開發模式";
            this.CBIsDevelopmentMode.UseVisualStyleBackColor = true;
            this.CBIsDevelopmentMode.CheckedChanged += new System.EventHandler(this.CBIsDevelopmentMode_CheckedChanged);
            // 
            // BtnTakeScreensshot
            // 
            this.BtnTakeScreensshot.Location = new System.Drawing.Point(618, 186);
            this.BtnTakeScreensshot.Name = "BtnTakeScreensshot";
            this.BtnTakeScreensshot.Size = new System.Drawing.Size(94, 29);
            this.BtnTakeScreensshot.TabIndex = 12;
            this.BtnTakeScreensshot.Text = "儲存截圖";
            this.BtnTakeScreensshot.UseVisualStyleBackColor = true;
            this.BtnTakeScreensshot.Click += new System.EventHandler(this.BtnTakeScreensshot_Click);
            // 
            // LLog
            // 
            this.LLog.AutoSize = true;
            this.LLog.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LLog.Location = new System.Drawing.Point(12, 165);
            this.LLog.Name = "LLog";
            this.LLog.Size = new System.Drawing.Size(39, 19);
            this.LLog.TabIndex = 14;
            this.LLog.Text = "紀錄";
            // 
            // TBLog
            // 
            this.TBLog.Location = new System.Drawing.Point(12, 187);
            this.TBLog.Multiline = true;
            this.TBLog.Name = "TBLog";
            this.TBLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TBLog.Size = new System.Drawing.Size(600, 232);
            this.TBLog.TabIndex = 15;
            // 
            // LVersion
            // 
            this.LVersion.AutoSize = true;
            this.LVersion.Location = new System.Drawing.Point(12, 422);
            this.LVersion.Name = "LVersion";
            this.LVersion.Size = new System.Drawing.Size(39, 19);
            this.LVersion.TabIndex = 16;
            this.LVersion.Text = "版本";
            // 
            // LWebSite
            // 
            this.LWebSite.AutoSize = true;
            this.LWebSite.Location = new System.Drawing.Point(348, 422);
            this.LWebSite.Name = "LWebSite";
            this.LWebSite.Size = new System.Drawing.Size(211, 19);
            this.LWebSite.TabIndex = 17;
            this.LWebSite.Text = "YouTube Subscriber Counter:";
            // 
            // LLWebSite
            // 
            this.LLWebSite.AutoSize = true;
            this.LLWebSite.Location = new System.Drawing.Point(565, 422);
            this.LLWebSite.Name = "LLWebSite";
            this.LLWebSite.Size = new System.Drawing.Size(223, 19);
            this.LLWebSite.TabIndex = 18;
            this.LLWebSite.TabStop = true;
            this.LLWebSite.Text = "https://subscribercounter.com/";
            this.LLWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLWebSite_LinkClicked);
            // 
            // CBUseClip
            // 
            this.CBUseClip.AutoSize = true;
            this.CBUseClip.Location = new System.Drawing.Point(618, 41);
            this.CBUseClip.Name = "CBUseClip";
            this.CBUseClip.Size = new System.Drawing.Size(166, 23);
            this.CBUseClip.TabIndex = 7;
            this.CBUseClip.Text = "裁切截圖（正方形）";
            this.CBUseClip.UseVisualStyleBackColor = true;
            this.CBUseClip.CheckedChanged += new System.EventHandler(this.CBUseClip_CheckedChanged);
            // 
            // CBAddTimestamp
            // 
            this.CBAddTimestamp.AutoSize = true;
            this.CBAddTimestamp.Location = new System.Drawing.Point(618, 70);
            this.CBAddTimestamp.Name = "CBAddTimestamp";
            this.CBAddTimestamp.Size = new System.Drawing.Size(121, 23);
            this.CBAddTimestamp.TabIndex = 8;
            this.CBAddTimestamp.Text = "加入日期戳記";
            this.CBAddTimestamp.UseVisualStyleBackColor = true;
            this.CBAddTimestamp.CheckedChanged += new System.EventHandler(this.CBAddTimestamp_CheckedChanged);
            // 
            // LCustomTimestamp
            // 
            this.LCustomTimestamp.AutoSize = true;
            this.LCustomTimestamp.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LCustomTimestamp.Location = new System.Drawing.Point(12, 113);
            this.LCustomTimestamp.Name = "LCustomTimestamp";
            this.LCustomTimestamp.Size = new System.Drawing.Size(114, 19);
            this.LCustomTimestamp.TabIndex = 4;
            this.LCustomTimestamp.Text = "自定義日期戳記";
            // 
            // DTPTimestamp
            // 
            this.DTPTimestamp.Location = new System.Drawing.Point(12, 135);
            this.DTPTimestamp.Name = "DTPTimestamp";
            this.DTPTimestamp.Size = new System.Drawing.Size(600, 27);
            this.DTPTimestamp.TabIndex = 5;
            // 
            // CBBlurBackground
            // 
            this.CBBlurBackground.AutoSize = true;
            this.CBBlurBackground.Location = new System.Drawing.Point(618, 99);
            this.CBBlurBackground.Name = "CBBlurBackground";
            this.CBBlurBackground.Size = new System.Drawing.Size(91, 23);
            this.CBBlurBackground.TabIndex = 9;
            this.CBBlurBackground.Text = "模糊背景";
            this.CBBlurBackground.UseVisualStyleBackColor = true;
            this.CBBlurBackground.CheckedChanged += new System.EventHandler(this.CBBlurBackground_CheckedChanged);
            // 
            // BtnRest
            // 
            this.BtnRest.Location = new System.Drawing.Point(618, 221);
            this.BtnRest.Name = "BtnRest";
            this.BtnRest.Size = new System.Drawing.Size(94, 29);
            this.BtnRest.TabIndex = 13;
            this.BtnRest.Text = "重設";
            this.BtnRest.UseVisualStyleBackColor = true;
            this.BtnRest.Click += new System.EventHandler(this.BtnRest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnRest);
            this.Controls.Add(this.CBBlurBackground);
            this.Controls.Add(this.DTPTimestamp);
            this.Controls.Add(this.LCustomTimestamp);
            this.Controls.Add(this.CBAddTimestamp);
            this.Controls.Add(this.CBUseClip);
            this.Controls.Add(this.LLWebSite);
            this.Controls.Add(this.LWebSite);
            this.Controls.Add(this.LVersion);
            this.Controls.Add(this.TBLog);
            this.Controls.Add(this.LLog);
            this.Controls.Add(this.BtnTakeScreensshot);
            this.Controls.Add(this.CBIsDevelopmentMode);
            this.Controls.Add(this.CBForceChromium);
            this.Controls.Add(this.CBUseTranslate);
            this.Controls.Add(this.NUDCustomSubscriberAmount);
            this.Controls.Add(this.LCustomSubscriberAmount);
            this.Controls.Add(this.TBYTChannelID);
            this.Controls.Add(this.LYTChannelID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "YT 頻道訂閱者計數器工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUDCustomSubscriberAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Label LYTChannelID;
    private TextBox TBYTChannelID;
    private Label LCustomSubscriberAmount;
    private NumericUpDown NUDCustomSubscriberAmount;
    private CheckBox CBUseTranslate;
    private CheckBox CBForceChromium;
    private CheckBox CBIsDevelopmentMode;
    private Button BtnTakeScreensshot;
    private Label LLog;
    private TextBox TBLog;
    private Label LVersion;
    private Label LWebSite;
    private LinkLabel LLWebSite;
    private CheckBox CBUseClip;
    private CheckBox CBAddTimestamp;
    private Label LCustomTimestamp;
    private DateTimePicker DTPTimestamp;
    private CheckBox CBBlurBackground;
    private Button BtnRest;
}