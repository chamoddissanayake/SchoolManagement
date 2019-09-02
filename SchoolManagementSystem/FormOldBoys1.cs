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
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public partial class FormOldBoys1 : Form
    {

        // SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AsokaCollegeDB\School_DataBase.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection sqlCon = new SqlConnection(CommonConstants.connnectionString);


        int MembershipId = 0;
        public FormOldBoys1()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
               /* if (txtName.Text == "" || txtDOB.Text == "" || txtYear.Text == "" || txtAddress.Text == "" || txtMobileNumber.Text == "")
                {
                    MessageBox.Show("Please fill all feilds!");
                }*/

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                if (btnSave.Text == "Save")
                {
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    
                    cmd.CommandText = "INSERT INTO tbl_OldBoys2 VALUES('"+txtName.Text+"','"+txtDOB.Text+"',"+txtYear.Text+",'"+ txtAddress.Text+"',"+ txtMobileNumber.Text+")";
                    cmd.ExecuteNonQuery();

                    //SqlCommand sqlCmd = new SqlCommand("MemberAddOrEdit", sqlCon);
                    //sqlCmd.CommandType = CommandType.StoredProcedure;
                    //sqlCmd.Parameters.AddWithValue("@mode", "Add");
                    //sqlCmd.Parameters.AddWithValue("@MembershipID", 0);
                    //sqlCmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    //sqlCmd.Parameters.AddWithValue("@DOB", txtDOB.Text.Trim());
                    //sqlCmd.Parameters.AddWithValue("@Year", txtYear.Text.Trim());
                    //sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    //sqlCmd.Parameters.AddWithValue("@MobileNumber", txtMobileNumber.Text.Trim());
                    //sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Saved Successfully");
                }

                else
                {
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    //cmd.CommandText = "INSERT INTO tbl_OldBoys2 VALUES('" + txtName.Text + "','" + txtDOB.Text + "'," + txtYear.Text + ",'" + txtAddress.Text + "'," + txtMobileNumber.Text + ")";
                    cmd.CommandText = "Update tbl_OldBoys2 Set Name = '"+txtName.Text+"', DOB = '"+txtDOB.Text+"', year = "+txtYear.Text+", Address = '"+txtAddress.Text+"', MobileNumber = "+txtMobileNumber.Text+" WHERE MembershipID = "+MembershipId;

                    cmd.ExecuteNonQuery();

                    //SqlCommand sqlCmd = new SqlCommand("MemberAddOrEdit", sqlCon);
                    //sqlCmd.CommandType = CommandType.StoredProcedure;
                    //sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                    //sqlCmd.Parameters.AddWithValue("@MembershipID", MembershipId);
                    //sqlCmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    //sqlCmd.Parameters.AddWithValue("@DOB", txtDOB.Text.Trim());
                    //sqlCmd.Parameters.AddWithValue("@Year", txtYear.Text.Trim());
                    //sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    //sqlCmd.Parameters.AddWithValue("@MobileNumber", txtMobileNumber.Text.Trim());
                    //sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Edited Successfully");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                sqlCon.Close();
            }
            Reset();
            FillDataGridView();
        }
        void FillDataGridView()
        {
            sqlCon.Open();
            SqlCommand cmd = sqlCon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_OldBoys2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvMembers.DataSource = dt;
            sqlCon.Close();

            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();
            //SqlDataAdapter sqlDa = new SqlDataAdapter("MemberViewOrSearch", sqlCon);
            //sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlDa.SelectCommand.Parameters.AddWithValue("@MemberViewOrSearch", txtMemberName.Text.Trim());
            //DataTable dtbl = new DataTable();
            ////sqlDa.Fill(dtbl);
            //dgvMembers.DataSource = dtbl;
            //sqlCon.Close();

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Open();
                SqlCommand cmd = sqlCon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from tbl_OldBoys2 where name like('%" + txtMemberName.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgvMembers.DataSource = dt;
                //FillDataGridView();

                sqlCon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void DgvMembers_DoubleClick(object sender, EventArgs e)
        {
            if(dgvMembers.CurrentRow.Index != -1)
            {
                MembershipId = Convert.ToInt32(dgvMembers.CurrentRow.Cells[0].Value.ToString());
                txtName.Text = dgvMembers.CurrentRow.Cells[1].Value.ToString();
                txtDOB.Text = dgvMembers.CurrentRow.Cells[2].Value.ToString();
                txtYear.Text = dgvMembers.CurrentRow.Cells[3].Value.ToString();
                txtAddress.Text = dgvMembers.CurrentRow.Cells[4].Value.ToString();
                txtMobileNumber.Text = dgvMembers.CurrentRow.Cells[5].Value.ToString();
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
        }

        void Reset()
        {
            txtName.Text = txtDOB.Text = txtYear.Text = txtAddress.Text = txtMobileNumber.Text = "";
            btnSave.Text = "Save";
            MembershipId = 0;
            btnDelete.Enabled = false;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        User u;
        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
            FillDataGridView();


            u = UserSessionStore.Instance.getUser();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Old Boys Management>";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Old Boys Management>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Old Boys Management> ";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Old Boys Management> ";
            }
            else
            {
                lblPath.Text = "";
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Open();
                SqlCommand cmd = sqlCon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM tbl_OldBoys2 WHERE MembershipID = "+ MembershipId;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                Reset();
                
                sqlCon.Close();

                FillDataGridView();
                //if (sqlCon.State == ConnectionState.Closed)
                //    sqlCon.Open();
                //SqlCommand SqlCmd = new SqlCommand("MemberDeletion", sqlCon);
                //SqlCmd.CommandType = CommandType.StoredProcedure;
                //SqlCmd.Parameters.AddWithValue("@MembershipID", MembershipId);
                //SqlCmd.ExecuteNonQuery();
                //messagebox.show("deleted successfully");
                //reset();
                //filldatagridview();

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            oldboysemail ob1 = new oldboysemail();
            ob1.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (u.Type == "Admin")
            {
                this.Close();
                AdminDashboard obj = new AdminDashboard();
                obj.Show();
            }
            else if (u.Type == "Academic_Staff")
            {
                this.Close();
                AcademicStaffDashBoard obj = new AcademicStaffDashBoard();
                obj.Show();
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                this.Close();
                NonAcademicStaffDashboard obj = new NonAcademicStaffDashboard();
                obj.Show();
            }
            else if (u.Type == "Administrative_Staff")
            {
                this.Close();
                AdministrativeStaffDashboard obj = new AdministrativeStaffDashboard();
                obj.Show();
            }
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
