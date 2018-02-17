using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpo4162.Ivanov.Lib
{
    public enum LoadStatus
    {
        None = 0,
        Success = 1,
        FileNameIsEmpty = -1,
        FileDoesNotExist = -2,
        GeneralError = -100
    }
    public interface IProjectLoad
    {
        LoadStatus status{get;}
        List<SETI> SETIlist{get;}
        void Execute();
    }
}
