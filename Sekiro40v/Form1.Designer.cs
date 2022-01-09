
namespace Sekiro40v
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalTab = new System.Windows.Forms.TabPage();
            this.GeneralEraseStatisticsButton = new System.Windows.Forms.Button();
            this.GeneralRestoreDefaultSettingsButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.GeneralStatusMemoryHookInput = new System.Windows.Forms.TextBox();
            this.GeneralStatusWebserverInput = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.webServerPortInput = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.memoryHookTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.resetStatisticsButton = new System.Windows.Forms.Button();
            this.totalDamageInput = new System.Windows.Forms.NumericUpDown();
            this.totalDeathsInput = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.maxHPInput = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.currentHPInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pidInput = new System.Windows.Forms.TextBox();
            this.statusInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.memoryOffsetInput = new System.Windows.Forms.NumericUpDown();
            this.maxReadsPerMinuteInput = new System.Windows.Forms.NumericUpDown();
            this.processNameInput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DeathCounterCopyUrlButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.DeathCounterImageSizeLabel = new System.Windows.Forms.Label();
            this.DeathCounterImageOffsetYLabel = new System.Windows.Forms.Label();
            this.DeathCounterImageOffsetXLabel = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.DeathCounterImageInput = new System.Windows.Forms.ComboBox();
            this.DeathCounterImageSizeInput = new System.Windows.Forms.TrackBar();
            this.DeathCounterImageOffsetYInput = new System.Windows.Forms.TrackBar();
            this.DeathCounterColorButton = new System.Windows.Forms.Button();
            this.DeathCounterFontFamilyInput = new System.Windows.Forms.TextBox();
            this.DeathCounterImageOffsetXInput = new System.Windows.Forms.TrackBar();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.DeathCounterAlignToRightRadio = new System.Windows.Forms.RadioButton();
            this.DeathCounterAlignToLeftRadio = new System.Windows.Forms.RadioButton();
            this.DeathCounterCounterInput = new System.Windows.Forms.NumericUpDown();
            this.DeathCounterDecrementButton = new System.Windows.Forms.Button();
            this.DeathCounterIncrementButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl1.SuspendLayout();
            this.generalTab.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webServerPortInput)).BeginInit();
            this.memoryHookTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totalDamageInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalDeathsInput)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxHPInput)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoryOffsetInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxReadsPerMinuteInput)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeathCounterImageSizeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeathCounterImageOffsetYInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeathCounterImageOffsetXInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeathCounterCounterInput)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalTab);
            this.tabControl1.Controls.Add(this.memoryHookTab);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(298, 429);
            this.tabControl1.TabIndex = 0;
            // 
            // generalTab
            // 
            this.generalTab.Controls.Add(this.GeneralEraseStatisticsButton);
            this.generalTab.Controls.Add(this.GeneralRestoreDefaultSettingsButton);
            this.generalTab.Controls.Add(this.groupBox5);
            this.generalTab.Controls.Add(this.groupBox4);
            this.generalTab.Location = new System.Drawing.Point(4, 24);
            this.generalTab.Name = "generalTab";
            this.generalTab.Padding = new System.Windows.Forms.Padding(3);
            this.generalTab.Size = new System.Drawing.Size(290, 401);
            this.generalTab.TabIndex = 0;
            this.generalTab.Text = "General";
            this.generalTab.UseVisualStyleBackColor = true;
            // 
            // GeneralEraseStatisticsButton
            // 
            this.GeneralEraseStatisticsButton.Location = new System.Drawing.Point(6, 343);
            this.GeneralEraseStatisticsButton.Name = "GeneralEraseStatisticsButton";
            this.GeneralEraseStatisticsButton.Size = new System.Drawing.Size(159, 23);
            this.GeneralEraseStatisticsButton.TabIndex = 3;
            this.GeneralEraseStatisticsButton.Text = "Erase all statistics";
            this.GeneralEraseStatisticsButton.UseVisualStyleBackColor = true;
            // 
            // GeneralRestoreDefaultSettingsButton
            // 
            this.GeneralRestoreDefaultSettingsButton.Location = new System.Drawing.Point(6, 372);
            this.GeneralRestoreDefaultSettingsButton.Name = "GeneralRestoreDefaultSettingsButton";
            this.GeneralRestoreDefaultSettingsButton.Size = new System.Drawing.Size(159, 23);
            this.GeneralRestoreDefaultSettingsButton.TabIndex = 2;
            this.GeneralRestoreDefaultSettingsButton.Text = "Restore default settings";
            this.GeneralRestoreDefaultSettingsButton.UseVisualStyleBackColor = true;
            this.GeneralRestoreDefaultSettingsButton.Click += new System.EventHandler(this.GeneralRestoreDefaultSettingsButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.GeneralStatusMemoryHookInput);
            this.groupBox5.Controls.Add(this.GeneralStatusWebserverInput);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 57);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(284, 85);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Status";
            // 
            // GeneralStatusMemoryHookInput
            // 
            this.GeneralStatusMemoryHookInput.Enabled = false;
            this.GeneralStatusMemoryHookInput.Location = new System.Drawing.Point(178, 51);
            this.GeneralStatusMemoryHookInput.Name = "GeneralStatusMemoryHookInput";
            this.GeneralStatusMemoryHookInput.Size = new System.Drawing.Size(100, 23);
            this.GeneralStatusMemoryHookInput.TabIndex = 1;
            // 
            // GeneralStatusWebserverInput
            // 
            this.GeneralStatusWebserverInput.Enabled = false;
            this.GeneralStatusWebserverInput.Location = new System.Drawing.Point(178, 22);
            this.GeneralStatusWebserverInput.Name = "GeneralStatusWebserverInput";
            this.GeneralStatusWebserverInput.Size = new System.Drawing.Size(100, 23);
            this.GeneralStatusWebserverInput.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "MemoryHook";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "WebServer";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.webServerPortInput);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(284, 54);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // webServerPortInput
            // 
            this.webServerPortInput.Location = new System.Drawing.Point(178, 22);
            this.webServerPortInput.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.webServerPortInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.webServerPortInput.Name = "webServerPortInput";
            this.webServerPortInput.Size = new System.Drawing.Size(100, 23);
            this.webServerPortInput.TabIndex = 1;
            this.webServerPortInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.webServerPortInput.ValueChanged += new System.EventHandler(this.webServerPortInput_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "WebServer port";
            // 
            // memoryHookTab
            // 
            this.memoryHookTab.Controls.Add(this.groupBox3);
            this.memoryHookTab.Controls.Add(this.groupBox2);
            this.memoryHookTab.Controls.Add(this.groupBox1);
            this.memoryHookTab.Location = new System.Drawing.Point(4, 24);
            this.memoryHookTab.Name = "memoryHookTab";
            this.memoryHookTab.Padding = new System.Windows.Forms.Padding(3);
            this.memoryHookTab.Size = new System.Drawing.Size(290, 401);
            this.memoryHookTab.TabIndex = 1;
            this.memoryHookTab.Text = "MemoryHook";
            this.memoryHookTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.resetStatisticsButton);
            this.groupBox3.Controls.Add(this.totalDamageInput);
            this.groupBox3.Controls.Add(this.totalDeathsInput);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 261);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(284, 134);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Statistics";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Total damage";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Total deaths";
            // 
            // resetStatisticsButton
            // 
            this.resetStatisticsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetStatisticsButton.Location = new System.Drawing.Point(6, 105);
            this.resetStatisticsButton.Name = "resetStatisticsButton";
            this.resetStatisticsButton.Size = new System.Drawing.Size(100, 23);
            this.resetStatisticsButton.TabIndex = 2;
            this.resetStatisticsButton.Text = "Reset statistics";
            this.resetStatisticsButton.UseVisualStyleBackColor = true;
            this.resetStatisticsButton.Click += new System.EventHandler(this.resetStatisticsButton_Click);
            // 
            // totalDamageInput
            // 
            this.totalDamageInput.Location = new System.Drawing.Point(178, 51);
            this.totalDamageInput.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.totalDamageInput.Name = "totalDamageInput";
            this.totalDamageInput.Size = new System.Drawing.Size(100, 23);
            this.totalDamageInput.TabIndex = 1;
            this.totalDamageInput.ValueChanged += new System.EventHandler(this.totalDamageInput_ValueChanged);
            // 
            // totalDeathsInput
            // 
            this.totalDeathsInput.Location = new System.Drawing.Point(178, 22);
            this.totalDeathsInput.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.totalDeathsInput.Name = "totalDeathsInput";
            this.totalDeathsInput.Size = new System.Drawing.Size(100, 23);
            this.totalDeathsInput.TabIndex = 0;
            this.totalDeathsInput.ValueChanged += new System.EventHandler(this.totalDeathsInput_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maxHPInput);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.currentHPInput);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.pidInput);
            this.groupBox2.Controls.Add(this.statusInput);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 144);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // maxHPInput
            // 
            this.maxHPInput.Location = new System.Drawing.Point(178, 109);
            this.maxHPInput.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.maxHPInput.Name = "maxHPInput";
            this.maxHPInput.Size = new System.Drawing.Size(100, 23);
            this.maxHPInput.TabIndex = 2;
            this.maxHPInput.ValueChanged += new System.EventHandler(this.maxHPInput_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Max. HP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Current HP";
            // 
            // currentHPInput
            // 
            this.currentHPInput.Enabled = false;
            this.currentHPInput.Location = new System.Drawing.Point(178, 80);
            this.currentHPInput.Name = "currentHPInput";
            this.currentHPInput.Size = new System.Drawing.Size(100, 23);
            this.currentHPInput.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "PID";
            // 
            // pidInput
            // 
            this.pidInput.Enabled = false;
            this.pidInput.Location = new System.Drawing.Point(178, 50);
            this.pidInput.Name = "pidInput";
            this.pidInput.Size = new System.Drawing.Size(100, 23);
            this.pidInput.TabIndex = 3;
            // 
            // statusInput
            // 
            this.statusInput.Enabled = false;
            this.statusInput.Location = new System.Drawing.Point(178, 20);
            this.statusInput.Name = "statusInput";
            this.statusInput.Size = new System.Drawing.Size(100, 23);
            this.statusInput.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.memoryOffsetInput);
            this.groupBox1.Controls.Add(this.maxReadsPerMinuteInput);
            this.groupBox1.Controls.Add(this.processNameInput);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // memoryOffsetInput
            // 
            this.memoryOffsetInput.Location = new System.Drawing.Point(178, 79);
            this.memoryOffsetInput.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.memoryOffsetInput.Name = "memoryOffsetInput";
            this.memoryOffsetInput.Size = new System.Drawing.Size(100, 23);
            this.memoryOffsetInput.TabIndex = 2;
            this.memoryOffsetInput.ValueChanged += new System.EventHandler(this.memoryOffsetInput_ValueChanged);
            // 
            // maxReadsPerMinuteInput
            // 
            this.maxReadsPerMinuteInput.Location = new System.Drawing.Point(178, 50);
            this.maxReadsPerMinuteInput.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.maxReadsPerMinuteInput.Name = "maxReadsPerMinuteInput";
            this.maxReadsPerMinuteInput.Size = new System.Drawing.Size(100, 23);
            this.maxReadsPerMinuteInput.TabIndex = 2;
            this.maxReadsPerMinuteInput.ValueChanged += new System.EventHandler(this.maxReadsPerMinuteInput_ValueChanged);
            // 
            // processNameInput
            // 
            this.processNameInput.Location = new System.Drawing.Point(178, 20);
            this.processNameInput.Name = "processNameInput";
            this.processNameInput.Size = new System.Drawing.Size(100, 23);
            this.processNameInput.TabIndex = 1;
            this.processNameInput.TextChanged += new System.EventHandler(this.processNameInput_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Memory offset";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Max. reads per minute";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Process name";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DeathCounterCopyUrlButton);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.DeathCounterCounterInput);
            this.tabPage1.Controls.Add(this.DeathCounterDecrementButton);
            this.tabPage1.Controls.Add(this.DeathCounterIncrementButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(290, 401);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "DeathCounter";
            // 
            // DeathCounterCopyUrlButton
            // 
            this.DeathCounterCopyUrlButton.Location = new System.Drawing.Point(6, 372);
            this.DeathCounterCopyUrlButton.Name = "DeathCounterCopyUrlButton";
            this.DeathCounterCopyUrlButton.Size = new System.Drawing.Size(75, 23);
            this.DeathCounterCopyUrlButton.TabIndex = 3;
            this.DeathCounterCopyUrlButton.Text = "Copy URL";
            this.DeathCounterCopyUrlButton.UseVisualStyleBackColor = true;
            this.DeathCounterCopyUrlButton.Click += new System.EventHandler(this.DeathCounterCopyUrlButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.DeathCounterImageSizeLabel);
            this.groupBox6.Controls.Add(this.DeathCounterImageOffsetYLabel);
            this.groupBox6.Controls.Add(this.DeathCounterImageOffsetXLabel);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.DeathCounterImageInput);
            this.groupBox6.Controls.Add(this.DeathCounterImageSizeInput);
            this.groupBox6.Controls.Add(this.DeathCounterImageOffsetYInput);
            this.groupBox6.Controls.Add(this.DeathCounterColorButton);
            this.groupBox6.Controls.Add(this.DeathCounterFontFamilyInput);
            this.groupBox6.Controls.Add(this.DeathCounterImageOffsetXInput);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.DeathCounterAlignToRightRadio);
            this.groupBox6.Controls.Add(this.DeathCounterAlignToLeftRadio);
            this.groupBox6.Location = new System.Drawing.Point(7, 36);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(277, 259);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Appearance";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 196);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(62, 15);
            this.label22.TabIndex = 9;
            this.label22.Text = "Image size";
            // 
            // DeathCounterImageSizeLabel
            // 
            this.DeathCounterImageSizeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DeathCounterImageSizeLabel.Location = new System.Drawing.Point(95, 198);
            this.DeathCounterImageSizeLabel.Name = "DeathCounterImageSizeLabel";
            this.DeathCounterImageSizeLabel.Size = new System.Drawing.Size(74, 15);
            this.DeathCounterImageSizeLabel.TabIndex = 8;
            this.DeathCounterImageSizeLabel.Text = "04";
            this.DeathCounterImageSizeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DeathCounterImageOffsetYLabel
            // 
            this.DeathCounterImageOffsetYLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DeathCounterImageOffsetYLabel.Location = new System.Drawing.Point(95, 168);
            this.DeathCounterImageOffsetYLabel.Name = "DeathCounterImageOffsetYLabel";
            this.DeathCounterImageOffsetYLabel.Size = new System.Drawing.Size(74, 15);
            this.DeathCounterImageOffsetYLabel.TabIndex = 8;
            this.DeathCounterImageOffsetYLabel.Text = "04";
            this.DeathCounterImageOffsetYLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DeathCounterImageOffsetXLabel
            // 
            this.DeathCounterImageOffsetXLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DeathCounterImageOffsetXLabel.Location = new System.Drawing.Point(95, 139);
            this.DeathCounterImageOffsetXLabel.Name = "DeathCounterImageOffsetXLabel";
            this.DeathCounterImageOffsetXLabel.Size = new System.Drawing.Size(74, 15);
            this.DeathCounterImageOffsetXLabel.TabIndex = 8;
            this.DeathCounterImageOffsetXLabel.Text = "04";
            this.DeathCounterImageOffsetXLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label16.Location = new System.Drawing.Point(6, 222);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(265, 34);
            this.label16.TabIndex = 4;
            this.label16.Text = "You can use any font installed on your computer or from Google Fonts.";
            // 
            // DeathCounterImageInput
            // 
            this.DeathCounterImageInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeathCounterImageInput.FormattingEnabled = true;
            this.DeathCounterImageInput.IntegralHeight = false;
            this.DeathCounterImageInput.Items.AddRange(new object[] {
            "Hide",
            "Left",
            "Right"});
            this.DeathCounterImageInput.Location = new System.Drawing.Point(171, 106);
            this.DeathCounterImageInput.Name = "DeathCounterImageInput";
            this.DeathCounterImageInput.Size = new System.Drawing.Size(100, 23);
            this.DeathCounterImageInput.TabIndex = 7;
            this.DeathCounterImageInput.SelectedIndexChanged += new System.EventHandler(this.DeathCounterImageInput_SelectedIndexChanged);
            // 
            // DeathCounterImageSizeInput
            // 
            this.DeathCounterImageSizeInput.LargeChange = 1;
            this.DeathCounterImageSizeInput.Location = new System.Drawing.Point(167, 196);
            this.DeathCounterImageSizeInput.Maximum = 150;
            this.DeathCounterImageSizeInput.Minimum = 1;
            this.DeathCounterImageSizeInput.Name = "DeathCounterImageSizeInput";
            this.DeathCounterImageSizeInput.Size = new System.Drawing.Size(104, 45);
            this.DeathCounterImageSizeInput.TabIndex = 6;
            this.DeathCounterImageSizeInput.TickStyle = System.Windows.Forms.TickStyle.None;
            this.DeathCounterImageSizeInput.Value = 1;
            this.DeathCounterImageSizeInput.Scroll += new System.EventHandler(this.DeathCounterImageSizeInput_Scroll);
            // 
            // DeathCounterImageOffsetYInput
            // 
            this.DeathCounterImageOffsetYInput.LargeChange = 1;
            this.DeathCounterImageOffsetYInput.Location = new System.Drawing.Point(167, 166);
            this.DeathCounterImageOffsetYInput.Maximum = 50;
            this.DeathCounterImageOffsetYInput.Minimum = -50;
            this.DeathCounterImageOffsetYInput.Name = "DeathCounterImageOffsetYInput";
            this.DeathCounterImageOffsetYInput.Size = new System.Drawing.Size(104, 45);
            this.DeathCounterImageOffsetYInput.TabIndex = 6;
            this.DeathCounterImageOffsetYInput.TickStyle = System.Windows.Forms.TickStyle.None;
            this.DeathCounterImageOffsetYInput.Scroll += new System.EventHandler(this.DeathCounterImageOffsetYInput_Scroll);
            // 
            // DeathCounterColorButton
            // 
            this.DeathCounterColorButton.BackColor = System.Drawing.Color.Transparent;
            this.DeathCounterColorButton.Location = new System.Drawing.Point(171, 77);
            this.DeathCounterColorButton.Name = "DeathCounterColorButton";
            this.DeathCounterColorButton.Size = new System.Drawing.Size(100, 23);
            this.DeathCounterColorButton.TabIndex = 5;
            this.DeathCounterColorButton.Text = "Change";
            this.DeathCounterColorButton.UseVisualStyleBackColor = false;
            this.DeathCounterColorButton.Click += new System.EventHandler(this.DeathCounterColorButton_Click);
            // 
            // DeathCounterFontFamilyInput
            // 
            this.DeathCounterFontFamilyInput.Location = new System.Drawing.Point(171, 48);
            this.DeathCounterFontFamilyInput.Name = "DeathCounterFontFamilyInput";
            this.DeathCounterFontFamilyInput.Size = new System.Drawing.Size(100, 23);
            this.DeathCounterFontFamilyInput.TabIndex = 4;
            this.DeathCounterFontFamilyInput.TextChanged += new System.EventHandler(this.DeathCounterFontFamilyInput_TextChanged);
            // 
            // DeathCounterImageOffsetXInput
            // 
            this.DeathCounterImageOffsetXInput.LargeChange = 1;
            this.DeathCounterImageOffsetXInput.Location = new System.Drawing.Point(167, 137);
            this.DeathCounterImageOffsetXInput.Maximum = 50;
            this.DeathCounterImageOffsetXInput.Minimum = -50;
            this.DeathCounterImageOffsetXInput.Name = "DeathCounterImageOffsetXInput";
            this.DeathCounterImageOffsetXInput.Size = new System.Drawing.Size(104, 45);
            this.DeathCounterImageOffsetXInput.TabIndex = 6;
            this.DeathCounterImageOffsetXInput.TickStyle = System.Windows.Forms.TickStyle.None;
            this.DeathCounterImageOffsetXInput.Scroll += new System.EventHandler(this.DeathCounterImageOffsetXInput_Scroll);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 168);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 15);
            this.label18.TabIndex = 3;
            this.label18.Text = "Image offset Y";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 139);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 15);
            this.label17.TabIndex = 3;
            this.label17.Text = "Image offset X";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 109);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 15);
            this.label19.TabIndex = 3;
            this.label19.Text = "Image";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 15);
            this.label15.TabIndex = 3;
            this.label15.Text = "Color";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 15);
            this.label14.TabIndex = 3;
            this.label14.Text = "Font family";
            // 
            // DeathCounterAlignToRightRadio
            // 
            this.DeathCounterAlignToRightRadio.AutoSize = true;
            this.DeathCounterAlignToRightRadio.Location = new System.Drawing.Point(176, 23);
            this.DeathCounterAlignToRightRadio.Name = "DeathCounterAlignToRightRadio";
            this.DeathCounterAlignToRightRadio.Size = new System.Drawing.Size(95, 19);
            this.DeathCounterAlignToRightRadio.TabIndex = 1;
            this.DeathCounterAlignToRightRadio.TabStop = true;
            this.DeathCounterAlignToRightRadio.Text = "Align to right";
            this.DeathCounterAlignToRightRadio.UseVisualStyleBackColor = true;
            this.DeathCounterAlignToRightRadio.CheckedChanged += new System.EventHandler(this.DeathCounterAlignToRightRadio_CheckedChanged);
            // 
            // DeathCounterAlignToLeftRadio
            // 
            this.DeathCounterAlignToLeftRadio.AutoSize = true;
            this.DeathCounterAlignToLeftRadio.Location = new System.Drawing.Point(6, 23);
            this.DeathCounterAlignToLeftRadio.Name = "DeathCounterAlignToLeftRadio";
            this.DeathCounterAlignToLeftRadio.Size = new System.Drawing.Size(87, 19);
            this.DeathCounterAlignToLeftRadio.TabIndex = 0;
            this.DeathCounterAlignToLeftRadio.TabStop = true;
            this.DeathCounterAlignToLeftRadio.Text = "Align to left";
            this.DeathCounterAlignToLeftRadio.UseVisualStyleBackColor = true;
            this.DeathCounterAlignToLeftRadio.CheckedChanged += new System.EventHandler(this.DeathCounterAlignToLeftRadio_CheckedChanged);
            // 
            // DeathCounterCounterInput
            // 
            this.DeathCounterCounterInput.Location = new System.Drawing.Point(87, 6);
            this.DeathCounterCounterInput.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.DeathCounterCounterInput.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.DeathCounterCounterInput.Name = "DeathCounterCounterInput";
            this.DeathCounterCounterInput.Size = new System.Drawing.Size(116, 23);
            this.DeathCounterCounterInput.TabIndex = 1;
            this.DeathCounterCounterInput.ValueChanged += new System.EventHandler(this.DeathCounterCounterInput_ValueChanged);
            // 
            // DeathCounterDecrementButton
            // 
            this.DeathCounterDecrementButton.Location = new System.Drawing.Point(6, 6);
            this.DeathCounterDecrementButton.Name = "DeathCounterDecrementButton";
            this.DeathCounterDecrementButton.Size = new System.Drawing.Size(75, 23);
            this.DeathCounterDecrementButton.TabIndex = 0;
            this.DeathCounterDecrementButton.Text = "Decrement";
            this.DeathCounterDecrementButton.UseVisualStyleBackColor = true;
            this.DeathCounterDecrementButton.Click += new System.EventHandler(this.DeathCounterDecrementButton_Click);
            // 
            // DeathCounterIncrementButton
            // 
            this.DeathCounterIncrementButton.Location = new System.Drawing.Point(209, 6);
            this.DeathCounterIncrementButton.Name = "DeathCounterIncrementButton";
            this.DeathCounterIncrementButton.Size = new System.Drawing.Size(75, 23);
            this.DeathCounterIncrementButton.TabIndex = 0;
            this.DeathCounterIncrementButton.Text = "Increment";
            this.DeathCounterIncrementButton.UseVisualStyleBackColor = true;
            this.DeathCounterIncrementButton.Click += new System.EventHandler(this.DeathCounterIncrementButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(298, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(115, 17);
            this.toolStripStatusLabel1.Text = "sekiro40v by kubagp";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 460);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Sekiro40v";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.generalTab.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webServerPortInput)).EndInit();
            this.memoryHookTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totalDamageInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalDeathsInput)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxHPInput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoryOffsetInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxReadsPerMinuteInput)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeathCounterImageSizeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeathCounterImageOffsetYInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeathCounterImageOffsetXInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeathCounterCounterInput)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalTab;
        private System.Windows.Forms.TabPage memoryHookTab;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox processNameInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox statusInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox currentHPInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pidInput;
        private System.Windows.Forms.NumericUpDown memoryOffsetInput;
        private System.Windows.Forms.NumericUpDown maxReadsPerMinuteInput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown maxHPInput;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button resetStatisticsButton;
        private System.Windows.Forms.NumericUpDown totalDamageInput;
        private System.Windows.Forms.NumericUpDown totalDeathsInput;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown DeathCounterCounterInput;
        private System.Windows.Forms.Button DeathCounterDecrementButton;
        private System.Windows.Forms.Button DeathCounterIncrementButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown webServerPortInput;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox GeneralStatusWebserverInput;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox GeneralStatusMemoryHookInput;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton DeathCounterAlignToRightRadio;
        private System.Windows.Forms.RadioButton DeathCounterAlignToLeftRadio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button DeathCounterColorButton;
        private System.Windows.Forms.TextBox DeathCounterFontFamilyInput;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button DeathCounterCopyUrlButton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar DeathCounterImageOffsetXInput;
        private System.Windows.Forms.TrackBar DeathCounterImageOffsetYInput;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox DeathCounterImageInput;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label DeathCounterImageOffsetYLabel;
        private System.Windows.Forms.Label DeathCounterImageOffsetXLabel;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label DeathCounterImageSizeLabel;
        private System.Windows.Forms.TrackBar DeathCounterImageSizeInput;
        private System.Windows.Forms.Button GeneralRestoreDefaultSettingsButton;
        private System.Windows.Forms.Button GeneralEraseStatisticsButton;
    }
}

