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
    public partial class Form2 : Form
    {
        SqlConnection conn;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 f, SqlConnection c)
        {
            InitializeComponent();
            conn = c;
           // f.BackColor = Color.Yellow;
        }
        
        private async void Form2_Load(object sender, EventArgs e)
        {
            dateTimePicker_athlete_DOB.CustomFormat = "MM/dd/yyyy";
            dateTimePicker_athlete_DOB.Format = DateTimePickerFormat.Custom;
            dateTimePicker_competition_dbegin.CustomFormat = "MM/dd/yyyy";
            dateTimePicker_competition_dbegin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_competition_dend.CustomFormat = "MM/dd/yyyy";
            dateTimePicker_competition_dend.Format = DateTimePickerFormat.Custom;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sportDataSet.sport". При необходимости она может быть перемещена или удалена.
            //this.sportTableAdapter.Fill(this.sportDataSet.sport);
            
            await conn.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [sport]", conn);
            SqlCommand command_command = new SqlCommand("SELECT * FROM [command]", conn);
            SqlCommand command_athlete = new SqlCommand("SELECT * FROM [athlete]", conn);
            SqlCommand command_competition = new SqlCommand("SELECT * FROM [competition]", conn);
            SqlCommand command_result = new SqlCommand("SELECT * FROM [result]", conn);
            try  
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    ListBoxSport.Items.Add(Convert.ToString(sqlReader["stype"]) + '\t' + Convert.ToString(sqlReader["edizm"]) + '\t' +
                        Convert.ToString(sqlReader["wrecord"]) + '\t' + Convert.ToString(sqlReader["wrdata"]));
                }
                sqlReader = await command_command.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    listBox_command.Items.Add(Convert.ToString(sqlReader["cname"]) + '\t' + Convert.ToString(sqlReader["stype"]));
                }
                sqlReader = await command_athlete.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    listBox_athlete.Items.Add(Convert.ToString(sqlReader["athlete_ID"]) + '\t' + Convert.ToString(sqlReader["FIO"]) + '\t' +
                        Convert.ToString(sqlReader["DOB"]) + '\t' + Convert.ToString(sqlReader["rang"]) + '\t' + Convert.ToString(sqlReader["cname"]));
                }
                sqlReader = await command_competition.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    listBox_competition.Items.Add(Convert.ToString(sqlReader["sname"]) + '\t' + Convert.ToString(sqlReader["place"]) + '\t' +
                        Convert.ToString(sqlReader["dbegin"]) + '\t' + Convert.ToString(sqlReader["dend"]));
                }
                sqlReader = await command_result.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    listBox_result.Items.Add(Convert.ToString(sqlReader["athlete_ID"]) + '\t' + Convert.ToString(sqlReader["result"]) + '\t' +
                        Convert.ToString(sqlReader["sname"]));
                }
            }
            catch(Exception ex)
            {
                //NC-14 A simple catch.  

                MessageBox.Show("Таблицы не созданы. Сейчас произойдет создание таблиц.");
                try
                {
                    command = new SqlCommand("IF OBJECT_ID('dbo.sport') IS NULL CREATE TABLE sport(stype 	Varchar(256) Not Null,edizm 	Varchar(10)	Null,wrecord	Int	Null,wrdata	Int	Null,PRIMARY KEY(stype),CHECK (wrdata<=YEAR(getdate()) AND wrdata>1000 AND wrecord>0))", conn);
                    command.ExecuteNonQuery();
                    command = new SqlCommand("IF OBJECT_ID('dbo.command') IS NULL CREATE TABLE command(cname	Varchar(256)	Not Null,stype 	Varchar(256)	Null,PRIMARY KEY(cname),FOREIGN KEY (stype) REFERENCES sport(stype))", conn);
                    command.ExecuteNonQuery();
                    command = new SqlCommand("IF OBJECT_ID('dbo.athlete') IS NULL CREATE TABLE athlete(athlete_ID	Int	Not Null IDENTITY,FIO 	Varchar(256)	Not Null,DOB 	Datetime	Null,rang	Int	Null,cname	Varchar(256)	Null,PRIMARY KEY(athlete_ID),FOREIGN KEY (cname) REFERENCES command(cname),CHECK (YEAR(DOB)<=YEAR(getdate()) AND FIO LIKE '% % %'))", conn);
                    command.ExecuteNonQuery();
                    command = new SqlCommand("IF OBJECT_ID('dbo.competition') IS NULL CREATE TABLE competition(sname 	Varchar(256)	Not Null,place 	Varchar(256)	Null,dbegin	Datetime	Null,dend	Datetime	Null,PRIMARY KEY(sname),CHECK (YEAR(dbegin)<=YEAR(getdate()) AND YEAR(dend)<=YEAR(getdate()) AND dbegin<dend))", conn);
                    command.ExecuteNonQuery();
                    command = new SqlCommand("IF OBJECT_ID('dbo.result') IS NULL CREATE TABLE result(athlete_ID	Int	Not Null,result	Int	Null,sname	Varchar(256)	Not Null,PRIMARY KEY(athlete_ID),FOREIGN KEY (athlete_ID) REFERENCES athlete(athlete_ID),FOREIGN KEY (sname) REFERENCES competition(sname))", conn);
                    command.ExecuteNonQueryAsync();
                    MessageBox.Show("Таблицы созданы.");
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message.ToString(), ex1.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
         
            }
            finally
            {
                if (sqlReader != null) sqlReader.Close();
            } 
        }

        private void ListBoxSport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void Обновить_Click(object sender, EventArgs e)
        {
            ListBoxSport.Items.Clear();
            listBox_command.Items.Clear();
            listBox_athlete.Items.Clear();
            listBox_competition.Items.Clear();
            listBox_result.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [sport]", conn);
            SqlCommand command_command = new SqlCommand("SELECT * FROM [command]", conn);
            SqlCommand command_athlete = new SqlCommand("SELECT * FROM [athlete]", conn);
            SqlCommand command_competition = new SqlCommand("SELECT * FROM [competition]", conn);
            SqlCommand command_result = new SqlCommand("SELECT * FROM [result]", conn);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    ListBoxSport.Items.Add(Convert.ToString(sqlReader["stype"]) + '\t' + Convert.ToString(sqlReader["edizm"]) + '\t' +
                        Convert.ToString(sqlReader["wrecord"]) + '\t' + Convert.ToString(sqlReader["wrdata"]));
                }
                sqlReader = await command_command.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    listBox_command.Items.Add(Convert.ToString(sqlReader["cname"]) + '\t' + Convert.ToString(sqlReader["stype"]));
                }
                sqlReader = await command_athlete.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    listBox_athlete.Items.Add(Convert.ToString(sqlReader["athlete_ID"]) + '\t' + Convert.ToString(sqlReader["FIO"]) + '\t' +
                        Convert.ToString(sqlReader["DOB"]) + '\t' + Convert.ToString(sqlReader["rang"]) + '\t' + Convert.ToString(sqlReader["cname"]));
                }
                sqlReader = await command_competition.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    listBox_competition.Items.Add(Convert.ToString(sqlReader["sname"]) + '\t' + Convert.ToString(sqlReader["place"]) + '\t' +
                        Convert.ToString(sqlReader["dbegin"]) + '\t' + Convert.ToString(sqlReader["dend"]));
                }
                sqlReader = await command_result.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    listBox_result.Items.Add(Convert.ToString(sqlReader["athlete_ID"]) + '\t' + Convert.ToString(sqlReader["result"]) + '\t' +
                        Convert.ToString(sqlReader["sname"]));
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

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            //this.клиентыBindingSource.EndEdit();
            this.sportTableAdapter.Update(this.sportDataSet.sport);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button_Add_sport_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcommand=new SqlCommand("INSERT INTO [sport] VALUES (@STYPE,@EDIZM,@WRECORD,@WRDATA)",conn);
            sqlcommand.Parameters.AddWithValue("STYPE", textBox_stype.Text);
            sqlcommand.Parameters.AddWithValue("EDIZM", textBox_edizm.Text);
            sqlcommand.Parameters.AddWithValue("WRECORD", textBox_wrecord.Text);
            sqlcommand.Parameters.AddWithValue("WRDATA", textBox_wrdata.Text);
            sqlcommand.ExecuteNonQueryAsync();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State != ConnectionState.Closed) conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonEdit_sport_Click(object sender, EventArgs e)
        {
            if (ListBoxSport.SelectedIndex == -1) {
                MessageBox.Show("Нужно выбрать запись.");
                    return;
            }
            string[] str=ListBoxSport.SelectedItem.ToString().Split('\t');
            EditSportForm sportEditForm = new EditSportForm(this, conn, str[0]);
            sportEditForm.ShowDialog();

        }

        private async void button_sport_delete_Click(object sender, EventArgs e)
        {
            if (ListBoxSport.SelectedIndex == -1)
            {
                MessageBox.Show("Нужно выбрать запись.");
                return;
            }
            string[] str = ListBoxSport.SelectedItem.ToString().Split('\t');
            SqlCommand sqlcommand = new SqlCommand("DELETE FROM sport WHERE stype=@STYPE", conn);
            sqlcommand.Parameters.AddWithValue("STYPE", str[0]);
            sqlcommand.ExecuteNonQueryAsync();
        }

        private async void button_Add_command_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcommand = new SqlCommand("INSERT INTO [command] VALUES (@CNAME,@STYPE)", conn);
            sqlcommand.Parameters.AddWithValue("CNAME", textBox_Command_cname.Text);
            sqlcommand.Parameters.AddWithValue("STYPE", textBox_Command_stype.Text);
            sqlcommand.ExecuteNonQueryAsync();
        }

        private void button_Refresh_command_Click(object sender, EventArgs e)
        {
            Обновить_Click(sender, e);
        }

        private void sportBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Обновить_Click(sender, e);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Обновить_Click(sender, e);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Обновить_Click(sender, e);
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcommand = new SqlCommand("INSERT INTO [athlete] VALUES (@FIO, convert(datetime,@DOB, 101), @RANG,@CNAME)", conn);
            sqlcommand.Parameters.AddWithValue("FIO", textBox_athlete_FIO.Text);
            sqlcommand.Parameters.AddWithValue("DOB", dateTimePicker_athlete_DOB.Text);
            sqlcommand.Parameters.AddWithValue("RANG", textBox_athlete_rang.Text);
            sqlcommand.Parameters.AddWithValue("CNAME", textBox_athlete_cname.Text);
            sqlcommand.ExecuteNonQueryAsync();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private async void button12_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcommand = new SqlCommand("INSERT INTO [competition] VALUES (@SNAME,@PLACE, convert(datetime,@DBEGIN, 101), convert(datetime,@DEND, 101))", conn);
            sqlcommand.Parameters.AddWithValue("SNAME", textBox_competition_sname.Text);
            sqlcommand.Parameters.AddWithValue("PLACE", textBox_competition_place.Text);
            sqlcommand.Parameters.AddWithValue("DBEGIN", dateTimePicker_competition_dbegin.Text);
            sqlcommand.Parameters.AddWithValue("DEND", dateTimePicker_competition_dend.Text);
            sqlcommand.ExecuteNonQueryAsync();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcommand = new SqlCommand("INSERT INTO [result] VALUES (@ATHLETEID,@RESULT, @SNAME)", conn);
            sqlcommand.Parameters.AddWithValue("ATHLETEID", textBox_result_athlete_ID.Text);
            sqlcommand.Parameters.AddWithValue("RESULT", textBox_result_result.Text);
            sqlcommand.Parameters.AddWithValue("SNAME", textBox_result_sname.Text);
            sqlcommand.ExecuteNonQueryAsync();
        }

        private void button_Edit_command_Click(object sender, EventArgs e)
        {
            if (listBox_command.SelectedIndex == -1)
            {
                MessageBox.Show("Нужно выбрать запись.");
                return;
            }
            string[] str = listBox_command.SelectedItem.ToString().Split('\t');
            Form_command_Edit CommandEditForm = new Form_command_Edit(this, conn, str[0]);
            CommandEditForm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox_athlete.SelectedIndex == -1)
            {
                MessageBox.Show("Нужно выбрать запись.");
                    return;
            }
            string[] str = listBox_athlete.SelectedItem.ToString().Split('\t');
            EditAthleteForm sportEditForm = new EditAthleteForm(this, conn, str[0]);
            sportEditForm.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (listBox_competition.SelectedIndex == -1)
            {
                MessageBox.Show("Нужно выбрать запись.");
                return;
            }
            string[] str = listBox_competition.SelectedItem.ToString().Split('\t');
            EditCompetitionForm competitionEditForm = new EditCompetitionForm(this, conn, str[0]);
            competitionEditForm.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (listBox_result.SelectedIndex == -1)
            {
                MessageBox.Show("Нужно выбрать запись.");
                return;
            }
            string[] str = listBox_result.SelectedItem.ToString().Split('\t');
            EditResultForm resultEditForm = new EditResultForm(this, conn, str[0]);
            resultEditForm.ShowDialog();
        }

        private void button_Delete_command_Click(object sender, EventArgs e)
        {
            if (listBox_command.SelectedIndex == -1)
            {
                MessageBox.Show("Нужно выбрать запись.");
                return;
            }
            string[] str = listBox_command.SelectedItem.ToString().Split('\t');
            SqlCommand sqlcommand = new SqlCommand("DELETE FROM command WHERE cname=@CNAME", conn);
            sqlcommand.Parameters.AddWithValue("CNAME", str[0]);
            sqlcommand.ExecuteNonQueryAsync();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox_athlete.SelectedIndex == -1)
            {
                MessageBox.Show("Нужно выбрать запись.");
                return;
            }
            string[] str = listBox_athlete.SelectedItem.ToString().Split('\t');
            SqlCommand sqlcommand = new SqlCommand("DELETE FROM athlete WHERE athlete_ID=@ATHLETE_ID", conn);
            sqlcommand.Parameters.AddWithValue("ATHLETE_ID", str[0]);
            sqlcommand.ExecuteNonQueryAsync();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox_competition.SelectedIndex == -1)
            {
                MessageBox.Show("Нужно выбрать запись.");
                return;
            }
            string[] str = listBox_competition.SelectedItem.ToString().Split('\t');
            SqlCommand sqlcommand = new SqlCommand("DELETE FROM competition WHERE sname=@SNAME", conn);
            sqlcommand.Parameters.AddWithValue("SNAME", str[0]);
            sqlcommand.ExecuteNonQueryAsync();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (listBox_result.SelectedIndex == -1)
            {
                MessageBox.Show("Нужно выбрать запись.");
                return;
            }
            string[] str = listBox_result.SelectedItem.ToString().Split('\t');
            SqlCommand sqlcommand = new SqlCommand("DELETE FROM result WHERE athlete_ID=@ATHLETE_ID", conn);
            sqlcommand.Parameters.AddWithValue("ATHLETE_ID", str[0]);
            sqlcommand.ExecuteNonQueryAsync();
        }

        private void tabPage_sport_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
