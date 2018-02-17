using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpo4162.Ivanov.Lib
{
    public interface IProjectListLoader
    {
        List<SETI> SETIlist{get;}

        LoadStatus status{get;}
        void Execute();
    }
}
