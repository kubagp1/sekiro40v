using Newtonsoft.Json;
using System.IO;

namespace Sekiro40v
{
    public class Config
    {
        public class General
        {
            public int webServerPort { get; set; }

            public bool shockOnDamage { get; set; }
            public ShockOnDamageMode shockOnDamageMode { get; set;}
            public int shockOnDamageStrength { get; set;}
            public int shockOnDamageDuration { get; set;}

            public bool shockOnDeath { get; set;}
            public int shockOnDeathStrength { get; set; }
            public int shockOnDeathDuration { get; set; }

        }

        public class MemoryHook
        {
            public string processName { get; set; }
            public int maxRPM { get; set; }
            public int offset { get; set; }
        }

        public class DeathCounter
        {
            public Sekiro40v.DeathCounter.CounterAlign counterAlign { get; set; }
            public string counterColor { get; set; }
            public string counterFontFamily { get; set; }
            public int counterImageOffsetX { get; set; }
            public int counterImageOffsetY { get; set; }
            public int counterImageSize { get; set; }
            public Sekiro40v.DeathCounter.ImageMode counterImageMode { get; set; }
        }
        
        public class PainSender
        {
            public string port { get; set; }
        }

        public class Settings
        {
            public General general { get; set; }
            public MemoryHook memoryHook { get; set; }
            public DeathCounter deathCounter { get; set; }
            public PainSender painSender { get; set; }
        }

        public string Path = @"settings.json";
        public Settings settings;

        public Config()
        {
            LoadSettings();
        }

        public void RestoreDefaults()
        {
            settings = new Settings()
            {
                general = new General()
                {
                    webServerPort = 2137,
                    shockOnDamage = true,
                    shockOnDamageMode = ShockOnDamageMode.ScaleDuration,
                    shockOnDamageDuration = 3000,
                    shockOnDamageStrength = 10,
                    shockOnDeath = true,
                    shockOnDeathDuration = 300,
                    shockOnDeathStrength = 100
                },
                memoryHook = new MemoryHook()
                {
                    processName = "sekiro",
                    maxRPM = 60,
                    offset = 62362212
                },
                deathCounter = new DeathCounter()
                {
                    counterAlign = Sekiro40v.DeathCounter.CounterAlign.Right,
                    counterColor = "#CB0000",
                    counterFontFamily = "Architects Daughter",
                    counterImageOffsetX = 8,
                    counterImageOffsetY = 3,
                    counterImageSize = 59,
                    counterImageMode = Sekiro40v.DeathCounter.ImageMode.Right
                },
                painSender = new PainSender()
                {
                    port = "COM4"
                }
            };

            SaveSettings();
        }

        public void SaveSettings()
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(settings));
        }

        public void LoadSettings()
        {
            try
            {
                var deserializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Error
                };
                settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(Path));

                if (settings == null) RestoreDefaults();
            }
            catch
            {
                RestoreDefaults();
            }
            
            SaveSettings();
        }
    }
}
