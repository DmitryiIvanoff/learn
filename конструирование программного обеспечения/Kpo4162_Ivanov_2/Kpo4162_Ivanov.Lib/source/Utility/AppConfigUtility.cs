using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Kpo4162.Utility
{
    public class AppConfigUtility
    {
        public string AppSettings(string name)
        {
            if (ConfigurationManager.AppSettings[name] == null)
            {
                return "";
            }
            else
            {
                return ConfigurationManager.AppSettings[name];
            }
        }
    }
}
