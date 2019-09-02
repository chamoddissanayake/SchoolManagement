using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class UpdatePassword : Form
    {
        string conString = CommonConstants.connnectionString;
        string foundEmail, foundNic, foundPhone;

        public UpdatePassword()
        {
            InitializeComponent();
        }


        private void UpdatePassword_Load(object sender, EventArgs e)
        {
            userType.SelectedIndex = 0;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            txtNic.Visible = false;
            txtPhone.Visible = false;
            txtEmail.Visible = false;
            submitDetails.Visible = false;


            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            txtPassword.Visible = false;
            txtRePassword.Visible = false;
            button1.Visible = false;

        }

        private void userType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void submitDetails_Click(object sender, EventArgs e)
        {
            if (txtNic.Text == "" || txtPhone.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
            }else
            {
                if(txtNic.Text.Equals(foundNic) || txtPhone.Text.Equals(foundPhone) || txtEmail.Text.Equals(foundEmail))
                {

                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    txtPassword.Visible = true;
                    txtRePassword.Visible = true;
                    button1.Visible = true;

                    MessageBox.Show("Your details are correct. Now Add a new password.");
                }else
                {
                    MessageBox.Show("Your details are incorrect.");
                }
            }
            

                
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if(txtPassword.Text =="" || txtRePassword.Text == "")
            {
                MessageBox.Show("Please enter new password and enter it again.");
            }else if (!(txtPassword.Text.Equals(txtRePassword.Text)))
            {
                MessageBox.Show("Passwords are not equal.");
            }else
            {
                //txtPassword.Text;
                //txtRePassword.Text;
                string saltpwd =  PasswordUtil.getSalt(30);
                string secpwd = PasswordUtil.generateSecurePassword(txtPassword.Text, saltpwd);
                string typeString = userType.SelectedItem.ToString();

                using (SqlConnection connection = new SqlConnection(conString))
                {
                    //try{
                        connection.Open();
                        SqlCommand command = new SqlCommand(null, connection);

                        /*
                        UPDATE Academic_Staff_Credentials
                        SET password = 'ppp', salt = 'sss'
                        WHERE stfID = 'iii';
                        */


                        if (typeString.Equals("Academic Staff"))
                        {
                            command.CommandText = "UPDATE Academic_Staff_Credentials SET password = @secPassword, salt = @saltPassword WHERE stfID = @stfID";
                        }
                        else if (typeString.Equals("Non Academic Staff"))
                        {
                            command.CommandText = "UPDATE Non_Academic_Staff_Credentials SET password = @secPassword, salt = @saltPassword WHERE stfID = @stfID";
                        }
                        else if (typeString.Equals("Administrative Staff"))
                        {
                            command.CommandText = "UPDATE Administrative_Staff_credentials SET password = @secPassword, salt = @saltPassword WHERE stfID = @stfID";
                        }
                        
                        SqlParameter secPassword = new SqlParameter("@secPassword", SqlDbType.VarChar, 100);
                        secPassword.Value = secpwd;
                        command.Parameters.Add(secPassword);

                        SqlParameter saltPassword = new SqlParameter("@saltPassword", SqlDbType.VarChar, 100);
                        saltPassword.Value = saltpwd;
                        command.Parameters.Add(saltPassword);

                        SqlParameter stfID = new SqlParameter("@stfID", SqlDbType.VarChar, 100);
                        stfID.Value = usernameString;
                        command.Parameters.Add(stfID);

                        // Call Prepare after setting the Commandtext and Parameters.
                        command.Prepare();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Password updated successfully. Now use your new password to login to the system.");
                    //}
                    //catch(Exception ex) {
                    //    MessageBox.Show(ex+"Error occured.");
                    //} finally {
                    //    connection.Close();
                    //}    
                }
                
            }
        }
        string usernameString;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User userObj= null;

            string typeString = userType.SelectedItem.ToString();
             usernameString = txtUsername.Text;
            if (typeString == "" || usernameString == "")
            {
                MessageBox.Show("Please fill your Username and select UserType");
            }else
            {
                //Check username in the staff table
                User userObject = new User();
                userObject = checkDetailsAreCorrect(usernameString);
                if(userObject != null)
                {
                    //found
                    String userID = userObject.getuserID();
                    foundNic = userObject.Nic;
                    foundPhone = userObject.Phone;
                    foundEmail = userObject.Email;

                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    txtNic.Visible = true;
                    txtPhone.Visible = true;
                    txtEmail.Visible = true;
                    submitDetails.Visible = true;

                    MessageBox.Show("Your ID was found. Please fill fill following details to confirm you.");

                }
                else
                {
                    MessageBox.Show("User id not found.");
                }
            }
        }

        private User checkDetailsAreCorrect(string usernameString)
        {
            bool found = false;
            User userobj = new User();
            
            //Check in db start
           
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                SELECT *
                FROM Staff
                WHERE stfID = 'STF001' 
                */

                command.CommandText = "SELECT * FROM Staff WHERE stfID = @stfID ";

                SqlParameter stfID = new SqlParameter("@stfID", SqlDbType.VarChar, 100);
                stfID.Value = usernameString;
                command.Parameters.Add(stfID);
                
                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();
                string strNic="", strPhone="", strEmail="";
                
                while (reader.Read())
                {
                    found = true;
                    strNic = reader["NIC"].ToString();
                    strPhone = reader["phone"].ToString();
                    strEmail = reader["email"].ToString();
                }
                userobj.Nic = strNic;
                userobj.Phone = strPhone;
                userobj.Email = strEmail;

                

                connection.Close();
            }
            if (found == true)
            {
                return userobj;
            }else
            {
                userobj = null;
                return userobj;
            }
            //Check in db end
        }
    }
}
