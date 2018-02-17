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
    public partial class Lgotnik : Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds;
        int rowcount = 0;
        public Lgotnik(Form f, SqlConnection c)
        {
            InitializeComponent();
            conn = c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("USE DocumentLgoty;SELECT * FROM Grajdanin", conn);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Grajdanin");
            conn.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Grajdanin";
            rowcount = dataGridView1.RowCount;
        }

        private void Lgotnik_Load(object sender, EventArgs e)
        {
            using (var bulkCopy = new SqlBulkCopy("Data Source=localhost; Initial Catalog=DocumentLgoty;Integrated Security=SSPI;"))
            {
                bulkCopy.BatchSize = 500;
                bulkCopy.NotifyAfter = 1000;
                bulkCopy.DestinationTableName = "Grajdanin";

                DataTable dt = new DataTable();

                dt.Columns.Add("passport", typeof(int));
                dt.Columns.Add("category", typeof(int));
                dt.Columns.Add("inv_group", typeof(int));
                dt.Columns.Add("war_place", typeof(string));


                //dataGridView1.AllowUserToAddRows = false;
                for (int i = rowcount - 1; i < dataGridView1.RowCount - 1; i++)
                {

                    dt.Rows.Add(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value,
                        dataGridView1.Rows[i].Cells[2].Value, dataGridView1.Rows[i].Cells[3].Value);

                }
                rowcount = dataGridView1.RowCount;
                bulkCopy.WriteToServer(dt);
                //dataGridView1.AllowUserToAddRows = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
