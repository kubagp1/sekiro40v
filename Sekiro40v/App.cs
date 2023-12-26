using System;
using Sekiro40v.DeathCounter;

namespace Sekiro40v;

public enum ShockOnDamageMode
{
    ScaleStrength,
    ScaleDuration,
    ScaleBoth,
    StaticBoth
}

public class App
{
    public readonly Config Config;
    public readonly Module DeathCounter;

    public readonly Config.General GeneralSettings;
    public readonly MemoryHook MemoryHook;
    public readonly PainSender PainSender;
    public readonly StatisticsManager StatisticsManager;
    public readonly WebServerManager WebServerManager;

    public App()
    {
        Config = new Config();
        StatisticsManager = new StatisticsManager();

        GeneralSettings = Config.Settings.General;

        MemoryHook = new MemoryHook(Config.Settings.MemoryHook);
        DeathCounter = new Module(Config.Settings.DeathCounter, StatisticsManager.Statistics.DeathCounter);
        WebServerManager = new WebServerManager(Config.Settings.General, DeathCounter.WebSocketModule);
        PainSender = new PainSender(Config.Settings.PainSender, StatisticsManager.Statistics.PainSender);

        MemoryHook.DeathEventHandler += MemoryHook_DeathEventHandler;
        MemoryHook.DamageEventHandler += MemoryHook_DamageEventHandler;
    }

    private void MemoryHook_DamageEventHandler(object sender, MemoryHook.DamageEventHandlerEventArgs e)
    {
        if (!GeneralSettings.ShockOnDamage) return;

        var percentage = (double)e.Damage / e.MaxHp;
        switch (GeneralSettings.ShockOnDamageMode)
        {
            case ShockOnDamageMode.ScaleBoth:
                PainSender.SendShock(
                    (int)(GeneralSettings.ShockOnDamageStrength * percentage),
                    (int)(GeneralSettings.ShockOnDamageDuration * percentage)
                );
                break;
            case ShockOnDamageMode.ScaleDuration:
                PainSender.SendShock(
                    GeneralSettings.ShockOnDamageStrength,
                    (int)(GeneralSettings.ShockOnDamageDuration * percentage)
                );
                break;
            case ShockOnDamageMode.ScaleStrength:
                PainSender.SendShock(
                    (int)(GeneralSettings.ShockOnDamageStrength * percentage),
                    GeneralSettings.ShockOnDamageDuration
                );
                break;
            case ShockOnDamageMode.StaticBoth:
                PainSender.SendShock(
                    GeneralSettings.ShockOnDamageStrength,
                    GeneralSettings.ShockOnDamageDuration
                );
                break;
        }
    }

    private void MemoryHook_DeathEventHandler(object sender, EventArgs e)
    {
        DeathCounter.CounterValue++;

        if (GeneralSettings.ShockOnDeath)
            PainSender.SendShock(GeneralSettings.ShockOnDeathStrength, GeneralSettings.ShockOnDeathDuration);
    }
}