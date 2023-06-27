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
    public partial class Category_Add : Form
    {
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Export;Integrated Security=True";
        public Category_Add()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "")
            {

                try
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO category (catname,description) VALUES (@catname,@description)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@catname", textBox3.Text);
                        sqlCmd.Parameters.AddWithValue("@description", textBox4.Text);

                        sqlCmd.ExecuteNonQuery();
                        this.Close();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill All the Fields");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
