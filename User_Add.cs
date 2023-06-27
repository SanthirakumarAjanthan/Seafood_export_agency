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
    public partial class User_Add : Form
    {
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Export;Integrated Security=True";

        public User_Add()
        {
            InitializeComponent();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {

                try
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO Admin_Log (name,Username,password,Email,Designation) VALUES (@name,@Username,@password,@Email,@Designation)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@name", textBox3.Text);
                        sqlCmd.Parameters.AddWithValue("@Username", textBox1.Text.ToLower());
                        sqlCmd.Parameters.AddWithValue("@password", textBox2.Text);
                        sqlCmd.Parameters.AddWithValue("@Email", textBox4.Text);
                        sqlCmd.Parameters.AddWithValue("@Designation", comboBox1.SelectedItem.ToString());

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
