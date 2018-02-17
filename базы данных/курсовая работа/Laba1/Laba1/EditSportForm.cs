using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1
{
    public partial class EditSportForm : Form
    {
        public EditSportForm()
        {
            InitializeComponent();
        }
        String stype = null; SqlConnection conn;
        public EditSportForm(Form2 f,SqlConnection c,string str)
        {
            InitializeComponent();
            stype = str;
            conn = c;
           // f.BackColor = Color.Yellow;
        }

        private async void EditSportForm_Load(object sender, EventArgs e)
        {
            textBox_Edit_stype.Clear();
            textBox_Edit_wrdata.Clear();
            textBox_Edit_wrecord.Clear();
            textBox_Edit_edizm.Clear();

            SqlDataReader sqlReader = null;
            SqlCommand sqlcommand = new SqlCommand("SELECT * FROM [sport] WHERE stype=@STYPE", conn);
            sqlcommand.Parameters.AddWithValue("STYPE", stype);
           

            try
            {
                
                sqlReader = await sqlcommand.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    textBox_Edit_stype.Text=Convert.ToString(sqlReader["stype"]);
                    textBox_Edit_edizm.Text = Convert.ToString(sqlReader["edizm"]);
                    textBox_Edit_wrecord.Text = Convert.ToString(sqlReader["wrecord"]);
                    textBox_Edit_wrdata.Text = Convert.ToString(sqlReader["wrdata"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (sqlReader != null) sqlReader.Close();
            }
        }

        private void textBox_Edit_stype_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button_Save_sport_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcommand = new SqlCommand("UPDATE [sport] SET edizm=@EDIZM,wrecord=@WRECORD,wrdata=@WRDATA WHERE stype=@STYPE", conn);
            sqlcommand.Parameters.AddWithValue("STYPE", textBox_Edit_stype.Text);
            sqlcommand.Parameters.AddWithValue("EDIZM", textBox_Edit_edizm.Text);
            sqlcommand.Parameters.AddWithValue("WRECORD", textBox_Edit_wrecord.Text);
            sqlcommand.Parameters.AddWithValue("WRDATA", textBox_Edit_wrdata.Text);
            sqlcommand.ExecuteNonQueryAsync();
            this.Close();
        }
    }
}
