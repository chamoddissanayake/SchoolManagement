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
         private void Student_details_Load(object sender, EventArgs e)
        {
           
                
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Library_Member_Student values('" + textBox1.Text + "' )";
            cmd.ExecuteNonQuery();
            con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
           
            MessageBox.Show("Student details added succesfully");
            display();
        }
        public void display()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select s.sID, s.fName, s.tel from Student s , Library_Member_Student lm where s.sID = lm.sid";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        User u;
        private void StudentDetails_Load(object sender, EventArgs e)
        {
            u = UserSessionStore.Instance.getUser();

            display();
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
               // cmd.CommandText = "select * from Student_details where admissionNo  = '" + textBox4.Text + "'";
                cmd.CommandText = "SELECT s.sID , s.fName, s.mName, s.lName, s.tel,s.email FROM Student s, Library_Member_Student lms WHERE s.sID = lms.sid and s.sID = '" + textBox4.Text + "'";


                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            //textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();


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
            string name="", tel="";
            while (reader.Read())
            {
                name= (string)(reader[2]);
                tel = (string)(reader[3]);
            }

            textBox2.Text = name;
            textBox3.Text = tel;

            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;


            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
