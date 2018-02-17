using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpo4162.Ivanov.Lib
{
    public enum SaveStatus
    {
        None = 0,
        Successful = 1,
        FileNameIsEmpty = -1,
        FileDoesNotExist = -2,
        GenericError = -100
    }
    public interface IProjectSave
    {
        SaveStatus GetStatus();
        void Save(List<SETI> dataList);
    }
}
