using System;
using System.Windows.Forms;

namespace Sekiro40v;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        App app = new();

        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1(app));
    }
}