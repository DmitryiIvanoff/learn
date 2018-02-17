using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public enum LoadStatus
{
    None = 0,
    Success = 1,
    FileNameIsEmpty = -1,
    FileNotExists = -2,
    GeneralError = -100
} 

namespace Kpo4162.Ivanov.Lib
{
    public class ProjectListtSplitFileLoader : IProjectListLoader
    {
        private List<SETI> _SETIlist = null;
        private readonly string _fileName = "";
        private LoadStatus _status = LoadStatus.None;
        public ProjectListtSplitFileLoader(string fName)
        {
            this._fileName = fName;
            this._SETIlist=new List<SETI>();
        }

        public List<SETI> SETIlist
        {
            get
            {
                return _SETIlist;
            }
        }
        public LoadStatus status
        {
            get
            {
                return _status;
            }
        }
        public void Execute()
        {
            try
            {
                if (_fileName.Length == 0)
                {
                    throw new Exception("Имя файла пустое");
                }
                if (!File.Exists(_fileName))
                {
                    throw new Exception("Файл не существует");
                }

                StreamReader sr = null;
                using (sr = new StreamReader(_fileName, Encoding.GetEncoding(1251)))
                {
                    while (!sr.EndOfStream)
                    {
                        //Прочитать очередную строку             
                        string str = sr.ReadLine();
                        string[] arr = str.Split('|');
                        SETI temp = new SETI();
                        try
                        {
                            temp.Year = Int32.Parse(arr[0]);
                            temp.Name = arr[1];
                            temp.Diametr = Int32.Parse(arr[2]);
                            temp.Chastota = Int32.Parse(arr[3]);
                            this._SETIlist.Add(temp);
                        }
                        catch (Exception ex)
                        {
                            _status = LoadStatus.GeneralError;
                            Kpo4162.Ivanov.Lib.LogUtility.ErrorLog(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Kpo4162.Ivanov.Lib.LogUtility.ErrorLog( ex);
            }
        }
    }
}
