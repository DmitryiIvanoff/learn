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
    public partial class Form1 : Form
    {
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\username\Desktop\учеба\Четвертый семестр\Базы данных\Programs\Laba1\Laba1\Sport.mdf;Integrated Security=True;MultipleActiveResultSets=True";
            conn = new SqlConnection(connectionString);
            comboBox1.Items.Add("INSERT INTO sport (stype,edizm) VALUES('Stanovaya tyaga','kg'),('Plavanie brasom','sec')");
            comboBox1.Items.Add("DELETE FROM sport WHERE stype='Stanovaya tyaga'");
            comboBox1.Items.Add("UPDATE sport SET wrecord=200,wrdata=1980 WHERE stype='Plavanie brasom'");
            comboBox1.Items.Add("SELECT * FROM sport WHERE wrdata>1985");
            comboBox1.Items.Add("SELECT * FROM competition UNION SELECT * FROM sport");
            comboBox1.Items.Add("SELECT * FROM result WHERE result.athlete_ID IN (SELECT athlete_ID FROM athlete)");
            comboBox1.Items.Add("SELECT * FROM sport WHERE sport.stype NOT IN (SELECT stype FROM command)");
            comboBox1.Items.Add("SELECT * FROM sport,command");
            comboBox1.Items.Add("SELECT DISTINCT FIO ,DOB ,rang FROM athlete");
            comboBox1.Items.Add("SELECT * FROM athlete,sport,command WHERE athlete.cname=command.cname AND sport.stype=command.stype");
            //мои запросы
            comboBox1.Items.Add("SELECT * FROM athlete WHERE athlete.athlete_ID IN (SELECT athlete_ID FROM result) AND athlete.cname IN (SELECT cname FROM command)");
            comboBox1.Items.Add("SELECT FIO FROM athlete AS A WHERE A.rang>1 UNION SELECT sname FROM competition AS C WHERE C.sname IN (SELECT cname FROM command)");
            comboBox1.Items.Add("SELECT DISTINCT FIO ,DOB ,rang FROM athlete AS A WHERE A.rang>1 AND A.cname IN (SELECT cname FROM command AS C WHERE C.stype IN (SELECT stype  FROM sport))");
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {

        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this, conn);
            newForm.ShowDialog();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_edizm.Text = this.comboBox1.Text;
        }
        
        private async void button_GO_Click(object sender, EventArgs e)
        {
                await conn.OpenAsync();
                SqlDataAdapter da = new SqlDataAdapter(textBox_edizm.Text, conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                try
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Запрос не вернул результат.");
                }
            

                conn.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
