using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpo4162.Ivanov.Lib
{
    public class MockProjectSaverInFile : IProjectSave
    {
        private SaveStatus _Status = SaveStatus.None;
        public SaveStatus GetStatus()
        {
            return _Status;
        }

        public void Save(List<SETI> dataItems)
        {
            // ничего не делаем, метод-заглушка
            _Status = SaveStatus.Successful;
        }
    }
}
