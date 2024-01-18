using System;
using System.Collections.Generic;
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
    private readonly Config.PainSender _config;

    private SerialPort _serialPort;

    private PainSenderStatus _status;
    public StatisticsManager.PainSender Statistics;

    public PainSender(Config.PainSender config, StatisticsManager.PainSender statistics)
    {
        _config = config;
        Statistics = statistics;

        Status = PainSenderStatus.Starting;
        RestartSerialConnection();
    }

    public static IEnumerable<string> PortList => SerialPort.GetPortNames();

    public string PortName
    {
        set
        {
            _config.Port = value;
            RestartSerialConnection();
        }
        get => _config.Port;
    }

    public PainSenderStatus Status
    {
        get => _status;
        set
        {
            if (value == Status) return;
            _status = value;
            StatusChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler StatusChanged;

    public event EventHandler StatisticsUpdated;

    public void RestartSerialConnection()
    {
        try
        {
            if (_serialPort != null) _serialPort.Close();

            _serialPort = new SerialPort(PortName, 115200);
            _serialPort.RtsEnable = true;
            _serialPort.DtrEnable = true;
            _serialPort.Open();

            Status = PainSenderStatus.Running;
        }
        catch
        {
            Status = PainSenderStatus.Error;
            _serialPort = null;
            _config.Port = "None"; // Changing via public property PortName would cause feedback loop
        }
    }

    private static string GenerateCommand(int strength, int duration)
    {
        return $"1 {strength} {duration}\n";
        ;
    }

    public void SendShock(int strength, int duration)
    {
        Debug.WriteLine($"Strength: {strength}, duration: {duration}");

        if (_serialPort != null && _serialPort.IsOpen)
        {
            _serialPort.Write(GenerateCommand(strength, duration));
            if (strength <= 0) return;
            Statistics.Duration += duration;
            StatisticsUpdated?.Invoke(this, EventArgs.Empty);
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