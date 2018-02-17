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
    public partial class Document : Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds;
        int rowcount = 0;
        public Document()
        {
            InitializeComponent();
        }

        public Document(Form f, SqlConnection c)
        {
            InitializeComponent();
            conn = c;
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Document_Load(object sender, EventArgs e)
        {

             da = new SqlDataAdapter("USE DocumentLgoty;SELECT * FROM Document", conn);
             ds = new DataSet();
             conn.Open();
             da.Fill(ds, "Document");
             conn.Close();
             dataGridView1.DataSource = ds;
             dataGridView1.DataMember = "Document";
             rowcount = dataGridView1.RowCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var bulkCopy = new SqlBulkCopy("Data Source=localhost; Initial Catalog=DocumentLgoty;Integrated Security=SSPI;"))
            {
                bulkCopy.BatchSize = 500;
                bulkCopy.NotifyAfter = 1000;
                bulkCopy.DestinationTableName = "Document";

                DataTable dt = new DataTable();

                dt.Columns.Add("doc_name", typeof(string));
                dt.Columns.Add("doc_data_begin", typeof(string));
                dt.Columns.Add("doc_data_end", typeof(string));
                dt.Columns.Add("finance", typeof(string));

                //dataGridView1.AllowUserToAddRows = false;
                for (int i = rowcount-1; i < dataGridView1.RowCount - 1; i++)
                {
                   
                        dt.Rows.Add(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value,
                            dataGridView1.Rows[i].Cells[2].Value, dataGridView1.Rows[i].Cells[3].Value);
          
                }
                rowcount = dataGridView1.RowCount;
                  

                bulkCopy.WriteToServer(dt);
                //dataGridView1.AllowUserToAddRows = true;
            }
            
        }
    }
}
