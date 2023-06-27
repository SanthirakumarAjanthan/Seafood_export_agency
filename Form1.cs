using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Export_agency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new Category());
        }

        private void button5_Click(object sender, EventArgs e)
        {
           openChildForm(new Product());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //openChildForm(new Stock());
            openChildForm(new Purchase());
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lblUser.Text = Login.user;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //openChildForm(new Help());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Dispose();

        }
        public static string user = "";
        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //openChildForm(new Admin_Manage_user());
            openChildForm(new Customer());
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Export());
            //user = gunaLabel1.Text;
            //openChildForm(new User_Prof());
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Dispose();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Help());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lblUser.Text == "admin")
            {
                openChildForm(new DB_Backup());
            }
            else
            {
                MessageBox.Show("You Cannot access Admin Side");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //openChildForm(new Ad_sales());
            openChildForm(new Supplier());
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (lblUser.Text == "admin")
            {
                openChildForm(new Settings());
            }
            else
            {
                openChildForm(new my_account());
            }
        }
    }
}
