using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kpo4162_Ivanov
{
    public partial class FrmMain : Form
    {
        private List<Kpo4162.Ivanov.Lib.SETI> setiList = new List<Kpo4162.Ivanov.Lib.SETI>();//null;
        private BindingSource bsSeties = new BindingSource();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                //Вызов исключения "Метод не реализован"
                //throw new NotImplementedException();
                //Вызов базового исключения
                //throw new Exception("Неправильные входные параметры");
                Kpo4162.Ivanov.Lib.MockSETIListCommand loader = new Kpo4162.Ivanov.Lib.MockSETIListCommand();
                loader.Execute();
                //dgvSETIes.DataSource = loader.SETIList;
                setiList = loader.SETIList;
                bsSeties.DataSource = setiList;
                dgvSETIes.DataSource = bsSeties;
            }
            //обработка исключения "Метод не реализован"
            catch (NotImplementedException ex)
            {
                //Kpo4162.Ivanov.Lib.LogUtility.ErrorLog("Ошибка №1: " + ex.Message);
                //Kpo4162.Ivanov.Lib.LogUtility.ErrorLog(ex);
                MessageBox.Show("Ошибка №1: " + ex.Message);
            }
            //обработка остальных исключений
            catch (Exception ex)
            {
                //Kpo4162.Ivanov.Lib.LogUtility.ErrorLog("Ошибка №2: " + ex.Message);
                //Kpo4162.Ivanov.Lib.LogUtility.ErrorLog(ex);
                MessageBox.Show("Ошибка №2: " + ex.Message);
            }
        }

        private void mmOpenProject_Click(object sender, EventArgs e)
        {
            /*Kpo4162.Ivanov.Lib.FrmProject frmProject = new Kpo4162.Ivanov.Lib.FrmProject();
            frmProject.ShowDialog();*/
            //Создать экземпляр формы
            Kpo4162.Ivanov.Lib.FrmProject frmProject = new Kpo4162.Ivanov.Lib.FrmProject();
            //Задать сылка на текущий объект в таблицы
            Kpo4162.Ivanov.Lib.SETI project = new Kpo4162.Ivanov.Lib.SETI();// (bsSeties.Current as Kpo4162.Ivanov.Lib.SETI);
            frmProject.SetProject(project);
            //открыть форму в модальном режиме
            frmProject.ShowDialog(); 
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Kpo4162.Ivanov.Lib.LogUtility.ErrorLog(ex);
            }
        }

        private void mmFile_Click(object sender, EventArgs e)
        {

        }
    }
}
