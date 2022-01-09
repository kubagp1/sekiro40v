﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sekiro40v
{
    public partial class Form1 : Form
    {
        private App app;

        public Form1(App app)
        {
            this.app = app;

            InitializeComponent();

            #region MemoryHook

            processNameInput.Text = app.memoryHook.processName;
            maxReadsPerMinuteInput.Value = app.memoryHook.Config.maxRPM;
            memoryOffsetInput.Value = app.memoryHook.Config.offset;

            statusInput.Text = app.memoryHook.status.ToString();

            totalDamageInput.Value = app.StatisticsManager.statistics.memoryHook.totalDamage;
            totalDeathsInput.Value = app.StatisticsManager.statistics.memoryHook.totalDeaths;

            // Rest is empty while this constructor is running so it's not necessary

            // Event handlers below

            app.memoryHook.StatusChanged += MemoryHook_StatusChanged;

            app.memoryHook.CurrentHPChanged += MemoryHook_CurrentHPChanged;
            app.memoryHook.MaxHPChanged += MemoryHook_MaxHPChanged;

            app.memoryHook.DamageEventHandler += MemoryHook_DamageEventHandler;
            app.memoryHook.DeathEventHandler += MemoryHook_DeathEventHandler;

            #endregion MemoryHook

            #region DeathCounter

            DeathCounterCounterInput.Value = app.deathCounter.Counter;

            Color color = ColorTranslator.FromHtml(app.deathCounter.counterColor);

            colorDialog1.Color = color;

            DeathCounterColorButton.BackColor = color;

            DeathCounterColorButton.ForeColor = color.GetBrightness() < 0.5 ? Color.White : Color.Black;

            DeathCounterFontFamilyInput.Text = app.deathCounter.counterFontFamily;

            switch (app.deathCounter.counterAlign)
            {
                case DeathCounter.CounterAlign.Left:
                    DeathCounterAlignToLeftRadio.Checked = true;
                    break;

                case DeathCounter.CounterAlign.Right:
                    DeathCounterAlignToRightRadio.Checked = true;
                    break;
            }

            DeathCounterImageInput.SelectedIndex = (int)app.deathCounter.counterImageMode;

            DeathCounterImageOffsetXInput.Value = app.deathCounter.counterImageOffsetX;
            DeathCounterImageOffsetXLabel.Text = app.deathCounter.counterImageOffsetX.ToString();

            DeathCounterImageOffsetYInput.Value = app.deathCounter.counterImageOffsetY;
            DeathCounterImageOffsetYLabel.Text = app.deathCounter.counterImageOffsetY.ToString();

            DeathCounterImageSizeInput.Value = app.deathCounter.counterImageSize;
            DeathCounterImageSizeLabel.Text = app.deathCounter.counterImageSize.ToString();

            // Event handlers below

            app.deathCounter.CounterChangedEventHandler += DeathCounter_CounterChangedEventHandler;

            #endregion DeathCounter

            #region General

            GeneralStatusWebserverInput.Text = app.webServerManager.GetWebServerState()?.ToString() ?? "error";

            webServerPortInput.Value = app.webServerManager.Port;
            GeneralStatusMemoryHookInput.Text = app.memoryHook.status.ToString();

            app.webServerManager.WebServerStateChangedEventHandler += WebServerManager_WebServerStateChangedEventHandler;

            #endregion General
        }

        #region WebServer Event Handler

        private void WebServerManager_WebServerStateChangedEventHandler(object sender, EmbedIO.WebServerStateChangedEventArgs e)
        {
            Debug.WriteLine(e.NewState.ToString());
            Invoke(new Action<string>((state) =>
            {
                GeneralStatusWebserverInput.Text = state;
            }), e.NewState.ToString());
        }

        private void webServerPortInput_ValueChanged(object sender, EventArgs e)
        {
            app.webServerManager.Port = (int)webServerPortInput.Value;
        }

        #endregion WebServer Event Handler

        #region DeathCounter Event Handlers

        private void DeathCounter_CounterChangedEventHandler(object sender, DeathCounter.CounterChangedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                DeathCounterCounterInput.Value = e.value;
            }));
        }

        private void DeathCounterIncrementButton_Click(object sender, EventArgs e)
        {
            app.deathCounter.Counter++;
        }

        private void DeathCounterDecrementButton_Click(object sender, EventArgs e)
        {
            app.deathCounter.Counter--;
        }

        private void DeathCounterCounterInput_ValueChanged(object sender, EventArgs e)
        {
            app.deathCounter.Counter = (int)DeathCounterCounterInput.Value;
        }

        private void DeathCounterColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                string hexColor = "#" + (colorDialog1.Color.ToArgb() & 0x00FFFFFF).ToString("X6"); // from stackOverflow
                app.deathCounter.counterColor = hexColor;
                DeathCounterColorButton.BackColor = colorDialog1.Color;
                DeathCounterColorButton.ForeColor = colorDialog1.Color.GetBrightness() < 0.5 ? Color.White : Color.Black;
            }
        }

        private void DeathCounterImageInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            app.deathCounter.counterImageMode = (DeathCounter.ImageMode)DeathCounterImageInput.SelectedIndex;
        }

        private void DeathCounterImageOffsetXInput_Scroll(object sender, EventArgs e)
        {
            app.deathCounter.counterImageOffsetX = DeathCounterImageOffsetXInput.Value;
            DeathCounterImageOffsetXLabel.Text = DeathCounterImageOffsetXInput.Value.ToString();
        }

        private void DeathCounterImageOffsetYInput_Scroll(object sender, EventArgs e)
        {
            app.deathCounter.counterImageOffsetY = DeathCounterImageOffsetYInput.Value;
            DeathCounterImageOffsetYLabel.Text = DeathCounterImageOffsetYInput.Value.ToString();
        }

        private void DeathCounterImageSizeInput_Scroll(object sender, EventArgs e)
        {
            app.deathCounter.counterImageSize = DeathCounterImageSizeInput.Value;
            DeathCounterImageSizeLabel.Text = DeathCounterImageSizeInput.Value.ToString();
        }

        private void DeathCounterFontFamilyInput_TextChanged(object sender, EventArgs e)
        {
            app.deathCounter.counterFontFamily = DeathCounterFontFamilyInput.Text;
        }

        private void DeathCounterAlignToLeftRadio_CheckedChanged(object sender, EventArgs e)
        {
            app.deathCounter.counterAlign = DeathCounter.CounterAlign.Left;
        }

        private void DeathCounterAlignToRightRadio_CheckedChanged(object sender, EventArgs e)
        {
            app.deathCounter.counterAlign = DeathCounter.CounterAlign.Right;
        }

        private void DeathCounterCopyUrlButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"http://127.0.0.1:{app.webServerManager.Port}/counter/counter.html");
        }

        #endregion DeathCounter Event Handlers

        #region MemoryHook Event Handlers

        private void MemoryHook_DeathEventHandler(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                app.StatisticsManager.statistics.memoryHook.totalDeaths++;
                totalDeathsInput.Value = app.StatisticsManager.statistics.memoryHook.totalDeaths;
            }));
        }

        private void MemoryHook_DamageEventHandler(object sender, MemoryHook.DamageEventHandlerEventArgs e)
        {
            Invoke(new Action(() =>
            {
                app.StatisticsManager.statistics.memoryHook.totalDamage += e.damage;
                totalDamageInput.Value = app.StatisticsManager.statistics.memoryHook.totalDamage;
            }));
        }

        private void MemoryHook_StatusChanged(object sender, EventArgs e)
        {
            Invoke(new Action(
                () =>
                {
                    statusInput.Text = app.memoryHook.status.ToString();
                    GeneralStatusMemoryHookInput.Text = app.memoryHook.status.ToString();

                    if (app.memoryHook.status != MemoryHookStatus.Ready)
                    {
                        pidInput.Text = "";
                        currentHPInput.Text = "";
                        maxHPInput.Value = 0;
                    }
                    else
                    {
                        pidInput.Text = app.memoryHook.process.Id.ToString();
                    }
                }
            )
            );
        }

        private void MemoryHook_MaxHPChanged(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                maxHPInput.Text = app.memoryHook.maxHP.ToString();
            }));
        }

        private void MemoryHook_CurrentHPChanged(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                currentHPInput.Text = app.memoryHook.currentHP.ToString();
            }));
        }

        private void processNameInput_TextChanged(object sender, EventArgs e)
        {
            app.memoryHook.processName = Path.GetFileNameWithoutExtension(processNameInput.Text);
        }

        private void maxHPInput_ValueChanged(object sender, EventArgs e)
        {
            app.memoryHook.maxHP = (int)maxHPInput.Value;
        }

        private void maxReadsPerMinuteInput_ValueChanged(object sender, EventArgs e)
        {
            app.memoryHook.Config.maxRPM = (int)maxReadsPerMinuteInput.Value;
        }

        private void memoryOffsetInput_ValueChanged(object sender, EventArgs e)
        {
            app.memoryHook.Config.offset = (int)memoryOffsetInput.Value;
        }

        private void resetStatisticsButton_Click(object sender, EventArgs e)
        {
            var userSure = MessageBox.Show("Are you sure you want to reset all statistics of MemoryHook?", "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (userSure == DialogResult.Yes)
            {
                totalDamageInput.Value = 0;
                app.StatisticsManager.statistics.memoryHook.totalDamage = 0;
                totalDeathsInput.Value = 0;
                app.StatisticsManager.statistics.memoryHook.totalDeaths = 0;
            }
        }

        private void totalDeathsInput_ValueChanged(object sender, EventArgs e)
        {
            app.StatisticsManager.statistics.memoryHook.totalDeaths = (int)totalDeathsInput.Value;
        }

        private void totalDamageInput_ValueChanged(object sender, EventArgs e)
        {
            app.StatisticsManager.statistics.memoryHook.totalDamage = (int)totalDamageInput.Value;
        }

        #endregion MemoryHook Event Handlers

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://github.com/kubagp1/sekiro40v");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            app.Config.SaveSettings();
            app.StatisticsManager.SaveStatistics();
        }

        private void GeneralRestoreDefaultSettingsButton_Click(object sender, EventArgs e)
        {
            var userSure = MessageBox.Show(
                "Are you sure you want to reset all settings?\nApplication will restart!", 
                "Are you sure?", 
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (userSure == DialogResult.Yes)
            {
                app.Config.RestoreDefaults();
                Application.Restart();
            }
        }
    }
}