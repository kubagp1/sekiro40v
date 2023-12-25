using System;
using System.Diagnostics;
using System.IO.Ports;

namespace Sekiro40v;

public enum PainSenderStatus
{
    Starting,
    Running,
    Error
}

public class PainSender
{
    private readonly Config.PainSender Config;

    private SerialPort serialPort;
    public StatisticsManager.PainSender Statistics;

    private PainSenderStatus status;

    public PainSender(Config.PainSender config, StatisticsManager.PainSender statistics)
    {
        Config = config;
        Statistics = statistics;

        Status = PainSenderStatus.Starting;
        RestartSerialConnection();
    }

    public string[] PortList => SerialPort.GetPortNames();

    public string PortName
    {
        set
        {
            Config.port = value;
            RestartSerialConnection();
        }
        get => Config.port;
    }

    public PainSenderStatus Status
    {
        get => status;
        set
        {
            if (value != Status)
            {
                status = value;
                StatusChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public event EventHandler StatusChanged;

    public event EventHandler StatisticsUpdated;

    public void RestartSerialConnection()
    {
        try
        {
            if (serialPort != null) serialPort.Close();

            serialPort = new SerialPort(PortName, 115200);
            serialPort.RtsEnable = true;
            serialPort.DtrEnable = true;
            serialPort.Open();

            Status = PainSenderStatus.Running;
        }
        catch
        {
            Status = PainSenderStatus.Error;
            serialPort = null;
            Config.port = "None"; // Changing via public property PortName would cause feedback loop
        }
    }

    private string GenerateCommand(int strength, int duration)
    {
        return $"1 {strength} {duration}\n";
        ;
    }

    public void SendShock(int strength, int duration)
    {
        Debug.WriteLine($"Strength: {strength}, duration: {duration}");

        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Write(GenerateCommand(strength, duration));
            if (strength > 0)
            {
                Statistics.duration += duration;
                StatisticsUpdated?.Invoke(this, EventArgs.Empty);
            }
        }
        else
        {
            RestartSerialConnection();
        }
    }

    public void Pair()
    {
        SendShock(0, 1000);
    }
}