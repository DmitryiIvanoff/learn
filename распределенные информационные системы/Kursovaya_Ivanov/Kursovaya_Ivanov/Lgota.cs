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
    public partial class Lgota : Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds;
        int rowcount = 0;
        public Lgota(Form f, SqlConnection c)
        {
            InitializeComponent();
            conn = c;
        }

        private void Lgota_Load(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("USE DocumentLgoty;SELECT * FROM Lgota", conn);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Lgota");
            conn.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Lgota";
            rowcount = dataGridView1.RowCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var bulkCopy = new SqlBulkCopy("Data Source=localhost; Initial Catalog=DocumentLgoty;Integrated Security=SSPI;"))
            {
                bulkCopy.BatchSize = 500;
                bulkCopy.NotifyAfter = 1000;
                bulkCopy.DestinationTableName = "Lgota";

                DataTable dt = new DataTable();

                dt.Columns.Add("passport", typeof(int));
                dt.Columns.Add("lgota_name", typeof(string));

                //dataGridView1.AllowUserToAddRows = false;
                for (int i = rowcount - 1; i < dataGridView1.RowCount - 1; i++)
                {

                    dt.Rows.Add(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value);

                }
                rowcount = dataGridView1.RowCount;
                bulkCopy.WriteToServer(dt);
                //dataGridView1.AllowUserToAddRows = true;
            }
        }
    }
}
