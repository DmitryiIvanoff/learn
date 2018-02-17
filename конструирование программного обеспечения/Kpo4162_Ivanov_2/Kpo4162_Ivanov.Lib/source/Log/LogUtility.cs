using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kpo4162.Ivanov.Lib
{
    public static class LogUtility
    {
        public static void ErrorLog(string message)
        {
            message = DateTime.Now + message+"\r\n";
            File.AppendAllText("error.log", message);
        }
        public static void ErrorLog(Exception ex)
        {
            string message = DateTime.Now +" "+ ex.Message + "\r\n";
            File.AppendAllText("error.log", message);
        } 
    }
}
