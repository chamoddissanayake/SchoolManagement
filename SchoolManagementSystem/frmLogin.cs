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
            }else if (txtUsername.Text ==""){
                MessageBox.Show("Please enter password");
            }else if (userType.Text == ""){
                MessageBox.Show("Please select usertype");
            }else{
                

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
                                        u.setuserID(userID_from_db);

                                        //Track Login - Start
                                        TrackLogin("Academic Staff", connection, userID_from_db, conString);
                                        //Track Login - End

                                        UserSessionStore.Instance.setUser(u);
                                        AcademicStaffDashBoard objAcdStfDashBoard = new AcademicStaffDashBoard();
                                        this.Hide();
                                        objAcdStfDashBoard.Show();

                                }else{
                                        MessageBox.Show("Your password is incorrect.");
                                }
                            }  else {
                                MessageBox.Show("Your Username or password not found.");
                            }
                        connection.Close();              
                        }
                    
                        

                }else if (userType.Text.Equals("Administrative Staff")) {

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
                                u.setuserID(userID_from_db);

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
                else if (userType.Text.Equals("Admin")){

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
                else if (userType.Text.Equals("Non Academic Staff")){

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
                                u.setuserID(userID_from_db);

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

        private void TrackLogin(String userType, SqlConnection connection, String userID, String conString)
        {
            if (userType.Equals("Academic Staff")){

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
                        description.Value = userID + " logged in at "+now;
                        loginTrackCommand.Parameters.Add(description);


                        // Call Prepare after setting the Commandtext and Parameters.
                         loginTrackCommand.Prepare();
                        loginTrackCommand.ExecuteNonQuery();

                        conn.Close();
                    }

            }
            else if (userType.Equals("Administrative Staff")){
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
            else if (userType.Equals("Admin")){
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
            else if (userType.Equals("Non Academic Staff")){
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
    }
}
