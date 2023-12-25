using System.Threading;
using System.Threading.Tasks;
using EmbedIO;

namespace Sekiro40v;

public class WebServerManager
{
    public Config.General Config;

    private readonly DeathCounter.CounterWebSocketModule counterModule;
    private CancellationTokenSource cts = new();

    private IWebServer webServer;

    private Task webServerTask;

    public WebServerManager(Config.General config, DeathCounter.CounterWebSocketModule counterModule)
    {
        Config = config;

        this.counterModule = counterModule;

        StartWebServer();
    }

    public int Port
    {
        get => Config.webServerPort;
        set
        {
            var changed = value != Config.webServerPort;
            Config.webServerPort = value;
            if (changed && webServerTask is not null)
            {
                // Maybe this is not the most elegant solution but it gets the job done
                cts.Cancel();
                StartWebServer();
            }
        }
    }

    public WebServerState? GetWebServerState()
    {
        return webServer?.State;
    }

    private WebServer ConfigureWebServer()
    {
        return new WebServer(o => o
                .WithUrlPrefix($"http://127.0.0.1:{Port}/")
                .WithMode(HttpListenerMode.Microsoft))
            .WithModule(counterModule)
            .WithStaticFolder("/", "webserver_static", false);
    }

    public event WebServerStateChangedEventHandler WebServerStateChangedEventHandler;

    private void StartWebServer()
    {
        webServer = ConfigureWebServer();

        webServer.StateChanged += WebServer_StateChanged;

        cts = new CancellationTokenSource();

        webServerTask = webServer.RunAsync(cts.Token);
    }

    private void WebServer_StateChanged(object sender, WebServerStateChangedEventArgs e)
    {
        if (sender == webServer) // Ignore state updates of old servers
            WebServerStateChangedEventHandler?.Invoke(sender, e);
    }
}