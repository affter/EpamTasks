using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05_01
{
    internal static class Configuration
    {
        public static string WorkingDirectory => ConfigurationManager.AppSettings.Get("workingDirectory");
    }
}
