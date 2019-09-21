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
    public partial class MemberDetails : Form
    {
        public string constring = "Data Source=DESKTOP-83SSJ0U;Initial Catalog=ConnectionDb;Integrated Security=True ";

        SqlConnection con = new SqlConnection(CommonConstants.connnectionString);
        //  SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AsokaCollegeDB\School_DataBase.mdf;Integrated Security=True;Connect Timeout=30");

        public MemberDetails()
        {
            InitializeComponent();
        }
        //add
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into  Library_Member_Staff values('" + sIDCombo.SelectedItem.ToString() + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Member Registered succesfully");
            }
            catch(Exception exc1)
            {
                MessageBox.Show("Error: "+exc1);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
                
            fillToDropDown();
            fillDataGridView();

        }


        User u;
        private void MemberDetails_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            u = UserSessionStore.Instance.getUser();

            fillToDropDown();
            fillDataGridView();

            btnDelete.Visible = false;

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Library> Member Details>";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Library> Member Details>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Library> Member Details>";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Library> Member Details>";
            }
            else
            {
                lblPath.Text = "";
            }
        }

        private void fillDataGridView()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                /*
                select s.stfID, s.fName, s.lName, s.phone, s.email
                from Staff s, Library_Member_Staff lm
                where s.stfID = lm.stfID
                */
                cmd.CommandText = "select s.stfID, s.fName, s.lName, s.phone, s.email from Staff s, Library_Member_Staff lm where s.stfID = lm.stfID";
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

        private void fillToDropDown()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select fName, tel from Student where sID  = '" + textBox1.Text + "'";

            /*
            SELECT DISTINCT Staff.stfID, Library_Member_Staff.stfID AS 'SSID' , Staff.fName , Staff.phone
            FROM Library_Member_Staff
            RIGHT  JOIN Staff
            ON Staff.stfID = Library_Member_Staff.stfID
            WHERE Staff.stfID = 'STF001'
            GROUP BY Staff.stfID , Staff.fName, Staff.phone, Library_Member_Staff.stfID
            HAVING Library_Member_Staff.stfID is NULL
            */

            cmd.CommandText = "SELECT DISTINCT Staff.stfID, Library_Member_Staff.stfID AS 'SSID' , Staff.fName , Staff.phone  FROM Library_Member_Staff  RIGHT JOIN Staff  ON Staff.stfID = Library_Member_Staff.stfID GROUP BY Staff.stfID , Staff.fName, Staff.phone, Library_Member_Staff.stfID HAVING Library_Member_Staff.stfID is NULL ";


            SqlDataReader reader = cmd.ExecuteReader();
            //string name = "", tel = "";
            String sid;
            sIDCombo.Items.Clear();
            while (reader.Read())
            {
                sid = (string)(reader[0]);
                sIDCombo.Items.Add(sid);
   
            }
            

            con.Close();
            sIDCombo.SelectedIndex = 0;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LibraryDashBoard ld1 = new LibraryDashBoard();
            ld1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }


        private void sIDCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDetailsOfSelected();
        }

        private void fillDetailsOfSelected()
        {

            string selectedID = sIDCombo.SelectedItem.ToString();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select fName, tel from Student where sID  = '" + textBox1.Text + "'";

            /*
            SELECT DISTINCT Staff.stfID, Library_Member_Staff.stfID AS 'SSID' , Staff.fName , Staff.phone
            FROM Library_Member_Staff
            RIGHT  JOIN Staff
            ON Staff.stfID = Library_Member_Staff.stfID
            WHERE Staff.stfID = 'STF001'
            GROUP BY Staff.stfID , Staff.fName, Staff.phone, Library_Member_Staff.stfID
            HAVING Library_Member_Staff.stfID is NULL
            */
            cmd.CommandText = "SELECT DISTINCT Staff.stfID, Library_Member_Staff.stfID AS 'SSID' , Staff.fName , Staff.phone  FROM Library_Member_Staff  RIGHT JOIN Staff  ON Staff.stfID = Library_Member_Staff.stfID   WHERE Staff.stfID = '" + selectedID + "'  GROUP BY Staff.stfID , Staff.fName, Staff.phone, Library_Member_Staff.stfID HAVING Library_Member_Staff.stfID is NULL ";


            SqlDataReader reader = cmd.ExecuteReader();
            string name = "", tel = "";
            while (reader.Read())
            {
                name = (string)(reader[2]);
                tel = (string)(reader[3]);
            }

            textBox2.Text = name;
            textBox3.Text = tel;

            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;


            con.Close();


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fillDataGridView();
        }

        String StaffDForDelete;
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnDelete.Visible = true;

            StaffDForDelete = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            btnDelete.Text = "Remove " + StaffDForDelete;
        }

        private void MemberDetails_Click(object sender, EventArgs e)
        {
            btnDelete.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          
            try
            {
                con.Open();
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandText = "Delete from Library_Member_Staff where stfID  = '" + StaffDForDelete + "'";
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
            fillToDropDown();
            fillDataGridView();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT s.stfID , s.fName, s.lName, s.phone,s.email FROM Staff s, Library_Member_Staff lms WHERE s.stfID = lms.stfID and s.stfID like '%" + textBox4.Text + "%'";


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
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
    
}
