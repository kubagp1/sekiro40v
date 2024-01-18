using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EmbedIO;
using Sekiro40v.DeathCounter;

namespace Sekiro40v;

public partial class Form1 : Form
{
    private readonly App _app;

    public Form1(App app)
    {
        _app = app;

        InitializeComponent();

        #region MemoryHook

        processNameInput.Text = app.MemoryHook.ProcessName;
        maxReadsPerMinuteInput.Value = app.MemoryHook.Config.MaxRps;
        memoryOffsetInput.Value = app.MemoryHook.Config.Offset;

        statusInput.Text = app.MemoryHook.Status.ToString();
        pidInput.Text = app.MemoryHook.Process?.Id.ToString() ?? "";

        totalDamageInput.Value = app.StatisticsManager.Statistics.MemoryHook.TotalDamage;
        totalDeathsInput.Value = app.StatisticsManager.Statistics.MemoryHook.TotalDeaths;

        // Rest is empty while this constructor is running so it's not necessary

        // Event handlers below

        app.MemoryHook.StatusChanged += MemoryHook_StatusChanged;

        app.MemoryHook.CurrentHpChanged += MemoryHook_CurrentHPChanged;
        app.MemoryHook.MaxHpChanged += MemoryHook_MaxHPChanged;

        app.MemoryHook.DamageEventHandler += MemoryHook_DamageEventHandler;
        app.MemoryHook.DeathEventHandler += MemoryHook_DeathEventHandler;

        #endregion

        #region DeathCounter

        DeathCounterCounterInput.DataBindings.Add(new Binding("Text", _app.DeathCounter,
            nameof(_app.DeathCounter.CounterValue), false, DataSourceUpdateMode.OnPropertyChanged));
        // Using `Text` instead of `Value` because `Value` doesn't update on each keypress

        Binding RadioCheckedBinding<T>(object dataSource, string dataMember, T trueValue)
        {
            var binding = new Binding("Checked", dataSource, dataMember, true,
                DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += (s, args) => args.Value = args.Value != null && ((T)args.Value).Equals(trueValue);
            binding.Parse += (s, args) =>
            {
                if (args.Value != null && (bool)args.Value) args.Value = trueValue;
            };
            return binding;
        }

        DeathCounterAlignToLeftRadio.DataBindings.Add(RadioCheckedBinding(_app.DeathCounter,
            nameof(_app.DeathCounter.CounterAlign), CounterAlign.Left));
        DeathCounterAlignToRightRadio.DataBindings.Add(RadioCheckedBinding(_app.DeathCounter,
            nameof(_app.DeathCounter.CounterAlign), CounterAlign.Right));

        DeathCounterFontFamilyInput.DataBindings.Add(new Binding("Text", _app.DeathCounter,
            nameof(_app.DeathCounter.CounterFontFamily), false, DataSourceUpdateMode.OnPropertyChanged));

        void StyleColorButtonAndDialog()
        {
            var color = ColorTranslator.FromHtml(_app.DeathCounter.CounterColor);
            DeathCounterColorButton.BackColor = color;
            DeathCounterColorButton.ForeColor = color.GetBrightness() < 0.5 ? Color.White : Color.Black;
            deathCounterColorDialog.Color = color;
        }

        _app.DeathCounter.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName != nameof(_app.DeathCounter.CounterColor)) return;

            StyleColorButtonAndDialog();
        };

        Load += (o, args) => StyleColorButtonAndDialog();

        var deathCounterImageModeBinding = new Binding("SelectedIndex", _app.DeathCounter,
            nameof(_app.DeathCounter.CounterImageMode), false, DataSourceUpdateMode.OnPropertyChanged);
        deathCounterImageModeBinding.Format += (s, args) =>
        {
            if (args.Value != null) args.Value = (int)args.Value;
        };
        deathCounterImageModeBinding.Parse += (s, args) =>
        {
            if (args.Value != null) args.Value = (ImageMode)args.Value;
        };
        DeathCounterImageInput.DataBindings.Add(deathCounterImageModeBinding);

        DeathCounterImageOffsetXInput.DataBindings.Add(new Binding("Value", _app.DeathCounter,
            nameof(_app.DeathCounter.CounterImageOffsetX), false, DataSourceUpdateMode.OnPropertyChanged));

        DeathCounterImageOffsetYInput.DataBindings.Add(new Binding("Value", _app.DeathCounter,
            nameof(_app.DeathCounter.CounterImageOffsetY), false, DataSourceUpdateMode.OnPropertyChanged));

        DeathCounterImageSizeInput.DataBindings.Add(new Binding("Value", _app.DeathCounter,
            nameof(_app.DeathCounter.CounterImageSize), false, DataSourceUpdateMode.OnPropertyChanged));

        #endregion

        #region General

        GeneralStatusWebserverInput.Text = app.WebServerManager.GetWebServerState()?.ToString() ?? "error";

        webServerPortInput.Value = app.WebServerManager.Port;
        GeneralStatusMemoryHookInput.Text = app.MemoryHook.Status.ToString();

        app.WebServerManager.WebServerStateChangedEventHandler += WebServerManager_WebServerStateChangedEventHandler;

        generalShockOnDamageChcekbox.Checked = app.GeneralSettings.ShockOnDamage;

        generalShockOnDamageMode.SelectedIndex = (int)app.GeneralSettings.ShockOnDamageMode;

        generalShockOnDamageStrengthInput.Value = app.GeneralSettings.ShockOnDamageStrength;
        generalShockOnDamageDurationInput.Value = app.GeneralSettings.ShockOnDamageDuration;

        generalShockOnDeathCheckbox.Checked = app.GeneralSettings.ShockOnDeath;

        generalShockOnDeathStrength.Value = app.GeneralSettings.ShockOnDeathStrength;
        generalShockOnDeathDuration.Value = app.GeneralSettings.ShockOnDeathDuration;

        #endregion

        #region PainSender

        RefreshPortList();
        app.PainSender.StatusChanged += PainSender_StatusChanged;
        app.PainSender.StatisticsUpdated += PainSender_StatisticsUpdated;
        PainSender_StatusChanged(app.PainSender, EventArgs.Empty);
        PainSender_StatisticsUpdated(app.PainSender, EventArgs.Empty);

        #endregion
    }

    private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
    {
        Process.Start("explorer", "https://github.com/kubagp1/sekiro40v");
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        _app.Config.SaveSettings();
        _app.StatisticsManager.SaveStatistics();
    }

    #region General

    private void GeneralShockOnDamageCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        _app.GeneralSettings.ShockOnDamage = generalShockOnDamageChcekbox.Checked;
    }

    private void GeneralShockOnDamageMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        _app.GeneralSettings.ShockOnDamageMode = (ShockOnDamageMode)generalShockOnDamageMode.SelectedIndex;

        switch (_app.GeneralSettings.ShockOnDamageMode)
        {
            case ShockOnDamageMode.ScaleBoth:
                generalShockOnDamageStrenthLabel.Text = "Max. strength (0-100)";
                generalShockOnDamageDurationLabel.Text = "Max. duration (ms)";
                break;
            case ShockOnDamageMode.ScaleDuration:
                generalShockOnDamageStrenthLabel.Text = "Strength (0-100)";
                generalShockOnDamageDurationLabel.Text = "Max. duration (ms)";
                break;
            case ShockOnDamageMode.ScaleStrength:
                generalShockOnDamageStrenthLabel.Text = "Max. strength (0-100)";
                generalShockOnDamageDurationLabel.Text = "Duration (ms)";
                break;
            case ShockOnDamageMode.StaticBoth:
                generalShockOnDamageStrenthLabel.Text = "Strength (0-100)";
                generalShockOnDamageDurationLabel.Text = "Duration (ms)";
                break;
        }
    }

    private void GeneralShockOnDamageStrengthInput_ValueChanged(object sender, EventArgs e)
    {
        _app.GeneralSettings.ShockOnDamageStrength = (int)generalShockOnDamageStrengthInput.Value;
    }

    private void GeneralShockOnDamageDurationInput_ValueChanged(object sender, EventArgs e)
    {
        _app.GeneralSettings.ShockOnDamageDuration = (int)generalShockOnDamageDurationInput.Value;
    }

    private void GeneralShockOnDeathCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        _app.GeneralSettings.ShockOnDeath = generalShockOnDeathCheckbox.Checked;
    }

    private void GeneralShockOnDeathStrength_ValueChanged(object sender, EventArgs e)
    {
        _app.GeneralSettings.ShockOnDeathStrength = (int)generalShockOnDeathStrength.Value;
    }

    private void GeneralShockOnDeathDuration_ValueChanged(object sender, EventArgs e)
    {
        _app.GeneralSettings.ShockOnDeathDuration = (int)generalShockOnDeathDuration.Value;
    }

    private void GeneralRestoreDefaultSettingsButton_Click(object sender, EventArgs e)
    {
        var userSure = MessageBox.Show(
            "Are you sure you want to reset all settings?\nApplication will restart!",
            "Reset all settings",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question);

        if (userSure != DialogResult.Yes) return;

        _app.Config.RestoreDefaults();
        Application.Restart();
    }

    private void GeneralEraseStatisticsButton_Click(object sender, EventArgs e)
    {
        var userSure = MessageBox.Show(
            "Are you sure you want to erase all statistics?\nApplication will restart!",
            "Reset all settings",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question);

        if (userSure != DialogResult.Yes) return;

        _app.StatisticsManager.EraseStatistics();
        Application.Restart();
    }

    #endregion General

    #region WebServer Event Handler

    private void WebServerManager_WebServerStateChangedEventHandler(object sender, WebServerStateChangedEventArgs e)
    {
        Debug.WriteLine(e.NewState.ToString());
        Invoke(new Action<string>(state => { GeneralStatusWebserverInput.Text = state; }), e.NewState.ToString());
    }

    private void WebServerPortInput_ValueChanged(object sender, EventArgs e)
    {
        _app.WebServerManager.Port = (int)webServerPortInput.Value;
    }

    #endregion WebServer Event Handler

    #region DeathCounter Event Handlers

    private void DeathCounterIncrementButton_Click(object sender, EventArgs e)
    {
        _app.DeathCounter.CounterValue++;
    }

    private void DeathCounterDecrementButton_Click(object sender, EventArgs e)
    {
        _app.DeathCounter.CounterValue--;
    }

    private void DeathCounterColorButton_Click(object sender, EventArgs e)
    {
        if (deathCounterColorDialog.ShowDialog() != DialogResult.OK) return;
        var hexColor =
            "#" + (deathCounterColorDialog.Color.ToArgb() & 0x00FFFFFF).ToString("X6"); // from stackOverflow
        _app.DeathCounter.CounterColor = hexColor;
    }

    private void DeathCounterCopyUrlButton_Click(object sender, EventArgs e)
    {
        Clipboard.SetText($"http://127.0.0.1:{_app.WebServerManager.Port}/counter/counter.html");
    }

    private void DeathCounterRestoreDefaultsButton_Click(object sender, EventArgs e)
    {
        var userSure = MessageBox.Show(
            "Are you sure you want to restore default DeathCounter settings?",
            "Reset all DeathCounter settings",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question);

        if (userSure != DialogResult.Yes) return;

        _app.DeathCounter.RestoreDefaultSettings();
    }

    #endregion DeathCounter Event Handlers

    #region MemoryHook Event Handlers

    private void MemoryHook_DeathEventHandler(object sender, EventArgs e)
    {
        Invoke(() =>
        {
            _app.StatisticsManager.Statistics.MemoryHook.TotalDeaths++;
            totalDeathsInput.Value = _app.StatisticsManager.Statistics.MemoryHook.TotalDeaths;
        });
    }

    private void MemoryHook_DamageEventHandler(object sender, MemoryHook.DamageEventHandlerEventArgs e)
    {
        Invoke(() =>
        {
            _app.StatisticsManager.Statistics.MemoryHook.TotalDamage += e.Damage;
            totalDamageInput.Value = _app.StatisticsManager.Statistics.MemoryHook.TotalDamage;
        });
    }

    private void MemoryHook_StatusChanged(object sender, EventArgs e)
    {
        Invoke(() =>
            {
                statusInput.Text = _app.MemoryHook.Status.ToString();
                GeneralStatusMemoryHookInput.Text = _app.MemoryHook.Status.ToString();

                if (_app.MemoryHook.Status != MemoryHookStatus.Ready)
                {
                    pidInput.Text = "";
                    currentHPInput.Text = "";
                    maxHPInput.Value = 0;
                }
                else
                {
                    pidInput.Text = _app.MemoryHook.Process.Id.ToString();
                }
            }
        );
    }

    private void MemoryHook_MaxHPChanged(object sender, EventArgs e)
    {
        Invoke(() => { maxHPInput.Text = _app.MemoryHook.MaxHp.ToString(); });
    }

    private void MemoryHook_CurrentHPChanged(object sender, EventArgs e)
    {
        Invoke(() => { currentHPInput.Text = _app.MemoryHook.CurrentHp.ToString(); });
    }

    private void ProcessNameInput_TextChanged(object sender, EventArgs e)
    {
        _app.MemoryHook.ProcessName = Path.GetFileNameWithoutExtension(processNameInput.Text);
    }

    private void MaxHPInput_ValueChanged(object sender, EventArgs e)
    {
        _app.MemoryHook.MaxHp = (int)maxHPInput.Value;
    }

    private void MaxReadsPerMinuteInput_ValueChanged(object sender, EventArgs e)
    {
        _app.MemoryHook.Config.MaxRps = (int)maxReadsPerMinuteInput.Value;
    }

    private void MemoryOffsetInput_ValueChanged(object sender, EventArgs e)
    {
        _app.MemoryHook.Config.Offset = (int)memoryOffsetInput.Value;
    }

    private void ResetStatisticsButton_Click(object sender, EventArgs e)
    {
        var userSure = MessageBox.Show("Are you sure you want to reset all statistics of MemoryHook?", "Are you sure?",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        if (userSure != DialogResult.Yes) return;

        totalDamageInput.Value = 0;
        _app.StatisticsManager.Statistics.MemoryHook.TotalDamage = 0;
        totalDeathsInput.Value = 0;
        _app.StatisticsManager.Statistics.MemoryHook.TotalDeaths = 0;
    }

    private void RestoreDefaultMemoryHookSettings_Click(object sender, EventArgs e)
    {
        var userSure = MessageBox.Show(
            "Are you sure you want to restore default MemoryHook settings?\nApplication will restart!",
            "Reset all MemoryHook settings",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question);

        if (userSure != DialogResult.Yes) return;

        _app.Config.RestoreMemoryHookDefaults();
        Application.Restart();
    }

    private void TotalDeathsInput_ValueChanged(object sender, EventArgs e)
    {
        _app.StatisticsManager.Statistics.MemoryHook.TotalDeaths = (int)totalDeathsInput.Value;
    }

    private void TotalDamageInput_ValueChanged(object sender, EventArgs e)
    {
        _app.StatisticsManager.Statistics.MemoryHook.TotalDamage = (int)totalDamageInput.Value;
    }

    #endregion MemoryHook Event Handlers

    #region PainSender Event Handlers and related

    private void RefreshPortList()
    {
        var portList = PainSender.PortList.Prepend("None").ToArray();

        painSenderComboBox.Items.Clear();
        painSenderComboBox.Items.AddRange(portList);
        var v = painSenderComboBox.Items.IndexOf(_app.PainSender.PortName);
        painSenderComboBox.SelectedIndex = v != -1 ? v : 0;
    }

    private void PainSenderRefreshButton_Click(object sender, EventArgs e)
    {
        RefreshPortList();
    }

    private void PainSenderComboBox_SelectionChangeCommitted(object sender, EventArgs e)
    {
        if (painSenderComboBox.SelectedItem != null)
            _app.PainSender.PortName = painSenderComboBox.SelectedItem.ToString();
    }

    private void PainSenderComboBox_TextUpdate(object sender, EventArgs e)
    {
        _app.PainSender.PortName = painSenderComboBox.Text;
    }

    private void PainSender_StatusChanged(object sender, EventArgs e)
    {
        painSenderStatus.Text = _app.PainSender.Status.ToString();
        generalPainSenderStatus.Text = _app.PainSender.Status.ToString();
    }

    private void PainSenderPairButton_Click(object sender, EventArgs e)
    {
        _app.PainSender.Pair();
    }

    private void PainSenderResetStatistics_Click(object sender, EventArgs e)
    {
        var userSure = MessageBox.Show("Are you sure you want to reset all statistics of PainSender?", "Are you sure?",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        if (userSure != DialogResult.Yes) return;
        _app.StatisticsManager.Statistics.PainSender.Duration = 0;
        PainSender_StatisticsUpdated(_app.PainSender, EventArgs.Empty);
    }

    private void PainSenderManualShockButton_Click(object sender, EventArgs e)
    {
        var strength = (int)painSenderManualShockStrength.Value;
        var duration = (int)painSenderManualShockDuration.Value;

        _app.PainSender.SendShock(strength, duration);
    }

    private void PainSender_StatisticsUpdated(object sender, EventArgs e)
    {
        painSenderTotalDuration.Value = _app.PainSender.Statistics.Duration;
    }

    private void PainSenderTotalDuration_ValueChanged(object sender, EventArgs e)
    {
        _app.StatisticsManager.Statistics.PainSender.Duration = (int)painSenderTotalDuration.Value;
    }

    #endregion
}