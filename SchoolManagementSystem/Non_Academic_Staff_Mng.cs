using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public partial class Non_Academic_Staff_Mng : Form
    {
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AsokaCollegeDB\School_DataBase.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection sqlCon = new SqlConnection(CommonConstants.connnectionString);

        int NonStaffId = 0;
        public Non_Academic_Staff_Mng()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string stfID = txtStfId.Text;
            string fName = txtFName.Text;
            string lName = txtLName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string nic = txtNIC.Text;
            string qualification = txtQualification.Text;
            string experience = txtExperience.Text;
            string dob = dobPicker.Value.ToShortDateString();
            string appdate = appdatePicker.Value.ToShortDateString();
            string jdate = jDatePicker.Value.ToShortDateString();
            string gender = "";
            string password = txtPassword.Text;
            if (rBtnMale.Checked)
            {
                gender = "M";
            }
            else if (rBtnFemale.Checked)
            {
                gender = "F";
            }

            if (!(stfID == "" || fName == "" || lName == "" || email == "" || phone == "" || nic == "" || qualification == "" || experience == "" ||
                dob == "" || appdate == "" || jdate == "" || gender == "" || password == ""))
            {
                try
                {
                    sqlCon.Open();

                    SqlCommand cmd1 = sqlCon.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "INSERT INTO Staff VALUES('" + stfID + "', '" + phone + "', '" + fName + "', '" + lName
                        + "','" + email + "','" + nic + "','" + appdate + "','" + jdate + "','" + qualification + "','" + gender + "','" + dob + "')";
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = sqlCon.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "INSERT INTO Non_Academic_Staff VALUES('" + stfID + "', '" + experience + "')";
                    cmd2.ExecuteNonQuery();

                    string saltpwd = PasswordUtil.getSalt(30);
                    string secpwd = PasswordUtil.generateSecurePassword(password, saltpwd);

                    SqlCommand cmd3 = sqlCon.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "INSERT INTO Non_Academic_Staff_Credentials VALUES('" + stfID + "','" + secpwd + "','" + saltpwd + "')";
                    cmd3.ExecuteNonQuery();

                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Error: " + ex1);
                }
                finally
                {
                    sqlCon.Close();
                }


                FillDataGridView();
                MessageBox.Show("Successfully Inserted!");
                clearDetails();
            }
            else
            {
                MessageBox.Show("All fields must be filled.");
            }
        }

        private void clearDetails()
        {
            txtStfId.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtNIC.Text = "";
            txtQualification.Text = "";
            txtExperience.Text = "";
            txtPassword.Text = "";

        }
        void FillDataGridView()
        {
            try
            {
                sqlCon.Open();
                SqlCommand cmd = sqlCon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Staff, Non_Academic_Staff WHERE Staff.stfID = Non_Academic_Staff.stfID";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch(Exception e2)
            {
                MessageBox.Show("Error: " + e2);
            }
            finally
            {
                sqlCon.Close();
            }
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
          
            if (dataGridView1.CurrentRow.Index != -1)
            {

                txtStfId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtPhone.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtFName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtLName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtNIC.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                appdatePicker.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                jDatePicker.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtQualification.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                String gender = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                if (gender == "M") { rBtnMale.Checked = true; } else if (gender == "F") { rBtnFemale.Checked = true; }
                dobPicker.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                txtExperience.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();

                txtStfId.ReadOnly = true;

            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string stfID = txtStfId.Text;
            if (!(stfID == ""))
            {
                try
                {
                    sqlCon.Open();

                    SqlCommand cmd1 = sqlCon.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "DELETE FROM Non_Academic_Staff_Credentials WHERE stfID = '" + stfID + "'";
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = sqlCon.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "DELETE FROM Non_Academic_Staff WHERE stfID = '" + stfID + "'";
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = sqlCon.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "DELETE FROM Staff WHERE stfID = '" + stfID + "'";
                    cmd3.ExecuteNonQuery();

                    MessageBox.Show("Successfully Deleted!");
                    clearDetails();

                }
                catch (Exception e1)
                {
                    MessageBox.Show("Error: " + e1);
                }
                finally
                {
                    sqlCon.Close();
                }
                FillDataGridView();
            }
            else
            {
                MessageBox.Show("Please select staff membe for delete.");
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            createDocument();
        }

        private void createDocument()
        {
            Document document = new Document();

            PdfWriter.GetInstance(document, new FileStream("F:/1.pdf", FileMode.Create));
            document.Open();

            Paragraph p = new Paragraph("abc");
            document.Add(p);

            document.Close();

            MessageBox.Show("Document Created.");
        }

        private void Non_Academic_Staff_Mng_Load(object sender, EventArgs e)
        {
            rBtnMale.Checked = true;
            FillDataGridView();

         
        }

        private void YOR2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radiButtMale2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtcont1_Click(object sender, EventArgs e)
        {

        }

        private void NIC2_TextChanged(object sender, EventArgs e)
        {

        }

        private void backNASM_Click(object sender, EventArgs e)
        {
            this.Close();
            sub_staff_dashboard nsdb = new sub_staff_dashboard();
            nsdb.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Dashboard db = new Dashboard();
            //db.Show();
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
            string experience = txtExperience.Text;
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

            if (!(stfID == "" || fName == "" || lName == "" || email == "" || phone == "" || nic == "" || qualification == "" || experience == "" ||
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
                    cmd2.CommandText = "UPDATE Non_Academic_Staff SET experience = '" + experience + "' WHERE stfID = '" + stfID + "'";
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Updated Successfully");
                    clearDetails();

                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Error: " + ex1);
                }
                finally
                {
                    sqlCon.Close();
                }


                FillDataGridView();

            }
            else
            {
                MessageBox.Show("All fields must be filled.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void Search2_TextChanged(object sender, EventArgs e)
        {
            specificSearch();
        }

        private void specificSearch()
        {
            try
            {
                sqlCon.Open();
                SqlCommand cmd = sqlCon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Staff, Non_Academic_Staff WHERE Staff.stfID = Non_Academic_Staff.stfID AND Staff.stfID LIKE '%" + Search2.Text + "%'";
                cmd.ExecuteNonQuery();


                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception e1)
            {
                MessageBox.Show("Error :" + e1);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
    

