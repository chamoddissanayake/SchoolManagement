using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public partial class OldBoysPayment : Form
    {
        int type = 0;
        SqlConnection con = new SqlConnection(CommonConstants.connnectionString);

        public OldBoysPayment()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int temp;

            if (radiobtnMemfee.Checked == true)
            {
                type = 1;
            }
            else if (radiobtnDonation.Checked == true)
            {
                type = 2;
            }
            else if (radiobtnOther.Checked == true)
            {
                type = 3;
            }

            if (txtmemID.Text == ""|| txtmemName.Text==""|| txtAmount.Text=="")
            {
                MessageBox.Show("Please fill all fields.");
            }else if (!(int.TryParse(txtAmount.Text, out temp)))
            {
                MessageBox.Show("Amount must be a number");
            }else if (!(int.TryParse(txtmemID.Text, out temp)))
            {
                MessageBox.Show("Membership id must be a number");
            }

            else if (type == 0)
            {
                MessageBox.Show("Please select a payment type");
            }
           else
            {
                AddOldBoysPayments();
            }
        }

        private void AddOldBoysPayments()
        {


            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO Old_Boys_Payment VALUES(" + txtmemID.Text + ", '" + txtmemName.Text + "'," + txtAmount.Text + "," + type + ")";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added to the database successfully.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Membership id already in the database.");
                }else
                {
                    MessageBox.Show("Sql exception occured.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: "+ex);
            }
            finally
            {
                con.Close();
            }
           
            
            
        }
        User u;
        private void OldBoysPayment_Load(object sender, EventArgs e)
        {
            radiobtnMemfee.Checked = true;
            fillDatagridView();
            u = UserSessionStore.Instance.getUser();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Old Boys> Payment>";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Old Boys> Payment>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Old Boys> Payment>";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Old Boys> Payment>";
            }
            else
            {
                lblPath.Text = "";
            }
        }

        private void fillDatagridView()
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Old_Boys_Payment";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error occured."+ex);
            }
            finally
            {
                con.Close();
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchPaymentDetails();
        }

        private void searchPaymentDetails()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Old_Boys_Payment where name like '%" + txtSearch.Text + "%'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: "+ex);
            }
            finally
            {
                con.Close();
            }

           
        }

        private void backAE_Click(object sender, EventArgs e)
        {
            this.Close();
            OldBoysDashboard obdash = new OldBoysDashboard();
            obdash.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }
    }
}
