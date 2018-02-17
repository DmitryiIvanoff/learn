using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kpo4162.Ivanov.Lib
{
    public class ProjectSaverInFile : IProjectSave
    {
        private SaveStatus _Status = SaveStatus.None;
        public SaveStatus GetStatus()
        {
            return _Status;
        }

        public void Save(List<SETI> dataItems)
        {
            if (string.IsNullOrWhiteSpace(AppGlobalSettings.dataFileName))
            {
                _Status = SaveStatus.FileNameIsEmpty;
                throw new Exception("Не указано имя файла в файле конфигурации!");
            }

            if (!File.Exists(AppGlobalSettings.dataFileName))
            {
                _Status = SaveStatus.FileDoesNotExist;
                throw new FileNotFoundException(AppGlobalSettings.dataFileName);
            }

            using (var writer = File.CreateText(AppGlobalSettings.dataFileName))
            {
                foreach (SETI item in dataItems)
                {
                    try
                    {
                        writer.WriteLine(string.Format("{0}|{1}|{2}|{3}", item.Year, item.Name, item.Diametr, item.Chastota));
                    }
                    catch (Exception ex)
                    {
                        _Status = SaveStatus.GenericError;
                        LogUtility.ErrorLog(ex);
                    }
                }
            }

            if (_Status == SaveStatus.None)
            {
                _Status = SaveStatus.Successful;
            }
        }
    }
}
