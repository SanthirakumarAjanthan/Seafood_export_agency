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
using System.IO;
namespace Export_agency
{
    public partial class DB_Backup : Form
    {
        private SqlCommand cmd;
        private SqlDataReader reader;
        string sql = "";
        public DB_Backup()
        {
            InitializeComponent();
        }

        private void trying()
        {

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=Export;Integrated Security=True");
            con.Open();
            // sql = "EXEC sp_databases";
            sql = "SELECT * FROM sys.databases d WHERE d.database_id>4";
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            comboBox1.Items.Clear();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0].ToString());

            }
            btnconnect.Enabled = false;
            btndisconnect.Enabled = true;

            con.Close();
            con.Dispose();
            reader.Dispose();

        }

        private void DB_Backup_Load(object sender, EventArgs e)
        {

        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            trying();
        }

        private void btndisconnect_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            btnbackup.Enabled = false;
            btnrestore.Enabled = false;
            txtlocation.Enabled = false;
            txtpath.Enabled = false;
            btnbrows2.Enabled = false;
            btnbrowse1.Enabled = false;
        }

        private void btnbrowse1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtlocation.Text = dlg.SelectedPath;
            }
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=Export;Integrated Security=True");
            try
            {
                if (comboBox1.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Pleas Connect The Database");
                    return;

                }
                // con = new SqlConnection(con);
                con.Open();
                sql = "BACKUP DATABASE " + comboBox1.Text + " TO DISK='" + txtlocation.Text + "\\" + comboBox1.Text + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Backup Completed");

                con.Close();
                con.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnbrows2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup Files(.bak)|*.bak|All Files(*.*)|*.*";
            dlg.FilterIndex = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtpath.Text = dlg.FileName;

            }
        }

        private void btnrestore_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=Export;Integrated Security=True");
            string database = con.Database.ToString();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                string sqlStmt2 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                bu2.ExecuteNonQuery();

                string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + txtpath.Text + "'WITH REPLACE;";
                SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                bu3.ExecuteNonQuery();

                string sqlStmt4 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                bu4.ExecuteNonQuery();

                MessageBox.Show("database restoration done successefully");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
    }
}
