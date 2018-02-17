using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kpo4162.Ivanov.Lib
{
    public class ProjectTestListSplitFileLoader : IProjectListLoader
    {
        private List<SETI> _SETIlist = null;
        private LoadStatus _status = LoadStatus.None;
        public ProjectTestListSplitFileLoader()
        {
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
            //Kpo4162.Ivanov.Lib.LoadProjectListCommand Seti = new Kpo4162.Ivanov.Lib.LoadProjectListCommand(Kpo4162.Ivanov.Lib.AppGlobalSettings.dataFileName);
            IProjectLoad Seti = new ProjectListtSplitFileLoader();
            Seti.Execute();
            _SETIlist = Seti.SETIlist;
        }
    }
}
