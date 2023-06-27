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
    public partial class Supplier : Form
    {
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Export;Integrated Security=True";

        public Supplier()
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
                    string query = "UPDATE supplier SET supname=@catname,supemail=@supemail,supphone=@supphone,description=@description WHERE supno = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@catname", textBox3.Text);
                    sqlCmd.Parameters.AddWithValue("@description", textBox4.Text);
                    sqlCmd.Parameters.AddWithValue("@supemail", textBox5.Text);
                    sqlCmd.Parameters.AddWithValue("@supphone", textBox6.Text);

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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM supplier WHERE CONCAT(supno,supname,supemail,description) Like '%" + textBox1.Text + "%'", sqlCon);
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
            Supplier_add act = new Supplier_add();
            act.Show();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[2].Value.ToString();
                textBox6.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM supplier WHERE supno = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", textBox2.Text);
                    sqlCmd.ExecuteNonQuery();
                    search();
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
