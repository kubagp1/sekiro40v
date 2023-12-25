using System.IO;
using Newtonsoft.Json;

namespace Sekiro40v;

public class StatisticsManager
{
    public string Path = @"statistics.json";
    public Statistics statistics;

    public StatisticsManager()
    {
        LoadStatistics();
    }

    public void LoadStatistics()
    {
        try
        {
            statistics = JsonConvert.DeserializeObject<Statistics>(File.ReadAllText(Path));

            if (statistics == null) EraseStatistics();
        }
        catch
        {
            EraseStatistics();
        }

        SaveStatistics();
    }

    public void EraseStatistics()
    {
        statistics = new Statistics
        {
            memoryHook = new MemoryHook
            {
                totalDeaths = 0,
                totalDamage = 0
            },
            deathCounter = new DeathCounter
            {
                deaths = 0
            },
            painSender = new PainSender
            {
                duration = 0
            }
        };

        SaveStatistics();
    }

    public void SaveStatistics()
    {
        File.WriteAllText(Path, JsonConvert.SerializeObject(statistics));
    }

    public class MemoryHook
    {
        public int totalDeaths { get; set; }
        public int totalDamage { get; set; }
    }

    public class DeathCounter
    {
        public int deaths { get; set; }
    }

    public class PainSender
    {
        public int duration { get; set; }
    }

    public class Statistics
    {
        public MemoryHook memoryHook { get; set; }
        public DeathCounter deathCounter { get; set; }
        public PainSender painSender { get; set; }
    }
}