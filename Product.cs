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
    public partial class Product : Form
    {
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Export;Integrated Security=True";

        public Product()
        {
            InitializeComponent();
        }
        

        private void Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pizza_DBDataSet1.category' table. You can move, or remove it, as needed.
            search();


        }
        private void search()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM product WHERE CONCAT(catno,proid,proname,b_price,S_price,avqty,description) Like '%" + textBox1.Text + "%'", sqlCon);
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_product adt = new Add_product();
            adt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells[1].Value.ToString();
                comboBox1.SelectedValue = row.Cells[0].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                textBox7.Text = row.Cells[3].Value.ToString();
                textBox6.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                dateTimePicker1.Text = row.Cells[6].Value.ToString();
                textBox9.Text = row.Cells[7].Value.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE product SET catno=@catno,proname=@proname,b_price=@b_price,S_price=@S_price,avqty=@avqty,Expdate=@Expdate,description=@description WHERE proid = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@catno", comboBox1.SelectedValue);

                    sqlCmd.Parameters.AddWithValue("@proname", textBox4.Text);

                    sqlCmd.Parameters.AddWithValue("@b_price", textBox7.Text);
                    sqlCmd.Parameters.AddWithValue("@S_price", textBox6.Text);
                    sqlCmd.Parameters.AddWithValue("@avqty", textBox5.Text);
                    sqlCmd.Parameters.AddWithValue("@Expdate", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    sqlCmd.Parameters.AddWithValue("@description", textBox9.Text);


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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM product WHERE proid = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
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

        private void Product_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exportDataSet1.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.exportDataSet1.category);

        }
    }
}
