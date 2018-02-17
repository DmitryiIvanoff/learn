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
    public partial class EditResultForm : Form
    {
        String str = null; SqlConnection conn;
        public EditResultForm(Form2 f, SqlConnection c, string s)
        {
            InitializeComponent();
            str = s;
            conn = c;
        }

        private async void button_result_edit_save_Click(object sender, EventArgs e)
        {

            SqlCommand sqlcommand = new SqlCommand("UPDATE [result] SET result=@RESULT,sname=@SNAME WHERE athlete_ID=@ATHLETE_ID", conn);
            sqlcommand.Parameters.AddWithValue("ATHLETE_ID", textBox_Edit_result_athlete_ID.Text);
            sqlcommand.Parameters.AddWithValue("RESULT", textBox_Edit_result_result.Text);
            sqlcommand.Parameters.AddWithValue("SNAME", textBox_Edit_result_sname.Text);
            sqlcommand.ExecuteNonQueryAsync();
            this.Close();
        }

        private async void EditResultForm_Load(object sender, EventArgs e)
        {
            textBox_Edit_result_athlete_ID.Clear();
            textBox_Edit_result_result.Clear();
            textBox_Edit_result_sname.Clear();

            SqlDataReader sqlReader = null;
            SqlCommand sqlcommand = new SqlCommand("SELECT * FROM [result] WHERE athlete_ID=@ATHLETE_ID", conn);
            sqlcommand.Parameters.AddWithValue("ATHLETE_ID", str);


            try
            {

                sqlReader = await sqlcommand.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    textBox_Edit_result_athlete_ID.Text = Convert.ToString(sqlReader["athlete_ID"]);
                    textBox_Edit_result_result.Text = Convert.ToString(sqlReader["result"]);
                    textBox_Edit_result_sname.Text = Convert.ToString(sqlReader["sname"]);
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
    }
}
