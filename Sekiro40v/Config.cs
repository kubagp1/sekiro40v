﻿using System.IO;
using Newtonsoft.Json;
using Sekiro40v.DeathCounter;

namespace Sekiro40v;

public class Config
{
    private const string Path = @"settings.json";

    public static readonly DeathCounter DeathCounterDefaults = new()
    {
        CounterAlign = CounterAlign.Right,
        CounterColor = "#CB0000",
        CounterFontFamily = "Architects Daughter",
        CounterImageOffsetX = 8,
        CounterImageOffsetY = 3,
        CounterImageSize = 59,
        CounterImageMode = ImageMode.Right
    };

    private readonly MemoryHook _memoryHookDefaults = new()
    {
        ProcessName = "sekiro",
        MaxRps = 60,
        Offset = 62362212
    };

    public SettingsSchema Settings;

    public Config()
    {
        LoadSettings();
    }

    public void RestoreDefaults()
    {
        Settings = new SettingsSchema
        {
            General = new General
            {
                WebServerPort = 2137,
                ShockOnDamage = true,
                ShockOnDamageMode = ShockOnDamageMode.ScaleDuration,
                ShockOnDamageDuration = 3000,
                ShockOnDamageStrength = 10,
                ShockOnDeath = true,
                ShockOnDeathDuration = 300,
                ShockOnDeathStrength = 100
            },
            MemoryHook = _memoryHookDefaults,
            DeathCounter = DeathCounterDefaults,
            PainSender = new PainSender
            {
                Port = "COM4"
            }
        };

        SaveSettings();
    }

    public void RestoreMemoryHookDefaults()
    {
        Settings.MemoryHook = _memoryHookDefaults;

        SaveSettings();
    }

    public void SaveSettings()
    {
        File.WriteAllText(Path, JsonConvert.SerializeObject(Settings));
    }

    private void LoadSettings()
    {
        try
        {
            var deserializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Error
            };
            Settings = JsonConvert.DeserializeObject<SettingsSchema>(File.ReadAllText(Path));

            if (Settings == null) RestoreDefaults();
        }
        catch
        {
            RestoreDefaults();
        }

        SaveSettings();
    }

    public class General
    {
        public int WebServerPort { get; set; }

        public bool ShockOnDamage { get; set; }
        public ShockOnDamageMode ShockOnDamageMode { get; set; }
        public int ShockOnDamageStrength { get; set; }
        public int ShockOnDamageDuration { get; set; }

        public bool ShockOnDeath { get; set; }
        public int ShockOnDeathStrength { get; set; }
        public int ShockOnDeathDuration { get; set; }
    }

    public class MemoryHook
    {
        public string ProcessName { get; set; }
        public int MaxRps { get; set; }
        public int Offset { get; set; }
    }

    public class DeathCounter
    {
        public CounterAlign CounterAlign { get; set; }
        public string CounterColor { get; set; }
        public string CounterFontFamily { get; set; }
        public int CounterImageOffsetX { get; set; }
        public int CounterImageOffsetY { get; set; }
        public int CounterImageSize { get; set; }
        public ImageMode CounterImageMode { get; set; }
    }

    public class PainSender
    {
        public string Port { get; set; }
    }

    public class SettingsSchema
    {
        public General General { get; set; }
        public MemoryHook MemoryHook { get; set; }
        public DeathCounter DeathCounter { get; set; }
        public PainSender PainSender { get; set; }
    }
}