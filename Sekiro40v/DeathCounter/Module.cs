using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EmbedIO.WebSockets;
using Newtonsoft.Json;

namespace Sekiro40v.DeathCounter;

public class Module : BindableBase
{
    private readonly Config.DeathCounter _config;
    private readonly StatisticsManager.DeathCounter _statistics;
    public readonly DeathCounterWebSocketModule WebSocketModule;

    public Module(Config.DeathCounter config, StatisticsManager.DeathCounter statistics)
    {
        _config = config;
        _statistics = statistics;

        WebSocketModule = new DeathCounterWebSocketModule("/counter/socket", this);
    }

    public void RestoreDefaultSettings()
    {
        var defaults = Config.DeathCounterDefaults;

        CounterFontFamily = defaults.CounterFontFamily;
        CounterColor = defaults.CounterColor;
        CounterAlign = defaults.CounterAlign;
        CounterImageMode = defaults.CounterImageMode;
        CounterImageOffsetX = defaults.CounterImageOffsetX;
        CounterImageOffsetY = defaults.CounterImageOffsetY;
        CounterImageSize = defaults.CounterImageSize;
    }

    #region Getters Setters

    private void SetProperty<T>(Func<T> getter, Action<T> setter, T value, UpdateAction updateAction,
        [CallerMemberName] string propertyName = null)
    {
        if (Equals(getter(), value)) return;

        setter(value);
        OnPropertyChanged(propertyName);
        WebSocketModule.BroadcastUpdate(new Update
        (
            updateAction,
            value
        ));
    }

    public int CounterValue
    {
        get => _statistics.Deaths;
        set => SetProperty(() => _statistics.Deaths, v => _statistics.Deaths = v, value, UpdateAction.Value);
    }

    public string CounterFontFamily
    {
        get => _config.CounterFontFamily;
        set => SetProperty(() => _config.CounterFontFamily, v => _config.CounterFontFamily = v, value,
            UpdateAction.FontFamily);
    }

    public string CounterColor
    {
        get => _config.CounterColor;
        set => SetProperty(() => _config.CounterColor, v => _config.CounterColor = v, value, UpdateAction.Color);
    }

    public CounterAlign CounterAlign
    {
        get => _config.CounterAlign;
        set => SetProperty(() => _config.CounterAlign, v => _config.CounterAlign = v, value, UpdateAction.Align);
    }

    public ImageMode CounterImageMode
    {
        get => _config.CounterImageMode;
        set => SetProperty(() => _config.CounterImageMode, v => _config.CounterImageMode = v, value,
            UpdateAction.ImageMode);
    }

    public int CounterImageOffsetX
    {
        get => _config.CounterImageOffsetX;
        set => SetProperty(() => _config.CounterImageOffsetX, v => _config.CounterImageOffsetX = v, value,
            UpdateAction.ImageOffsetX);
    }

    public int CounterImageOffsetY
    {
        get => _config.CounterImageOffsetY;
        set => SetProperty(() => _config.CounterImageOffsetY, v => _config.CounterImageOffsetY = v, value,
            UpdateAction.ImageOffsetY);
    }

    public int CounterImageSize
    {
        get => _config.CounterImageSize;
        set => SetProperty(() => _config.CounterImageSize, v => _config.CounterImageSize = v, value,
            UpdateAction.ImageSize);
    }

    #endregion Getters Setters
}

public class DeathCounterWebSocketModule : WebSocketModule
{
    private readonly Module _deathCounter;

    public DeathCounterWebSocketModule(string urlPath, Module deathCounter) : base(urlPath, true)
    {
        _deathCounter = deathCounter;
    }

    protected override Task OnMessageReceivedAsync(IWebSocketContext context, byte[] buffer,
        IWebSocketReceiveResult result)
    {
        return Task.CompletedTask;
    }

    protected override Task OnClientConnectedAsync(IWebSocketContext context)
    {
        var updates = new List<(UpdateAction action, object property)>
        {
            (UpdateAction.Value, _deathCounter.CounterValue),
            (UpdateAction.Align, _deathCounter.CounterAlign),
            (UpdateAction.Color, _deathCounter.CounterColor),
            (UpdateAction.FontFamily, _deathCounter.CounterFontFamily),
            (UpdateAction.ImageMode, _deathCounter.CounterImageMode),
            (UpdateAction.ImageOffsetX, _deathCounter.CounterImageOffsetX),
            (UpdateAction.ImageOffsetY, _deathCounter.CounterImageOffsetY),
            (UpdateAction.ImageSize, _deathCounter.CounterImageSize)
        };

        foreach (var (action, property) in updates)
            SendAsync(context, JsonConvert.SerializeObject(new Update(action, property)));
        return base.OnClientConnectedAsync(context);
    }

    public void BroadcastUpdate(Update update)
    {
        BroadcastAsync(JsonConvert.SerializeObject(update));
    }
}

public record Update
(
    UpdateAction Action,
    object Value
);

public enum ImageMode
{
    Hide,
    Left,
    Right
}

public enum CounterAlign
{
    Left,
    Right
}

public enum UpdateAction
{
    Value,
    FontFamily,
    Color,
    Align,
    ImageMode,
    ImageOffsetX,
    ImageOffsetY,
    ImageSize
}