using System.Threading;
using System.Threading.Tasks;
using EmbedIO;
using Sekiro40v.DeathCounter;

namespace Sekiro40v;

public class WebServerManager
{
    private readonly Config.General _config;

    private readonly DeathCounterWebSocketModule _deathCounterModule;
    private CancellationTokenSource _cts = new();

    private WebServer _webServer;

    private Task _webServerTask;

    public WebServerManager(Config.General config, DeathCounterWebSocketModule deathCounterModule)
    {
        _config = config;

        _deathCounterModule = deathCounterModule;

        StartWebServer();
    }

    public int Port
    {
        get => _config.WebServerPort;
        set
        {
            var changed = value != _config.WebServerPort;
            _config.WebServerPort = value;

            if (!changed || _webServerTask is null) return;

            // Maybe this is not the most elegant solution but it gets the job done
            _cts.Cancel();
            StartWebServer();
        }
    }

    public WebServerState? GetWebServerState()
    {
        return _webServer?.State;
    }

    private WebServer ConfigureWebServer()
    {
        return new WebServer(o => o
                .WithUrlPrefix($"http://127.0.0.1:{Port}/")
                .WithMode(HttpListenerMode.Microsoft))
            .WithModule(_deathCounterModule)
            .WithStaticFolder("/", "webserver_static", false);
    }

    public event WebServerStateChangedEventHandler WebServerStateChangedEventHandler;

    private void StartWebServer()
    {
        _webServer = ConfigureWebServer();

        _webServer.StateChanged += WebServer_StateChanged;

        _cts = new CancellationTokenSource();

        _webServerTask = _webServer.RunAsync(_cts.Token);
    }

    private void WebServer_StateChanged(object sender, WebServerStateChangedEventArgs e)
    {
        if (sender == _webServer) // Ignore state updates of old servers
            WebServerStateChangedEventHandler?.Invoke(sender, e);
    }
}