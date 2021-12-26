
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.memoryHookTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totalDamageInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalDeathsInput)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxHPInput)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoryOffsetInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxReadsPerMinuteInput)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalTab);
            this.tabControl1.Controls.Add(this.memoryHookTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(298, 429);
            this.tabControl1.TabIndex = 0;
            // 
            // generalTab
            // 
            this.generalTab.Location = new System.Drawing.Point(4, 24);
            this.generalTab.Name = "generalTab";
            this.generalTab.Padding = new System.Windows.Forms.Padding(3);
            this.generalTab.Size = new System.Drawing.Size(290, 401);
            this.generalTab.TabIndex = 0;
            this.generalTab.Text = "General";
            this.generalTab.UseVisualStyleBackColor = true;
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(298, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(115, 17);
            this.toolStripStatusLabel1.Text = "sekiro40v by kubagp";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
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
            this.tabControl1.ResumeLayout(false);
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
    }
}

