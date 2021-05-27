using System.Diagnostics;

namespace IridiumEditor
{
    public static class Helpers
    {
        public static void LaunchBrowser(string url)
        {
            Process.Start( new ProcessStartInfo { FileName = url, UseShellExecute = true } );
        }
    }
}
