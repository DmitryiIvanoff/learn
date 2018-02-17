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
    public partial class EditCompetitionForm : Form
    {
        String str = null; SqlConnection conn;
        public EditCompetitionForm(Form2 f, SqlConnection c, string s)
        {
            InitializeComponent();
            str = s;
            conn = c;
        }

        private async void EditCompetitionForm_Load(object sender, EventArgs e)
        {
            dateTimePicker_Edit_competition_dbegin.CustomFormat = "MM/dd/yyyy";
            dateTimePicker_Edit_competition_dbegin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Edit_competition_dend.CustomFormat = "MM/dd/yyyy";
            dateTimePicker_Edit_competition_dend.Format = DateTimePickerFormat.Custom;

            textBox_Edit_competition_sname.Clear();
            textBox_Edit_competition_place.Clear();
            

            SqlDataReader sqlReader = null;
            SqlCommand sqlcommand = new SqlCommand("SELECT * FROM [competition] WHERE sname=@SNAME", conn);
            sqlcommand.Parameters.AddWithValue("SNAME", str);


            try
            {

                sqlReader = await sqlcommand.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    textBox_Edit_competition_sname.Text = Convert.ToString(sqlReader["sname"]);
                    textBox_Edit_competition_place.Text = Convert.ToString(sqlReader["place"]);

                    dateTimePicker_Edit_competition_dbegin.Value = Convert.ToDateTime(sqlReader["dbegin"]);
                    dateTimePicker_Edit_competition_dend.Value = Convert.ToDateTime(sqlReader["dend"]);
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

        private async void button_competition_Edit_Save_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcommand = new SqlCommand("UPDATE [competition] SET place=@PLACE,dbegin=(convert(datetime,@DBEGIN,101)),dend=(convert(datetime,@DEND,101)) WHERE sname=@SNAME", conn);
            sqlcommand.Parameters.AddWithValue("SNAME", textBox_Edit_competition_sname.Text);
            sqlcommand.Parameters.AddWithValue("PLACE", textBox_Edit_competition_place.Text);
            sqlcommand.Parameters.AddWithValue("DBEGIN", dateTimePicker_Edit_competition_dbegin.Text);
            sqlcommand.Parameters.AddWithValue("DEND", dateTimePicker_Edit_competition_dend.Text);
            sqlcommand.ExecuteNonQueryAsync();
            this.Close();
        }
    }
}
