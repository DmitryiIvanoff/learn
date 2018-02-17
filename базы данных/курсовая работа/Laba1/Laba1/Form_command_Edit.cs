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
    public partial class Form_command_Edit : Form
    {
        String cname = null; SqlConnection conn;
        public Form_command_Edit(Form2 f, SqlConnection c, string str)
        {
            InitializeComponent();
            cname = str;
            conn = c;
        }

        private async void Form_command_Edit_Load(object sender, EventArgs e)
        {
            textBox_Edit_Command_cname.Clear();
            textBox_Edit_Command_stype.Clear();
           
            SqlDataReader sqlReader = null;
            SqlCommand sqlcommand = new SqlCommand("SELECT * FROM [command] WHERE cname=@CNAME", conn);
            sqlcommand.Parameters.AddWithValue("CNAME", cname);


            try
            {

                sqlReader = await sqlcommand.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    textBox_Edit_Command_cname.Text = Convert.ToString(sqlReader["cname"]);
                    textBox_Edit_Command_stype.Text = Convert.ToString(sqlReader["stype"]);
               
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

        private async void button_Save_command_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcommand = new SqlCommand("UPDATE [command] SET stype=@STYPE WHERE cname=@CNAME", conn);
            sqlcommand.Parameters.AddWithValue("CNAME", textBox_Edit_Command_cname.Text);
            sqlcommand.Parameters.AddWithValue("STYPE", textBox_Edit_Command_stype.Text);
            sqlcommand.ExecuteNonQueryAsync();
            this.Close();
        }
    }
}
