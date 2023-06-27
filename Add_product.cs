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
    public partial class Add_product : Form
    {
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Export;Integrated Security=True";
        public Add_product()
        {
            InitializeComponent();
        }

        string id;
        private void Add_product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exportDataSet.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.exportDataSet.category);
            // TODO: This line of code loads data into the 'pizza_DBDataSet.category' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'yopsinventoryDataSet.category' table. You can move, or remove it, as needed.

           
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "INSERT INTO product (catno,proname,b_price,S_price,avqty,Expdate,description) VALUES (@catno,@proname,@b_price,@S_price,@avqty,@Expdate,@description)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@catno", comboBox1.SelectedValue);
                    sqlCmd.Parameters.AddWithValue("@proname", textBox2.Text);
                    sqlCmd.Parameters.AddWithValue("@b_price", textBox4.Text);
                    sqlCmd.Parameters.AddWithValue("@S_price", textBox1.Text);
                    sqlCmd.Parameters.AddWithValue("@avqty", textBox6.Text);
                    sqlCmd.Parameters.AddWithValue("@Expdate", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    sqlCmd.Parameters.AddWithValue("@description", textBox5.Text);
                    sqlCmd.ExecuteNonQuery();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
