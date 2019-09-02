using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    
    public partial class Administrative_Staff_Account : Form
    {
        User u;
        SqlConnection sqlCon = new SqlConnection(CommonConstants.connnectionString);

        public Administrative_Staff_Account()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            string stfID = txtStfId.Text;
            string fName = txtFName.Text;
            string lName = txtLName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string nic = txtNIC.Text;
            string qualification = txtQualification.Text;
            string designation = txtDesignation.Text;
            string dob = dobPicker.Value.ToShortDateString();
            string appdate = appdatePicker.Value.ToShortDateString();
            string jdate = jDatePicker.Value.ToShortDateString();
            string gender = "";

            if (rBtnMale.Checked)
            {
                gender = "M";
            }
            else if (rBtnFemale.Checked)
            {
                gender = "F";
            }

            if (!(stfID == "" || fName == "" || lName == "" || email == "" || phone == "" || nic == "" || qualification == "" || designation == "" ||
                dob == "" || appdate == "" || jdate == "" || gender == ""))
            {
                try
                {
                    sqlCon.Open();

                    SqlCommand cmd1 = sqlCon.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "UPDATE Staff SET phone = '" + phone + "', fName = '" + fName + "', lName = '" + lName + "', email = '" + email + "', NIC = '" + nic + "', appointedDate = '" + appdate + "',joinedDate = '" + jdate + "', qualification = '" + qualification + "', gender = '" + gender + "', dob = '" + dob + "' WHERE stfID = '" + stfID + "'";
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = sqlCon.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "UPDATE Administrative_Staff SET designation = '" + designation + "' WHERE stfID = '" + stfID + "'";
                    cmd2.ExecuteNonQuery();
                    
                    MessageBox.Show("Updated Successfully");
                    
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Error: " + ex1);
                }
                finally
                {
                    sqlCon.Close();
                }
            }
            else
            {
                MessageBox.Show("All fields must be filled.");
            }  
        }

        private void backAA_Click(object sender, EventArgs e)
        {
            this.Close();
            AdministrativeStaffDashboard obj = new AdministrativeStaffDashboard();
            obj.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //DashboardStaff db = new DashboardStaff();
            //db.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

       
        private void fillData()
        {
            txtStfId.Text = u.getuserID();
            txtFName.Text = u.Fname;
            txtLName.Text = u.Lname;
            txtEmail.Text = u.Email;
            txtPhone.Text = u.Phone;
            txtNIC.Text = u.Nic;
            txtDesignation.Text = u.Designation;
            txtQualification.Text = u.Qualification;

            if (u.Gender == "M"){
                rBtnMale.Checked = true;
            }else if (u.Gender == "F"){
                rBtnFemale.Checked = true;
            }
            dobPicker.Text = u.Dob;
            appdatePicker.Text = u.Appointeddate;
            jDatePicker.Text = u.Joineddate;
            
        }

        private void Administrative_Staff_Account_Load(object sender, EventArgs e)
        {
            u = UserSessionStore.Instance.getUser();
            fillData();
            txtStfId.ReadOnly = true;

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> My Account>";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> My Account>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> My Account>";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> My Account>";
            }
            else
            {
                lblPath.Text = "";
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Staff_Email obj = new Staff_Email();
            obj.Show();
        }
    }
}
