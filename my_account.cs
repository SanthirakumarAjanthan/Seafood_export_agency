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
    public partial class my_account : Form
    {
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Export;Integrated Security=True";

        public my_account()
        {
            InitializeComponent();
        }

        string pw;
        protected void Loginform()
        {
            Form1 frm = new Form1();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(String.Format("select * from Admin_Log where Username='" + Login.user + "'"), conn);
            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                textBox1.Text = reader.GetValue(1).ToString();
                textBox2.Text = reader.GetValue(2).ToString();
                textBox3.Text = reader.GetValue(4).ToString();
                comboBox1.Text = reader.GetValue(5).ToString();
                pw= reader.GetValue(3).ToString();


            }

            else
            {

                MessageBox.Show("username wrong");

            }

            conn.Close();
        }
        private void my_account_Load(object sender, EventArgs e)
        {
            Loginform();
        }

        private void clear()
        {
            textBox5.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox5.Text==textBox4.Text)
            {
                if (textBox2.Text == textBox6.Text)
                {



                    if (textBox7.Text == pw)
                    {
                        using (SqlConnection sqlCon = new SqlConnection(connectionString))
                        {
                            sqlCon.Open();
                            string query = "UPDATE Admin_Log SET password=@password WHERE Username = @id";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                            sqlCmd.Parameters.AddWithValue("@password", textBox5.Text);

                            sqlCmd.Parameters.AddWithValue("@id", textBox6.Text);
                            sqlCmd.ExecuteNonQuery();
                            clear();
                            MessageBox.Show("Succuss");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your Old Password Does not match");
                    }


                }
                else
                {
                    MessageBox.Show("Please enter correct User Name");
                }
            }
            else
            {
                MessageBox.Show("Password Does not match");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Admin_Log SET name=@name,Email=Email,Designation=@Designation WHERE Username = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@name", textBox1.Text);
                sqlCmd.Parameters.AddWithValue("@Email", textBox3.Text);
                
                sqlCmd.Parameters.AddWithValue("@Designation", comboBox1.Text);
                sqlCmd.Parameters.AddWithValue("@id", textBox2.Text);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Updated");
            }
        }
    }
}
