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

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into  Library_Member_Staff values('"+ sIDCombo.SelectedItem.ToString() + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                
                MessageBox.Show("Member Registered succesfully");
                fillToDropDown();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        User u;
        private void MemberDetails_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            u = UserSessionStore.Instance.getUser();

            fillToDropDown();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
    }
    
}
