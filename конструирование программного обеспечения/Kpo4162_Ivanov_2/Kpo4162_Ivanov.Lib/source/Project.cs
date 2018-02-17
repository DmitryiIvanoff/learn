using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kpo4162.Ivanov.Lib
{
    public partial class FrmProject : Form
    {
        public FrmProject()
        {
            InitializeComponent();
            _project = new SETI();//null;
            
        }

        private SETI _project = null;
        public SETI project
        {
            get { return _project; }
        }
        public void SetProject(SETI project)
        {
            //инициализировать скрытое поля класса
            this._project = project;
            //присвоить значение данных проекта элементам редактирования
            this.txtboxYear.Text = "" + _project.Year;
            this.txtboxName.Text = _project.Name;
            this.txtboxDiametr.Text =""+ _project.Diametr;
            this.txtboxChastota.Text =""+ _project.Chastota;
            this.txtboxPrimechanie.Text = _project.Primechanie;
        } 

        private void FrmProject_Load(object sender, EventArgs e)
        {

        }
    }
}
