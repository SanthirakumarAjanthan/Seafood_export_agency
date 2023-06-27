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
namespace Export_agency
{
    public partial class Category : Form
    {
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Export;Integrated Security=True";
        public Category()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE category SET catname=@catname,description=@description WHERE catno = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@catname", textBox3.Text);
                    sqlCmd.Parameters.AddWithValue("@description", textBox4.Text);

                    sqlCmd.Parameters.AddWithValue("@id", textBox2.Text);
                    sqlCmd.ExecuteNonQuery();
                    search();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void search()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM category WHERE CONCAT(catno,catname,description) Like '%" + textBox1.Text + "%'", sqlCon);
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }


        }
        private void Category_Load(object sender, EventArgs e)
        {
            search();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Category_Add act = new Category_Add();
            act.Show();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM category WHERE catno = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", textBox2.Text);
                    sqlCmd.ExecuteNonQuery();
                    search();
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
