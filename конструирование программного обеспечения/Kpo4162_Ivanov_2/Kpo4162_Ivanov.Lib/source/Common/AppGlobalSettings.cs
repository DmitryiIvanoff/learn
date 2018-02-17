using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpo4162.Ivanov.Lib
{
    public static class AppGlobalSettings
    {
        private static Kpo4162.Utility.AppConfigUtility conf = new Kpo4162.Utility.AppConfigUtility();
        private static string _logPath { get; set; }
        private static string _dataFileName { get; set; }
        public static string logPath
        {
            get
            {
                return _logPath;
            }
        }
        public static string dataFileName
        {
            get
            {
                return _dataFileName;
            }
        }
        public static void Initialize()
        {
            _logPath = conf.AppSettings("logPath");
            _dataFileName = conf.AppSettings("dataFileName");
        }

    }
}
