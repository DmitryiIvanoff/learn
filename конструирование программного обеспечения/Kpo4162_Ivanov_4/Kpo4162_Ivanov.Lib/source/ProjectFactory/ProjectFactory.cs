using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpo4162.Ivanov.Lib
{
    public class ProjectFactory : IProjectFactory
    {
        public IProjectLoad GetProjectLoad()
        {
            return new ProjectListtSplitFileLoader();
        }

        public IProjectSave GetProjectSave()
        {
            return new ProjectSaverInFile();
        }
    }
}
