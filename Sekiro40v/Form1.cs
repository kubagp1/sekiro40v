using System;
using System.Diagnostics;
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

            processNameInput.Text = app.memoryHook.processName;
            maxReadsPerMinuteInput.Value = app.memoryHook.maxRPM;
            memoryOffsetInput.Value = app.memoryHook.offset;

            statusInput.Text = app.memoryHook.status.ToString();

            // Rest is empty while this constructor is running so it's not necessary

            app.memoryHook.StatusChanged += MemoryHook_StatusChanged;

            app.memoryHook.CurrentHPChanged += MemoryHook_CurrentHPChanged;
            app.memoryHook.MaxHPChanged += MemoryHook_MaxHPChanged;

            app.memoryHook.DamageEventHandler += MemoryHook_DamageEventHandler;
            app.memoryHook.DeathEventHandler += MemoryHook_DeathEventHandler;
        }

        private void MemoryHook_DeathEventHandler(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                totalDeathsInput.Value++;
            }));
        }

        private void MemoryHook_DamageEventHandler(object sender, MemoryHook.DamageEventHandlerEventArgs e)
        {
            Invoke(new Action(() =>
            {
                totalDamageInput.Value += e.damage;
            }));
        }

        private void MemoryHook_StatusChanged(object sender, EventArgs e)
        {
            Invoke(new Action(
                () =>
                {
                    statusInput.Text = app.memoryHook.status.ToString();

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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://github.com/kubagp1/sekiro40v");
        }

        private void maxReadsPerMinuteInput_ValueChanged(object sender, EventArgs e)
        {
            app.memoryHook.maxRPM = (int)maxReadsPerMinuteInput.Value;
        }

        private void memoryOffsetInput_ValueChanged(object sender, EventArgs e)
        {
            app.memoryHook.offset = (int)memoryOffsetInput.Value;
        }

        private void resetStatisticsButton_Click(object sender, EventArgs e)
        {
            var userSure = MessageBox.Show("Are you sure you want to reset all statistics of MemoryHook?", "Are you sure?", MessageBoxButtons.YesNoCancel);

            if (userSure == DialogResult.Yes)
            {
                totalDamageInput.Value = 0;
                totalDeathsInput.Value = 0;
            }
        }
    }
}