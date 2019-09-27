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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {

            InitializeComponent();
            userType.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Please enter username");
            } else if (txtUsername.Text == "") {
                MessageBox.Show("Please enter password");
            } else if (userType.Text == "") {
                MessageBox.Show("Please select usertype");
            } else {


                string conString = CommonConstants.connnectionString;
                if (userType.Text.Equals("Academic Staff"))
                {

                    using (SqlConnection connection = new SqlConnection(conString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(null, connection);


                        command.CommandText = "SELECT * FROM Academic_Staff_Credentials WHERE stfID = @stfID ";

                        SqlParameter stfID = new SqlParameter("@stfID", SqlDbType.VarChar, 100);
                        stfID.Value = txtUsername.Text;
                        command.Parameters.Add(stfID);


                        // Call Prepare after setting the Commandtext and Parameters.
                        command.Prepare();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            String secured_pwd_from_db = reader["password"].ToString();
                            String salt_from_db = reader["salt"].ToString();

                            String userID_from_db = reader["stfID"].ToString();

                            if (PasswordUtil.verifyUserPassword(txtPassword.Text, secured_pwd_from_db, salt_from_db)) {
                                User u = new User();
                                //populate u 
                                //u.setuserID(userID_from_db);
                                u = getAcademicStaffObjectWithAllProperties(userID_from_db);

                                //Track Login - Start
                                TrackLogin("Academic Staff", connection, userID_from_db, conString);
                                //Track Login - End

                                UserSessionStore.Instance.setUser(u);
                                AcademicStaffDashBoard objAcdStfDashBoard = new AcademicStaffDashBoard();
                                this.Hide();
                                objAcdStfDashBoard.Show();

                            } else {
                                MessageBox.Show("Your password is incorrect.");
                            }
                        } else {
                            MessageBox.Show("Your Username or password not found.");
                        }
                        connection.Close();
                    }



                } else if (userType.Text.Equals("Administrative Staff")) {

                    using (SqlConnection connection = new SqlConnection(conString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(null, connection);

                        command.CommandText = "SELECT * FROM Administrative_Staff_credentials WHERE stfID = @stfID ";

                        SqlParameter stfID = new SqlParameter("@stfID", SqlDbType.VarChar, 100);
                        stfID.Value = txtUsername.Text;
                        command.Parameters.Add(stfID);


                        // Call Prepare after setting the Commandtext and Parameters.
                        command.Prepare();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            String secured_pwd_from_db = reader["password"].ToString();
                            String salt_from_db = reader["salt"].ToString();

                            String userID_from_db = reader["stfID"].ToString();

                            if (PasswordUtil.verifyUserPassword(txtPassword.Text, secured_pwd_from_db, salt_from_db))
                            {
                                User u = new User();
                                //populate u 
                                //u.setuserID(userID_from_db);
                                u = getAdministrativeStaffObjectWithAllProperties(userID_from_db);

                                //Track Login - Start
                                TrackLogin("Administrative Staff", connection, userID_from_db, conString);
                                //Track Login - End

                                UserSessionStore.Instance.setUser(u);
                                AdministrativeStaffDashboard objAdmStfDashBoard = new AdministrativeStaffDashboard();
                                this.Hide();
                                objAdmStfDashBoard.Show();
                            }
                            else
                            {
                                MessageBox.Show("Your password is incorrect.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Your Username or password not found.");
                        }
                        connection.Close();
                    }
                }
                else if (userType.Text.Equals("Admin")) {

                    using (SqlConnection connection = new SqlConnection(conString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(null, connection);

                        command.CommandText = "SELECT * FROM Admin_credentials WHERE adminID = @adminID ";

                        SqlParameter adminID = new SqlParameter("@adminID", SqlDbType.VarChar, 100);
                        adminID.Value = txtUsername.Text;
                        command.Parameters.Add(adminID);


                        // Call Prepare after setting the Commandtext and Parameters.
                        command.Prepare();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            String secured_pwd_from_db = reader["password"].ToString();
                            String salt_from_db = reader["salt"].ToString();

                            String userID_from_db = reader["adminID"].ToString();

                            if (PasswordUtil.verifyUserPassword(txtPassword.Text, secured_pwd_from_db, salt_from_db))
                            {
                                User u = new User();
                                //populate u 
                                u.setuserID(userID_from_db);
                                u.Type = "Admin";

                                //Track Login - Start
                                TrackLogin("Admin", connection, userID_from_db, conString);
                                //Track Login - End

                                UserSessionStore.Instance.setUser(u);

                                AdminDashboard objAdminDashboard = new AdminDashboard();
                                this.Hide();
                                objAdminDashboard.Show();

                            }
                            else
                            {
                                MessageBox.Show("Your password is incorrect.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Your Username or password not found.");
                        }
                        connection.Close();
                    }


                }
                else if (userType.Text.Equals("Non Academic Staff")) {

                    using (SqlConnection connection = new SqlConnection(conString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(null, connection);

                        command.CommandText = "SELECT * FROM Non_Academic_Staff_Credentials WHERE stfID = @stfID ";

                        SqlParameter stfID = new SqlParameter("@stfID", SqlDbType.VarChar, 100);
                        stfID.Value = txtUsername.Text;
                        command.Parameters.Add(stfID);


                        // Call Prepare after setting the Commandtext and Parameters.
                        command.Prepare();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            String secured_pwd_from_db = reader["password"].ToString();
                            String salt_from_db = reader["salt"].ToString();

                            String userID_from_db = reader["stfID"].ToString();

                            if (PasswordUtil.verifyUserPassword(txtPassword.Text, secured_pwd_from_db, salt_from_db))
                            {
                                User u = new User();
                                //populate u 
                                //u.setuserID(userID_from_db);
                                u = getNonAcademicStaffObjectWithAllProperties(userID_from_db);

                                //Track Login - Start
                                TrackLogin("Non Academic Staff", connection, userID_from_db, conString);
                                //Track Login - End

                                UserSessionStore.Instance.setUser(u);

                                NonAcademicStaffDashboard objNonAcdStfDashboard = new NonAcademicStaffDashboard();
                                this.Hide();
                                objNonAcdStfDashboard.Show();
                            }
                            else
                            {
                                MessageBox.Show("Your password is incorrect.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Your Username or password not found.");
                        }
                        connection.Close();
                    }


                }
                else
                {
                    MessageBox.Show("Unknown user type!!!");
                }


                //Login validation end
            }
        }

        private User getNonAcademicStaffObjectWithAllProperties(string userID)
        {
            User nonAcdStfObj = new User();
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);


                command.CommandText = "SELECT * FROM Staff, Non_Academic_Staff WHERE Staff.stfID = Non_Academic_Staff.stfID AND Staff.stfID = @stfID ";

                SqlParameter stfID = new SqlParameter("@stfID", SqlDbType.VarChar, 100);
                stfID.Value = userID;
                command.Parameters.Add(stfID);

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    String userID_from_db = reader["stfID"].ToString();
                    String phone_from_db = reader["phone"].ToString();
                    String fname_from_db = reader["fName"].ToString();
                    String lname_from_db = reader["lName"].ToString();
                    String email_from_db = reader["email"].ToString();
                    String nic_from_db = reader["NIC"].ToString();
                    String appointeddate_from_db = reader["appointedDate"].ToString();
                    String joineddate_from_db = reader["joinedDate"].ToString();
                    String qualification_from_db = reader["qualification"].ToString();
                    String gender_from_db = reader["gender"].ToString();
                    String dob_from_db = reader["dob"].ToString();
                    String experience_from_db = reader["experience"].ToString();


                    nonAcdStfObj.setuserID(userID_from_db);
                    nonAcdStfObj.Type = "Non_Academic_Staff";
                    nonAcdStfObj.Phone = phone_from_db;
                    nonAcdStfObj.Fname = fname_from_db;
                    nonAcdStfObj.Lname = lname_from_db;
                    nonAcdStfObj.Email = email_from_db;
                    nonAcdStfObj.Nic = nic_from_db;
                    nonAcdStfObj.Appointeddate = appointeddate_from_db;
                    nonAcdStfObj.Joineddate = joineddate_from_db;
                    nonAcdStfObj.Qualification = qualification_from_db;
                    nonAcdStfObj.Gender = gender_from_db;
                    nonAcdStfObj.Dob = dob_from_db;

                    nonAcdStfObj.Experience = experience_from_db;
                    return nonAcdStfObj;
                }

                connection.Close();
            }

            return nonAcdStfObj;
        }

        private User getAdministrativeStaffObjectWithAllProperties(string userID)
        {
            User admStfObj = new User();
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);


                command.CommandText = "SELECT * FROM Staff, Administrative_Staff WHERE Staff.stfID = Administrative_Staff.stfID AND Staff.stfID = @stfID ";

                SqlParameter stfID = new SqlParameter("@stfID", SqlDbType.VarChar, 100);
                stfID.Value = userID;
                command.Parameters.Add(stfID);


                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    String userID_from_db = reader["stfID"].ToString();
                    String phone_from_db = reader["phone"].ToString();
                    String fname_from_db = reader["fName"].ToString();
                    String lname_from_db = reader["lName"].ToString();
                    String email_from_db = reader["email"].ToString();
                    String nic_from_db = reader["NIC"].ToString();
                    String appointeddate_from_db = reader["appointedDate"].ToString();
                    String joineddate_from_db = reader["joinedDate"].ToString();
                    String qualification_from_db = reader["qualification"].ToString();
                    String gender_from_db = reader["gender"].ToString();
                    String dob_from_db = reader["dob"].ToString();
                    String designation_from_db = reader["designation"].ToString();

                    admStfObj.setuserID(userID_from_db);
                    admStfObj.Type = "Administrative_Staff";
                    admStfObj.Phone = phone_from_db;
                    admStfObj.Fname = fname_from_db;
                    admStfObj.Lname = lname_from_db;
                    admStfObj.Email = email_from_db;
                    admStfObj.Nic = nic_from_db;
                    admStfObj.Appointeddate = appointeddate_from_db;
                    admStfObj.Joineddate = joineddate_from_db;
                    admStfObj.Qualification = qualification_from_db;
                    admStfObj.Gender = gender_from_db;
                    admStfObj.Dob = dob_from_db;

                    admStfObj.Designation = designation_from_db;
                    return admStfObj;
                }

                connection.Close();
            }

            return admStfObj;
        }

        private User getAcademicStaffObjectWithAllProperties(String userID)
        {
            User acadObj = new User();
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);


                command.CommandText = "SELECT * FROM Staff, Academic_Staff WHERE Staff.stfID = Academic_Staff.stfID AND Staff.stfID = @stfID ";

                SqlParameter stfID = new SqlParameter("@stfID", SqlDbType.VarChar, 100);
                stfID.Value = userID;
                command.Parameters.Add(stfID);


                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    String userID_from_db = reader["stfID"].ToString();
                    String phone_from_db = reader["phone"].ToString();
                    String fname_from_db = reader["fName"].ToString();
                    String lname_from_db = reader["lName"].ToString();
                    String email_from_db = reader["email"].ToString();
                    String nic_from_db = reader["NIC"].ToString();
                    String appointeddate_from_db = reader["appointedDate"].ToString();
                    String joineddate_from_db = reader["joinedDate"].ToString();
                    String qualification_from_db = reader["qualification"].ToString();
                    String gender_from_db = reader["gender"].ToString();
                    String dob_from_db = reader["dob"].ToString();
                    String specializedSubject_from_db = reader["specializedSubject"].ToString();

                    acadObj.setuserID(userID_from_db);
                    acadObj.Type = "Academic_Staff";
                    acadObj.Phone = phone_from_db;
                    acadObj.Fname = fname_from_db;
                    acadObj.Lname = lname_from_db;
                    acadObj.Email = email_from_db;
                    acadObj.Nic = nic_from_db;
                    acadObj.Appointeddate = appointeddate_from_db;
                    acadObj.Joineddate = joineddate_from_db;
                    acadObj.Qualification = qualification_from_db;
                    acadObj.Gender = gender_from_db;
                    acadObj.Dob = dob_from_db;

                    acadObj.Specializedsubject = specializedSubject_from_db;

                    return acadObj;
                }

                connection.Close();
            }


            return acadObj;

        }

        private void TrackLogin(String userType, SqlConnection connection, String userID, String conString)
        {
            if (userType.Equals("Academic Staff")) {

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();

                    SqlCommand loginTrackCommand = new SqlCommand(null, conn);

                    loginTrackCommand.CommandText = "INSERT INTO LoginTrack VALUES(@uType, @description)";

                    SqlParameter uType = new SqlParameter("@uType", SqlDbType.VarChar, 100);
                    uType.Value = userType;
                    loginTrackCommand.Parameters.Add(uType);

                    SqlParameter description = new SqlParameter("@description", SqlDbType.VarChar, 500);
                    DateTime now = DateTime.Now;
                    description.Value = userID + " logged in at " + now;
                    loginTrackCommand.Parameters.Add(description);


                    // Call Prepare after setting the Commandtext and Parameters.
                    loginTrackCommand.Prepare();
                    loginTrackCommand.ExecuteNonQuery();

                    conn.Close();
                }

            }
            else if (userType.Equals("Administrative Staff")) {
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();

                    SqlCommand loginTrackCommand = new SqlCommand(null, conn);

                    loginTrackCommand.CommandText = "INSERT INTO LoginTrack VALUES(@uType, @description)";

                    SqlParameter uType = new SqlParameter("@uType", SqlDbType.VarChar, 100);
                    uType.Value = userType;
                    loginTrackCommand.Parameters.Add(uType);

                    SqlParameter description = new SqlParameter("@description", SqlDbType.VarChar, 500);
                    DateTime now = DateTime.Now;
                    description.Value = userID + " logged in at " + now;
                    loginTrackCommand.Parameters.Add(description);


                    // Call Prepare after setting the Commandtext and Parameters.
                    loginTrackCommand.Prepare();
                    loginTrackCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            else if (userType.Equals("Admin")) {
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();

                    SqlCommand loginTrackCommand = new SqlCommand(null, conn);

                    loginTrackCommand.CommandText = "INSERT INTO LoginTrack VALUES(@uType, @description)";

                    SqlParameter uType = new SqlParameter("@uType", SqlDbType.VarChar, 100);
                    uType.Value = userType;
                    loginTrackCommand.Parameters.Add(uType);

                    SqlParameter description = new SqlParameter("@description", SqlDbType.VarChar, 500);
                    DateTime now = DateTime.Now;
                    description.Value = userID + " logged in at " + now;
                    loginTrackCommand.Parameters.Add(description);


                    // Call Prepare after setting the Commandtext and Parameters.
                    loginTrackCommand.Prepare();
                    loginTrackCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }
            else if (userType.Equals("Non Academic Staff")) {
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();

                    SqlCommand loginTrackCommand = new SqlCommand(null, conn);

                    loginTrackCommand.CommandText = "INSERT INTO LoginTrack VALUES(@uType, @description)";

                    SqlParameter uType = new SqlParameter("@uType", SqlDbType.VarChar, 100);
                    uType.Value = userType;
                    loginTrackCommand.Parameters.Add(uType);

                    SqlParameter description = new SqlParameter("@description", SqlDbType.VarChar, 500);
                    DateTime now = DateTime.Now;
                    description.Value = userID + " logged in at " + now;
                    loginTrackCommand.Parameters.Add(description);


                    // Call Prepare after setting the Commandtext and Parameters.
                    loginTrackCommand.Prepare();
                    loginTrackCommand.ExecuteNonQuery();

                    conn.Close();
                }
            }



        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Select();
            }

        }

        private void userType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtUsername.Select();
        }

        private void passwordMissing_Click(object sender, EventArgs e)
        {

            UpdatePassword obj = new UpdatePassword();
            obj.Show();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
