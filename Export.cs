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
    public partial class Export : Form
    {
        string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Export;Integrated Security=True";

        public Export()
        {
            InitializeComponent();
        }

        private void orderid()
        {
            int r;
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                string Query = "SELECT max(exp_ID) FROM Expo_Details";

                SqlCommand cmdd = new SqlCommand(Query, conn);
                SqlDataReader Myreader = cmdd.ExecuteReader();

                if (Myreader.Read())
                {
                    string d = Myreader[0].ToString();
                    if (d == "")
                    {
                        lblprch.Text = "3001";

                    }
                    else
                    {
                        r = Convert.ToInt32(Myreader[0].ToString());
                        r = r + 1;
                        lblprch.Text = r.ToString();

                    }
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Export_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exportDataSet3.product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.exportDataSet3.product);
            // TODO: This line of code loads data into the 'exportDataSet4.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.exportDataSet4.customer);
            tabControl1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
           
            orderid();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            tabControl1.SelectedIndex = 0;
            searchbydate();
        }

        private void search()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlDa = new SqlCommand("SELECT * FROM product WHERE proid='" + comboBox2.SelectedValue + "'", sqlCon);
                SqlDataReader DR1 = sqlDa.ExecuteReader();
                if (DR1.Read())
                {
                    lblbprice.Text = DR1.GetValue(4).ToString();
                    lblPid.Text = DR1.GetValue(1).ToString();
                    lblavlqty.Text = DR1.GetValue(5).ToString();
                }
                sqlCon.Close();
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
            button3.Enabled = true;
        }


        int price = 0;
        private void grdadd()
        {
            price = Convert.ToInt32(textBox1.Text) * Convert.ToInt32(lblbprice.Text);
            dataGridView1.Rows.Add(lblprch.Text, comboBox1.SelectedValue, comboBox2.SelectedValue, comboBox2.Text, textBox1.Text, lblbprice.Text, price.ToString());
            int avlqty = 0;

            avlqty = Convert.ToInt32(lblavlqty.Text) - Convert.ToInt32(textBox1.Text);
            lblavlqty.Text = avlqty.ToString();
            int sum = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                sum += Convert.ToInt32(item.Cells[6].Value);
                lblttlamt.Text = sum.ToString();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            grdadd();
            puech_det();
            qtyupd();
            button4.Enabled = true;
            button6.Enabled = false;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                button6.Enabled = true;
                comboBox1.SelectedValue = row.Cells[1].Value.ToString();
                comboBox2.SelectedValue = row.Cells[2].Value.ToString();
                textBox1.Text = row.Cells[4].Value.ToString();
                lblPid.Text = row.Cells[2].Value.ToString();
                lblbprice.Text = row.Cells[5].Value.ToString();


            }
        }

        private void puech_det()
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "INSERT INTO Expo_Details (exp_ID,Cus_ID,pro_id,Proname,P_Qty,U_price,p_tot) VALUES (@purch_ID,@Sup_ID,@pro_id,@Proname,@P_Qty,@U_price,@p_tot)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@purch_ID", lblprch.Text);
                    sqlCmd.Parameters.AddWithValue("@Sup_ID", comboBox1.SelectedValue);
                    sqlCmd.Parameters.AddWithValue("@pro_id", comboBox2.SelectedValue);
                    sqlCmd.Parameters.AddWithValue("@Proname", comboBox2.Text);
                    sqlCmd.Parameters.AddWithValue("@P_Qty", textBox1.Text);
                    sqlCmd.Parameters.AddWithValue("@U_price", lblbprice.Text);
                    sqlCmd.Parameters.AddWithValue("@p_tot", price.ToString());
                    sqlCmd.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void puech_det_del()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Expo_Details WHERE exp_ID = @id and pro_id=@pro_id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", lblprch.Text);
                    sqlCmd.Parameters.AddWithValue("@pro_id", comboBox2.SelectedValue);
                    sqlCmd.ExecuteNonQuery();
                    search();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void qtyupd()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE product SET avqty=@avqty WHERE proid = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@avqty", lblavlqty.Text);

                    sqlCmd.Parameters.AddWithValue("@id", lblPid.Text);
                    sqlCmd.ExecuteNonQuery();
                    search();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(row.Index);
            }

            int avlqty = 0;
            avlqty = Convert.ToInt32(lblavlqty.Text) + Convert.ToInt32(textBox1.Text);
            lblavlqty.Text = avlqty.ToString();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                sum -= Convert.ToInt32(item.Cells[6].Value);
                lblttlamt.Text = Math.Abs(sum).ToString();
            }
            qtyupd();
            puech_det_del();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "INSERT INTO Export (Expd_id,cus_id,date,total,Status) VALUES (@purch_ID,@sup_id,@date,@total,@Status)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@purch_ID", lblprch.Text);
                    sqlCmd.Parameters.AddWithValue("@sup_id", comboBox1.SelectedValue);
                    sqlCmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString("dd/MM/yyyy"));
                    sqlCmd.Parameters.AddWithValue("@total", lblttlamt.Text);
                    sqlCmd.Parameters.AddWithValue("@Status", comboBox3.Text);

                    sqlCmd.ExecuteNonQuery();

                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchbydate()
        {

            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Export", sqlCon);
                sqlDa.Fill(dtbl);
                dataGridView2.DataSource = dtbl;
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];




                DataTable dtbl = new DataTable();
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Expo_Details WHERE exp_ID = '" + row.Cells[1].Value.ToString() + "'", sqlCon);
                    sqlDa.Fill(dtbl);
                    dataGridView3.DataSource = dtbl;
                }


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Export WHERE date between '" + dateTimePicker2.Value.ToString("dd/MM/yyyy") + "' AND '" + dateTimePicker3.Value.ToString("dd/MM/yyyy") + "'", sqlCon);
                sqlDa.Fill(dtbl);
                dataGridView2.DataSource = dtbl;
            }
        }
    }
}
