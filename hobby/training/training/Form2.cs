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


namespace training
{
    public partial class Form2 : Form
    {
        SqlConnection conn;
        public Form2(SqlConnection c)
        {
            conn= c;
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void UpdateTabControl()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT training_name,count,primech FROM training WHERE day=" + (tabControl1.SelectedIndex + 1), conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            
            SqlCommand command = new SqlCommand("SELECT holidays FROM [holidays] WHERE training_day=" + (tabControl1.SelectedIndex + 1), conn);
            SqlDataReader sqlReader = await command.ExecuteReaderAsync();
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    TabPage tp = tabControl1.SelectedTab as TabPage;
                    ComboBox cmbbx = tp.Controls["comboBox1"] as ComboBox;
                    cmbbx.Text = Convert.ToString(sqlReader["holidays"]);
                }
            };

            try
            {
                DataSet ds = new DataSet();
                da.Fill(ds);

                TabPage tp = tabControl1.SelectedTab as TabPage;
                DataGridView dg = tp.Controls["dataGridView1"] as DataGridView;
                dg.DataSource = ds.Tables[0];

                dg.Columns[0].Width = 300;
                dg.Columns[1].Width = 41;
                dg.Columns[2].Width = dg.Width-300-41-45;

           }
            catch (Exception ex)
           {
                MessageBox.Show("Запрос не вернул результат.");
            }
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.training". При необходимости она может быть перемещена или удалена.
           // this.trainingTableAdapter.Fill(this.database1DataSet.training);

            SqlDataReader sqlReader = null;
            for (int i = 2; i < 10; i++)
            {
                try
                {
                    sqlReader = null;
                    SqlCommand command = new SqlCommand("SELECT * FROM [training] WHERE day="+i, conn);
                    sqlReader = await command.ExecuteReaderAsync();
                   
                    if (sqlReader.HasRows)
                    {
                        button3_Click(null, null);
                        tabControl1.SelectedIndex = i-1;
                        UpdateTabControl();
                    };
                }
                catch (Exception ex)
                {
                }
                finally
                {
                   // if (sqlReader != null) sqlReader.Close();
                }
            }
            sqlReader.Close();
            tabControl1.SelectedIndex = 0;
            UpdateTabControl();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            

            TabPage tp = tabControl1.SelectedTab as TabPage;
            TextBox txtBox01 = tp.Controls["textBox1"] as TextBox;
            ComboBox combobo02 = tp.Controls["comboBox2"] as ComboBox;
            TextBox txtBox03 = tp.Controls["textBox3"] as TextBox;

            SqlCommand sqlcommand = new SqlCommand("INSERT INTO [training] (day,training_name,count,primech) VALUES (" + (tabControl1.SelectedIndex+1) +
                ",@TN,@COUN,@PR)", conn);
            sqlcommand.Parameters.Add("@TN", SqlDbType.NVarChar, 200);
            sqlcommand.Parameters["@TN"].Value = txtBox01.Text;
            sqlcommand.Parameters.Add("@PR", SqlDbType.NVarChar, 1000);
            sqlcommand.Parameters["@PR"].Value = txtBox03.Text;
            sqlcommand.Parameters.AddWithValue("COUN", combobo02.Text);

            await sqlcommand.ExecuteNonQueryAsync();
            UpdateTabControl();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabCount > 9) return;//максимум 10 вкладок
            string title = "Тренировка " + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            myTabPage.BackColor = System.Drawing.Color.White;
            tabControl1.TabPages.Add(myTabPage);

            Button button_add = new Button();
            button_add.Text = button2.Text;
            button_add.BackColor = System.Drawing.Color.Lime;
            button_add.ForeColor = button2.ForeColor;
            button_add.Width = button2.Width;
            button_add.Height = button2.Height;
            button_add.Location = new Point(button2.Location.X, button2.Location.Y);
            button_add.Click += new EventHandler(button2_Click);

            Button button_delete = new Button();
            button_delete.Text = button1.Text;
            button_delete.ForeColor = button1.ForeColor;
            button_delete.BackColor = System.Drawing.Color.Red;
            button_delete.Width = button1.Width;
            button_delete.Height = button1.Height;
            button_delete.Location = new Point(button1.Location.X, button1.Location.Y);
            button_delete.Click += new EventHandler(button1_Click);

            Button button_save = new Button();
            button_save.Text = button5.Text;
            button_save.ForeColor = button5.ForeColor;
            button_save.BackColor = System.Drawing.Color.Lime;
            button_save.Width = button5.Width;
            button_save.Height = button5.Height;
            button_save.Location = new Point(button5.Location.X, button5.Location.Y);
            button_save.Click += new EventHandler(button5_Click);

            TextBox textbox1 = new TextBox();
            textbox1.Width = textBox1.Width;
            textbox1.Height = textBox1.Height;
            textbox1.Location = new Point(textBox1.Location.X, textBox1.Location.Y);
            textbox1.Name = "textBox1";// +(((tabControl1.TabCount + 1) * 3) - 2).ToString();

            TextBox textbox3 = new TextBox();
            textbox3.Width = textBox3.Width;
            textbox3.Height = textBox3.Height;
            textbox3.Location = new Point(textBox3.Location.X, textBox3.Location.Y);
            textbox3.Name = "textBox3";// +((tabControl1.TabCount + 1) * 3).ToString();

            Label label01 = new Label() ;
            label01.Text = label1.Text;
            label01.Height = label1.Height;
            label01.Width = label1.Width;
            label01.Location = new Point(label1.Location.X, label1.Location.Y);

            Label label02 = new Label();
            label02.Text = label2.Text;
            label02.Height = label2.Height;
            label02.Width = label2.Width;
            label02.Location = new Point(label2.Location.X, label2.Location.Y);

            Label label03 = new Label();
            label03.Text = label3.Text;
            label03.Height = label3.Height;
            label03.Width = label3.Width;
            label03.Location = new Point(label3.Location.X, label3.Location.Y);

            Label label04 = new Label();
            label04.Text = label4.Text;
            label04.Height = label4.Height;
            label04.Width = label4.Width;
            label04.Location = new Point(label4.Location.X, label4.Location.Y);

            DataGridView dg = new DataGridView();
            dg.Name = "dataGridView1";// +(tabControl1.TabCount + 1).ToString();
            dg.Width = dataGridView1.Width;
            dg.Height = dataGridView1.Height;
            dg.ColumnHeadersVisible = false;
            dg.Location = new Point(dataGridView1.Location.X, dataGridView1.Location.Y);

            ComboBox comb = new ComboBox();
            comb.Name="comboBox1";
            comb.Items.AddRange(new string[]{"1","2","3","4","5","6","7","8","9","10"});
            comb.Width = comboBox1.Width;
            comb.Height = comboBox1.Height;
            comb.Location = new Point(comboBox1.Location.X, comboBox1.Location.Y);

            ComboBox combobox = new ComboBox();
            combobox.Width = comboBox2.Width;
            combobox.Height = comboBox2.Height;
            combobox.Location = new Point(comboBox2.Location.X, comboBox2.Location.Y);
            combobox.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            combobox.Name = "comboBox2";

            //Добавляем элемент на форму
            myTabPage.Controls.Add(button_delete);
            myTabPage.Controls.Add(button_add);
            myTabPage.Controls.Add(button_save);
            myTabPage.Controls.Add(textbox1);
            myTabPage.Controls.Add(combobox);
            myTabPage.Controls.Add(textbox3);
            myTabPage.Controls.Add(label01);
            myTabPage.Controls.Add(label02);
            myTabPage.Controls.Add(label03);
            myTabPage.Controls.Add(label04);
            myTabPage.Controls.Add(dg);
            myTabPage.Controls.Add(comb);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabCount > 1) {
                SqlCommand sqlcommand = new SqlCommand("DELETE FROM [training] WHERE day=" + (tabControl1.TabCount).ToString(), conn);
                await sqlcommand.ExecuteNonQueryAsync();
                tabControl1.TabPages.RemoveAt(tabControl1.TabCount-1); 
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void trainingBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            TabPage tp = tabControl1.SelectedTab as TabPage;
            DataGridView dg = tp.Controls["dataGridView1"] as DataGridView;

            int selected_row = dg.CurrentCell.RowIndex;
            int selectedrowindex = dg.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dg.Rows[selectedrowindex];
            SqlCommand sqlcommand = new SqlCommand("DELETE FROM [training] WHERE day=" + (tabControl1.SelectedIndex + 1) + " AND training_name=@T AND count=@C AND primech=@P", conn);
            sqlcommand.Parameters.AddWithValue("T", selectedRow.Cells["training_name"].Value);
            sqlcommand.Parameters.AddWithValue("C", selectedRow.Cells["count"].Value);
            sqlcommand.Parameters.AddWithValue("P", selectedRow.Cells["primech"].Value);
            await sqlcommand.ExecuteNonQueryAsync();
            UpdateTabControl();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [holidays] WHERE training_day="+(tabControl1.SelectedIndex + 1).ToString(), conn);
            sqlReader = await command.ExecuteReaderAsync();
  
            if (sqlReader.HasRows)
            {
                //если уже есть запись
                command=new SqlCommand("UPDATE [holidays] SET holidays=@HOL WHERE training_day=" + (tabControl1.SelectedIndex + 1), conn);
            }
            else
            {
                command = new SqlCommand("INSERT INTO [holidays]  (training_day,holidays) VALUES ("+(tabControl1.SelectedIndex + 1).ToString()+",@HOL)", conn);
            }
            TabPage tp = tabControl1.SelectedTab as TabPage;
            ComboBox cmbbx = tp.Controls["comboBox1"] as ComboBox;
            command.Parameters.AddWithValue("HOL", cmbbx.Text);

            await command.ExecuteNonQueryAsync();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
