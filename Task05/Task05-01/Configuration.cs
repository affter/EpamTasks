using System.Configuration;

namespace Task05_01
{
    internal static class Configuration
    {
        public static string WorkingDirectory => ConfigurationManager.AppSettings.Get("workingDirectory");
    }
}