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
    public partial class Login : Form
    {
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Export;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
        }

        public static string user = "";
        protected void Loginform()
        {

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(String.Format("select * from Admin_Log where Username='" + textBox1.Text + "' and password='" + textBox2.Text + "'"), conn);
            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                if (textBox1.Text.ToLower() == "admin")
                {
                    user = "admin";
                    Form1 mn = new Form1();
                    mn.Show();
                    textBox1.Text = "";
                  textBox2.Text = "";

                    this.Hide();


                }
                else
                {
                    user = textBox1.Text.ToLower();
                    Form1 mn = new Form1();
                    mn.Show();
                    textBox1.Text = "";
                    textBox2.Text = "";

                    this.Hide();

                }


            }

            else
            {

                MessageBox.Show("username or password is incorrect");

            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loginform();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
