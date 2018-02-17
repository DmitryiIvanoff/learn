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
    public partial class EditAthleteForm : Form
    {
        String str = null; SqlConnection conn;
        public EditAthleteForm(Form2 f, SqlConnection c, string s)
        {
            InitializeComponent();
            str = s;
            conn = c;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void EditAthleteForm_Load(object sender, EventArgs e)
        {

            dateTimePicker_Edit_athlete_DOB.CustomFormat = "MM/dd/yyyy";
            dateTimePicker_Edit_athlete_DOB.Format = DateTimePickerFormat.Custom;

            textBox_Edit_athlete_athlete_ID.Clear();
            textBox_Edit_athlete_FIO.Clear();
            textBox_Edit_athlete_rang.Clear();
            textBox_Edit_athlete_cname.Clear();

            SqlDataReader sqlReader = null;
            SqlCommand sqlcommand = new SqlCommand("SELECT * FROM [athlete] WHERE athlete_ID=@ATHLETE_ID", conn);
            sqlcommand.Parameters.AddWithValue("ATHLETE_ID", str);


            try
            {

                sqlReader = await sqlcommand.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    textBox_Edit_athlete_athlete_ID.Text = Convert.ToString(sqlReader["athlete_ID"]);
                    textBox_Edit_athlete_FIO.Text = Convert.ToString(sqlReader["FIO"]);
                    textBox_Edit_athlete_rang.Text = Convert.ToString(sqlReader["rang"]);
                    textBox_Edit_athlete_cname.Text = Convert.ToString(sqlReader["cname"]);
                    dateTimePicker_Edit_athlete_DOB.Value = Convert.ToDateTime(sqlReader["DOB"]);
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

        private async void button_athlete_Edit_Save_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcommand = new SqlCommand("UPDATE [athlete] SET FIO=@FION,DOB=(convert(datetime,@DOBN,101)),rang=@RANG,cname=@CNAME WHERE athlete_ID=@ATHLETE_ID", conn);
            sqlcommand.Parameters.AddWithValue("ATHLETE_ID", textBox_Edit_athlete_athlete_ID.Text);
            sqlcommand.Parameters.AddWithValue("FION", textBox_Edit_athlete_FIO.Text);
            sqlcommand.Parameters.AddWithValue("DOBN", dateTimePicker_Edit_athlete_DOB.Text);
            sqlcommand.Parameters.AddWithValue("RANG", textBox_Edit_athlete_rang.Text);
            sqlcommand.Parameters.AddWithValue("CNAME", textBox_Edit_athlete_cname.Text);
            sqlcommand.ExecuteNonQueryAsync();
            this.Close();
        }
    }
}
