using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.Config
{
    public class Configuration
    {
        public static string UsersFileName => ConfigurationManager.AppSettings.Get("UsersFileName");

        public static string AwardsFileName => ConfigurationManager.AppSettings.Get("AwardsFileName");

        public static string UsersAwardsFileName => ConfigurationManager.AppSettings.Get("UsersAwardsFileName");
    }
}
