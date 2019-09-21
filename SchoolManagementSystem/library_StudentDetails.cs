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
    
    public partial class library_StudentDetails : Form
    {
        public string constring = "Data Source=DESKTOP-83SSJ0U;Initial Catalog=ConnectionDb;Integrated Security=True ";

        SqlConnection con = new SqlConnection(CommonConstants.connnectionString);
        public library_StudentDetails()
        {
            InitializeComponent();
        }
     

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Need Student ID for Register as a library member.");
            }else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Library_Member_Student values('" + textBox1.Text + "' )";
                    cmd.ExecuteNonQuery();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                    MessageBox.Show("Student details added succesfully");
                }
                catch(Exception exce)
                {
                    MessageBox.Show("Error: " + exce);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
      
                display();
            }
            
        }
        public void display()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select s.sID, s.fName,s.mName, s.lName, s.tel, s.email from Student s , Library_Member_Student lm where s.sID = lm.sid";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc);
            }
            finally
            {
                con.Close();
            }
        }



        User u;
        private void StudentDetails_Load(object sender, EventArgs e)
        {
            u = UserSessionStore.Instance.getUser();

            display();
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;

            btnDelete.Visible = false;

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Library> Student Details>";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Library> Student Details>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Library> Student Details>";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Library> Student Details>";
            }
            else
            {
                lblPath.Text = "";
            }
        }
   
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                // cmd.CommandText = "select * from Student_details where admissionNo  = '" + textBox4.Text + "'";
                cmd.CommandText = "SELECT s.sID , s.fName, s.mName, s.lName, s.tel,s.email FROM Student s, Library_Member_Student lms WHERE s.sID = lms.sid and s.sID like '%" + textBox4.Text + "%'";


                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            finally
            {
                con.Close();
            }
        }

        String StudentIDForDelete;

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnDelete.Visible = true;

            StudentIDForDelete = dataGridView1.CurrentRow.Cells[0].Value.ToString();
     
            btnDelete.Text = "Remove " + StudentIDForDelete;

            
      
        }

        private void deleteCurrentStudent(string studentID)
        {
            try
            {
                con.Open();
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandText = "Delete from Library_Member_Student where sid  = '" + studentID + "'" ;
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Removed Library Membership successfully.");
                btnDelete.Visible = false;
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Error: " + ex1);
                btnDelete.Visible = false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            LibraryDashBoard LibDashObj = new LibraryDashBoard();
            LibDashObj.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "select fName, tel from Student where sID  = '" + textBox1.Text + "'";

                /*
                SELECT DISTINCT Student.sID, Library_Member_Student.sid AS 'SSID' , Student.fName, Student.tel
                FROM Library_Member_Student
                RIGHT  JOIN Student
                ON Student.sID = Library_Member_Student.sid
                WHERE Student.sID = 'S00011'
                GROUP BY Student.sID , Student.fName, Student.tel, Library_Member_Student.sid
                HAVING Library_Member_Student.sid is NULL
                */

                cmd.CommandText = "SELECT DISTINCT Student.sID, Library_Member_Student.sid AS 'SSID' , Student.fName, Student.tel FROM Library_Member_Student RIGHT JOIN Student ON Student.sID = Library_Member_Student.sid  WHERE Student.sID = '" + textBox1.Text + "' GROUP BY Student.sID , Student.fName, Student.tel, Library_Member_Student.sid   HAVING Library_Member_Student.sid is NULL";

                //  cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();
                string name = "", tel = "";
                int counter = 0;
                while (reader.Read())
                {
                    name = (string)(reader[2]);
                    tel = (string)(reader[3]);
                    counter++;
                }

                if (counter == 0)
                {
                    MessageBox.Show("Not a valid student Number or Already a library member.");
                }

                textBox2.Text = name;
                textBox3.Text = tel;

                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: "+ exc);
            }
            finally
            {
                if(con.State == ConnectionState.Open)
                    con.Close();
            }
        
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteCurrentStudent(StudentIDForDelete);
        }

        private void library_StudentDetails_MouseClick(object sender, MouseEventArgs e)
        {
            btnDelete.Visible = false;
        }
    }
}
