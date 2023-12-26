using System.IO;
using Newtonsoft.Json;

namespace Sekiro40v;

public class StatisticsManager
{
    private const string Path = @"statistics.json";
    public StatisticsSchema Statistics;

    public StatisticsManager()
    {
        LoadStatistics();
    }

    private void LoadStatistics()
    {
        try
        {
            Statistics = JsonConvert.DeserializeObject<StatisticsSchema>(File.ReadAllText(Path));

            if (Statistics == null) EraseStatistics();
        }
        catch
        {
            EraseStatistics();
        }

        SaveStatistics();
    }

    public void EraseStatistics()
    {
        Statistics = new StatisticsSchema
        {
            MemoryHook = new MemoryHook
            {
                TotalDeaths = 0,
                TotalDamage = 0
            },
            DeathCounter = new DeathCounter
            {
                Deaths = 0
            },
            PainSender = new PainSender
            {
                Duration = 0
            }
        };

        SaveStatistics();
    }

    public void SaveStatistics()
    {
        File.WriteAllText(Path, JsonConvert.SerializeObject(Statistics));
    }

    public class MemoryHook
    {
        public int TotalDeaths { get; set; }
        public int TotalDamage { get; set; }
    }

    public class DeathCounter
    {
        public int Deaths { get; set; }
    }

    public class PainSender
    {
        public int Duration { get; set; }
    }

    public class StatisticsSchema
    {
        public MemoryHook MemoryHook { get; set; }
        public DeathCounter DeathCounter { get; set; }
        public PainSender PainSender { get; set; }
    }
}