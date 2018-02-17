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

namespace Kursovaya_Ivanov
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
            //коннектимся к локалке Microsoft SQL Server
            conn = new SqlConnection(@"Data Source=localhost; Integrated Security=SSPI;");
            conn.Open();

            //создаем БД
            SqlCommand command = new SqlCommand(@"USE master;
                IF DB_ID('DocumentLgoty') IS NULL CREATE DATABASE DocumentLgoty;", conn);
            command.ExecuteNonQuery();
            //создаем таблицы
            command = new SqlCommand(@"USE DocumentLgoty;
                IF OBJECT_ID('dbo.Document') IS NULL CREATE TABLE Document(
	                doc_name Varchar(256) Not Null,
	                doc_data_begin Datetime Null,
	                doc_data_end Datetime Null,
	                finance Varchar(256) Null,
	                PRIMARY KEY(doc_name),
	                CHECK (YEAR(doc_data_begin)<=YEAR(getdate()) AND YEAR(doc_data_begin)>1990 AND YEAR(doc_data_end)>=YEAR(getdate()) AND doc_data_begin<doc_data_end)
                );
                IF OBJECT_ID('dbo.VidLgoty') IS NULL CREATE TABLE VidLgoty(
	                lgota_name	Varchar(256)	Not Null,
	                lgota_proc	Int	Null,
	                lgota_data_begin	Datetime	Null,
	                lgota_data_end_JKH	Datetime	Null,
	                doc_name Varchar(256)	Not Null,
	                PRIMARY KEY(lgota_name),
	                FOREIGN KEY (doc_name) REFERENCES Document(doc_name),
	                CHECK (YEAR(lgota_data_begin)<=YEAR(getdate()) AND YEAR(lgota_data_begin)>1990 AND YEAR(lgota_data_end_JKH)>=YEAR(getdate()) AND lgota_data_begin<lgota_data_end_JKH)
                );
                IF OBJECT_ID('dbo.Lgota') IS NULL CREATE TABLE Lgota(
	                passport	Int	Not Null,
	                lgota_name	Varchar(256)	Not Null,
	                PRIMARY KEY(passport),
	                FOREIGN KEY (lgota_name) REFERENCES VidLgoty(lgota_name),
	                CHECK (passport > 100000000)
                );
                IF OBJECT_ID('dbo.Grajdanin') IS NULL CREATE TABLE Grajdanin(
	                passport	Int	Not Null,
	                category	Int	Null,
	                inv_group	Int	Null,
	                war_place	Varchar(256)	Null,
	                PRIMARY KEY(passport),
	                FOREIGN KEY (passport) REFERENCES Lgota(passport),
	                CHECK (passport > 100000000 AND category<4 AND category>0)
                );", conn);
            command.ExecuteNonQuery();
            //создаем процедуры - нельзя создать отсюда, похоже прав не хватает
            /*command = new SqlCommand(@"USE DocumentLgoty;
                    IF OBJECT_ID ('dbo.Zapros01') IS NOT NULL DROP PROCEDURE Zapros01;
                    CREATE PROC dbo.Zapros01
                    @var varchar(256)
                    AS
                    SELECT doc_name FROM Document WHERE Document.doc_name IN (SELECT doc_name FROM VidLgoty WHERE lgota_name=@var);
                    IF OBJECT_ID ('dbo.Zapros1') IS NOT NULL DROP PROCEDURE Zapros1;
                    CREATE PROC dbo.Zapros1
                    @var varchar(256)
                    AS
                    CREATE TABLE dbo.Table1 ([name] sysname NOT NULL)
                    INSERT INTO dbo.Table1 ([name])
                    EXEC dbo.Zapros01 @var
                    SELECT * FROM dbo.Table1
                    DROP TABLE dbo.Table1;", conn);
            command.ExecuteNonQuery();
            MessageBox.Show("123");*/

            //создаем тригер на событие INSERT на таблицу Lgota, он
            //будет автоматически добавлять записи в таблицу Grajdanin
            /*command = new SqlCommand(@"USE  DocumentLgoty;
	                IF OBJECT_ID ('auto_fill_grajdanin') IS NOT NULL DROP TRIGGER auto_fill_grajdanin;
	                CREATE TRIGGER auto_fill_grajdanin ON Lgota 
	                FOR INSERT AS DECLARE 
		                 @passport Varchar(256),
		                 @lgota_name int
	                BEGIN
		                SELECT @passport = (SELECT passport FROM inserted)

		                INSERT INTO Grajdanin VALUES (@passport, 1, 2, NULL)
	                END;", conn);
            command.ExecuteNonQuery();*/

            comboBox1.Items.Add("Найти документ по названию льготы");
            comboBox1.Items.Add("Найти всех граждан и льготы и их количество по документу");
            comboBox1.Items.Add("Выбрать все льготы, указанные в заданном нормативном документе, для заданной категории граждан, которые действовали в указанный период времени");
            comboBox1.Items.Add("Определить перечень категорий граждан, для которых действуют максимальные жилищно-коммунальные льготы");
            for (int i = 1; i < 4; i++)
            {
                comboBox2.Items.Add(Convert.ToString(i));
            }
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            conn.Close();
            refresh_data();
        }

        private async void refresh_data(){
            
            SqlDataReader sqlReader = null;
            await conn.OpenAsync();
            SqlCommand command = new SqlCommand("USE DocumentLgoty;SELECT doc_name FROM Document", conn);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (sqlReader.Read()) 
                {
                    comboBox3.Items.Add(Convert.ToString(sqlReader["doc_name"]));
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
            sqlReader = null;
            command = new SqlCommand("USE DocumentLgoty;SELECT lgota_name FROM VidLgoty", conn);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    comboBox4.Items.Add(Convert.ToString(sqlReader["lgota_name"]));
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
            conn.Close();
            //conn.Dispose();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await conn.OpenAsync();
            try
            {
                SqlCommand command = new SqlCommand(@"USE DocumentLgoty;INSERT INTO Document VALUES('Документ 824',convert(datetime, '10/23/1993', 101),convert(datetime, '10/23/2019', 101),'минфин'),
	            ('Документ 825',convert(datetime, '10/23/2003', 101),convert(datetime, '10/23/2021', 101),'местный');
            INSERT INTO VidLgoty VALUES('ЖКХ','20',convert(datetime, '10/23/1995', 101),convert(datetime, '10/23/2019', 101),'Документ 824'),
	            ('Телефон','17',convert(datetime, '10/23/2003', 101),convert(datetime, '10/23/2019', 101),'Документ 824'),
	            ('Проезд','5',convert(datetime, '10/23/2003', 101),convert(datetime, '10/23/2021', 101),'Документ 825'),
	            ('Здравоохранение','50',convert(datetime, '10/23/2003', 101),convert(datetime, '10/23/2021', 101),'Документ 825');
            INSERT INTO Lgota VALUES(889945780,'Телефон'),
	            (889045780,'ЖКХ'),
	            (889945680,'Проезд'),
	            (879945780,'Здравоохранение'),
	            (879555780,'Здравоохранение'),
	            (999945780,'Здравоохранение');
            INSERT INTO Grajdanin VALUES(889945780,1,2,NULL),
	            (889045780,3,NULL,NULL),
	            (889945680,1,NULL,NULL),
	            (879945780,2,NULL,NULL);", conn);
                await command.ExecuteNonQueryAsync();
                this.button1.BackColor = System.Drawing.Color.Red;
                this.button1.Text = "Выполнено";
                
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                refresh_data();
                //conn.Dispose();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             comboBox4 - вид льготы
             comboBox3 - документ
             comboBox2 - кат. граждан
             dateTimePicker2 - начало действия док.
             dateTimePicker1 - конец действия док.
             */
            comboBox4.Enabled = false; comboBox3.Enabled = false; comboBox2.Enabled = false; dateTimePicker2.Enabled = false; dateTimePicker1.Enabled = false;
            int i = comboBox1.SelectedIndex;
            switch (i)
            {
                case 0:
                    comboBox4.Enabled = true;
                    ;break;
                case 1:
                    comboBox3.Enabled = true;
                    ;break;
                case 2:
                    comboBox3.Enabled = true; comboBox2.Enabled = true; dateTimePicker2.Enabled = true; dateTimePicker1.Enabled = true;
                    ;break;
                case 3:
                    ;break;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            String str ="USE DocumentLgoty;";
            switch (i)
            {
                case 0: str += @"SELECT doc_name FROM Document WHERE Document.doc_name IN 
                    (SELECT doc_name FROM VidLgoty WHERE lgota_name='" + comboBox4.Text + "')"; break;
                //"EXEC dbo.Zapros01 '" + comboBox4.Text + "')";break;
                case 1: str += @"SELECT Grajdanin.category AS cotegory,Lgota.lgota_name AS lgota,
                    COUNT(Lgota.lgota_name) AS LgotaCount,COUNT(Grajdanin.category) CategoryCount
                    FROM Grajdanin,Lgota WHERE Lgota.lgota_name IN (SELECT lgota_name FROM VidLgoty AS V WHERE  
                    V.doc_name IN (SELECT doc_name FROM Document WHERE doc_name='"+comboBox3.Text+@"')) GROUP BY 
                    Grajdanin.category,Lgota.lgota_name"; break;
                case 2: str += @"SELECT lgota_name FROM VidLgoty AS Vlgota WHERE Vlgota.lgota_name 
                    IN (SELECT Lgota.lgota_name FROM Lgota AS lgota WHERE lgota.passport 
                    IN (SELECT Grajdanin.passport FROM Grajdanin WHERE category=" + comboBox2.Text+ @")) AND Vlgota.doc_name IN 
                    (SELECT doc_name FROM Document AS D WHERE  D.doc_name='" +comboBox3.Text+@"' 
	                AND D.doc_data_begin BETWEEN '"+dateTimePicker2.Text+"' AND '"+dateTimePicker1.Text+"')"; break;
                case 3: str += @"SELECT G.category FROM Grajdanin AS G WHERE G.passport IN (
                    SELECT L.passport FROM Lgota AS L WHERE L.lgota_name  IN (
                    SELECT VL.lgota_name FROM VidLgoty AS VL 
                    WHERE (VL.lgota_name='ЖКХ' OR VL.lgota_name='Телефон') AND VL.lgota_proc=(SELECT MAX(VL2.lgota_proc) 
                    FROM VidLgoty AS VL2 WHERE VL2.lgota_name='ЖКХ' OR VL2.lgota_name='Телефон')))"; break;
            }

            await conn.OpenAsync();

            /*
             comboBox4 - вид льготы
             comboBox3 - документ
             comboBox2 - кат. граждан
             dateTimePicker2 - начало действия док.
             dateTimePicker1 - конец действия док.
             */
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            //da.SelectCommand.CommandType = CommandType.StoredProcedure; 
        
            /*da.SelectCommand.Parameters.AddWithValue("@LGOTA_VID",comboBox4.Text);
            da.SelectCommand.Parameters.AddWithValue("@DOC_NAME",comboBox3.Text);
            da.SelectCommand.Parameters.AddWithValue("@CATEGORY",comboBox2.Text);
            da.SelectCommand.Parameters.AddWithValue("@DATA_BEGIN",dateTimePicker2.Text);
            da.SelectCommand.Parameters.AddWithValue("@DATA_END", dateTimePicker1.Text);*/         
      
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            
            try
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Запрос не вернул результат:" + ex.Data);
            }
            finally
            {
                conn.Close();
                //conn.Dispose();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Document form_doc=new Document(this, conn);
            form_doc.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LgotaVid form = new LgotaVid(this, conn);
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Lgota form =new Lgota(this,conn);
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Lgotnik form = new Lgotnik(this, conn);
            form.ShowDialog();
        }
    }
}
