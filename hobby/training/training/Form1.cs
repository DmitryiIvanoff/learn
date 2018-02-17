using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;

namespace training
{
    public partial class Form1 : Form
    {
        private enum DateComparisonResult
        {
            Earlier = -1,
            Later = 1,
            TheSame = 0
        };
        int holidays = 1;
        int currentday = 1;
        int vsego_uprajneniy = 1;  
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
    
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename="+Environment.CurrentDirectory+@"\DATABASE1.MDF;Integrated Security=True;MultipleActiveResultSets=True;";
            conn = new SqlConnection(connectionString);
            await conn.OpenAsync();

            SqlCommand command = new SqlCommand("SELECT TOP 1 trainingnum FROM [currentday]", conn);
            SqlDataReader sqlReader = await command.ExecuteReaderAsync();
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    currentday = Convert.ToInt32(sqlReader["trainingnum"]);
                }
            };
            //заполняем combobox
            int day = 0;
            for (int i = 0; i < 10; i++)
            {
                command = new SqlCommand("SELECT * FROM [training] WHERE [day]="+i, conn);
                sqlReader = await command.ExecuteReaderAsync();
                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        if (day == Convert.ToInt32(sqlReader["day"])) continue;
                        day = Convert.ToInt32(sqlReader["day"]);
                        comboBox1.Items.Add(day);
                        vsego_uprajneniy++;
                    } 
                };
            };
            comboBox1.Text = Convert.ToString(currentday);
            //узнаем сколько отдыхать
            command = new SqlCommand("SELECT [holidays] FROM [holidays] WHERE [training_day]=" + currentday, conn);
            sqlReader = await command.ExecuteReaderAsync();
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    holidays = Convert.ToInt32(sqlReader["holidays"]);
                }
            };
            //смотрим когда была предыдцщая тренировка, предупреждаем если что
            command = new SqlCommand("SELECT * FROM [currentday] WHERE id=1", conn);
            sqlReader = await command.ExecuteReaderAsync();
            DateTime last_training = DateTime.Now ;
            DateTime current_time = DateTime.Now.Date;
            
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    DateTime.TryParse(Convert.ToString(sqlReader["last_training"]), out last_training);
                }
            };
            if (DateTime.Now.Equals(last_training))
            {
                //первая тренировка
                MessageBox.Show("Первая тренировка");
            }
            DateTime next_training = last_training.AddDays(holidays);
            int check_if_7_day = (int)next_training.DayOfWeek;
            if (check_if_7_day == 0)
            {
                //если воскресенье
                holidays++;
                next_training = last_training.AddDays(holidays);
            }
            DateComparisonResult sravneniye = (DateComparisonResult)current_time.CompareTo(next_training);
            /*
                Меньше нуля-Данный экземпляр раньше value.
                Нуль-Данный экземпляр равен value.
                Больше нуля-Этот экземпляр позже value.
             */

            if (sravneniye.ToString().Equals("Later"))
            {
                //пропустил тренировку
                MessageBox.Show("Пропустил тренировку. Прошлая тренировка была: " + last_training.ToShortDateString());
               
            }
            else if (sravneniye.ToString().Equals("TheSame"))
            {
                //самое время
                MessageBox.Show("Вовремя. Сегодня тренировочный день");
            }
            else
            {
                //ещё рано
                MessageBox.Show("Ещё рано. Прошлая тренировка была: " + last_training.ToShortDateString());
                
            }
            //выделим сл. тренировку на календаре
            
            monthCalendar1.SetDate(next_training);
            monthCalendar1.AddBoldedDate(next_training);
            init_panel();
            show_Programm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(conn);
            form2.ShowDialog();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void init_panel()
        {
           /* tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            */
        }

        int uprajnenie = 0;
        int minus_podhody = 0;
        bool is_finished = false;

        private async void show_Programm()
        {
            if (is_finished) return;
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";

            SqlCommand command = new SqlCommand("SELECT COUNT(*)  FROM training WHERE day=" + currentday, conn);
            int row_counts=(int)command.ExecuteScalar();
            if (row_counts <= uprajnenie)
            {
                //завершили все упражнения
                is_finished = true;

                label5.Text = "Следующее";
                label6.Text = "занятие";
                label7.Text = DateTime.Now.AddDays(holidays).ToShortDateString();
                MessageBox.Show("Поздравляю! Следующее занятие: " + DateTime.Now.AddDays(holidays).ToShortDateString());
                //ставим => тренировку
                currentday++;
                if (vsego_uprajneniy == currentday)
                {
                    currentday = 1;
                }
                command = new SqlCommand("SELECT TOP 1 trainingnum FROM [currentday]", conn);
                SqlDataReader sqlReader = await command.ExecuteReaderAsync();

                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                if (sqlReader.HasRows)
                {
                    //если уже есть запись
                    command = new SqlCommand("UPDATE currentday SET trainingnum=" + currentday + ",last_training='" + sqlFormattedDate + "' WHERE id=1", conn);
                }
                else
                {
                    
                    command = new SqlCommand("INSERT INTO [currentday]  VALUES (1," + currentday + ",'" + sqlFormattedDate + "')", conn);
                }

                await command.ExecuteNonQueryAsync();
                
            }else{
                command = new SqlCommand("SELECT [training_name],[count],[primech] FROM [training] WHERE day=" + currentday, conn);
                SqlDataReader sqlReader = await command.ExecuteReaderAsync();
                if (sqlReader.HasRows)
                {
                    int count = 0;
                    while (sqlReader.Read())
                    {
                          
                        if (count != uprajnenie) { count++; continue; }
                        if ((Convert.ToInt32(sqlReader["count"]) - minus_podhody) <= 0) { uprajnenie++; minus_podhody = 0; show_Programm(); return; }
                        count++;
                        label5.Text = Convert.ToString(sqlReader["training_name"]);
                        label6.Text = Convert.ToString(Convert.ToInt32(sqlReader["count"]) - minus_podhody);
                        label7.Text = Convert.ToString(sqlReader["primech"]);
                    }
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT TOP 1 trainingnum FROM [currentday]", conn);
            SqlDataReader sqlReader = await command.ExecuteReaderAsync();

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            if (sqlReader.HasRows)
            {
                //если уже есть запись
                command = new SqlCommand("UPDATE currentday SET trainingnum=" + comboBox1.Text + ",last_training='" + sqlFormattedDate + "' WHERE id=1", conn);
                //command.Parameters.AddWithValue("CURSSS", comboBox1.Text);
            }
            else
            {
                
                command = new SqlCommand("INSERT INTO [currentday]  VALUES (1," + comboBox1.Text + ",'" + sqlFormattedDate + "')", conn);
            }
            
            await command.ExecuteNonQueryAsync();
            currentday = Convert.ToInt32(comboBox1.Text);
            minus_podhody = 0;
            uprajnenie = 0;
            is_finished = false;
            show_Programm();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            minus_podhody++;
            show_Programm();
            button3.Enabled = false;
            button4.Enabled = false;
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uprajnenie++;
            minus_podhody = 0;
            show_Programm();
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        int timeLeft=120;
        SoundPlayer sp = new SoundPlayer("c:\\Users\\username\\Desktop\\MyProjects\\training\\sound.wav");
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                label8.Text = timeLeft.ToString();
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                //label8.Text = "Время вышло.";
                button3.Enabled = true;
                button4.Enabled = true;
                timeLeft = 120;
                sp.Play();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sp.Stop();
        }

    }
}
