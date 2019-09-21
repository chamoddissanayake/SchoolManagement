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
    public partial class Book_Issue : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AsokaCollegeDB\School_DataBase.mdf;Integrated Security=True;Connect Timeout=30");
        public string constring = "Data Source=DESKTOP-83SSJ0U;Initial Catalog=ConnectionDb;Integrated Security=True ";

        SqlConnection con = new SqlConnection(CommonConstants.connnectionString);


        public Book_Issue()
        {
            InitializeComponent();
        }
        public void disp_date()
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Books_Issued";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception e001)
            {
                MessageBox.Show("Error: "+e001);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }



        }

        private void sub_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || dateTimePicker1.Text == "" || dateTimePicker1.Text == "")
            {
                MessageBox.Show("All Should be Filled!");
            }
            else
            {

                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Insert into Books_Issued values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    disp_date();
                    MessageBox.Show("Record Inserted Successfully!");
                    con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error");
                    con.Close();

                }
            }
        }

        private void Book_Issue_Load_1(object sender, EventArgs e)
        {
            disp_date();
        }

        
    
private void button1_Click(object sender, EventArgs e)
        {
          
        }
        private void dataGridView1_DoubleClick(object sender, EvaluateException e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Books_Issued set Due_Date='" + dateTimePicker2.Text.Trim() + "' where admissionNo ='" + textBox1.Text.Trim() + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

                textBox1.ReadOnly = false;
                textBox3.ReadOnly = false;

                disp_date();
                MessageBox.Show("Record Updated Successfully!!!");   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                con.Close();
            }
            sub.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Books_Issued where admissionNo ='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox1.ReadOnly = false;
                textBox3.ReadOnly = false;
                disp_date();
                MessageBox.Show("Record Deleted Successfully!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");   
            }
            finally
            {
                con.Close();
            }
            sub.Visible = true;
        }
        User u;
        private void Book_Issue_Load(object sender, EventArgs e)
        {
            u = UserSessionStore.Instance.getUser();
            disp_date();

            textBox2.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            lblStaffName.Visible = false;
            lblStaffName.Visible = false;

            radioStudent.Checked = true;

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Library> Books> Issue Books>";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Library> Books> Issue Books>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Library> Books> Issue Books>";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Library> Books> Issue Books>";
            }
            else
            {
                lblPath.Text = "";
            }


        }

        public void getdetailsselectRow(DataGridViewCellEventArgs e)
        {

        }   


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                textBox1.ReadOnly = true;
                textBox3.ReadOnly = true;

                sub.Visible = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex);
            }


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                textBox1.ReadOnly = true;
                textBox3.ReadOnly = true;

                sub.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            BooksDetails Bd1 = new BooksDetails();
            Bd1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillStudentORStaffName();
            }
        }

        private void fillStudentORStaffName()
        {
            if(radioStudent.Checked == true)
            {
                fillStudentName();
            }else if (radioStaff.Checked == true)
            {
                fillStaffName();
            }
        }

        private void fillStaffName()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                /*
                    SELECT s.stfID, s.fname
                    FROM Library_Member_Staff lms, Staff s
                    WHERE s.stfID = lms.stfID AND s.stfID = 'STF002'
                */

                cmd.CommandText = "SELECT s.stfID, s.fname FROM Library_Member_Staff lms, Staff s WHERE s.stfID = lms.stfID AND s.stfID = '" + textBox1.Text + "' ";

                SqlDataReader reader = cmd.ExecuteReader();
                string name = "";
                int counter = 0;
                while (reader.Read())
                {
                    name = (string)(reader[1]);
                    counter++;
                }

                if (counter == 0)
                {
                    MessageBox.Show("Not a valid Staff member in library.");
                }
                textBox2.Text = name;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }


        }

        private void fillStudentName()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                /*
                    SELECT s.sID, s.fname
                    FROM Library_Member_Student lms, Student s
                    WHERE s.sID = lms.sID AND s.sID = 'S00001'
                */

                cmd.CommandText = "SELECT s.sID, s.fname  FROM Library_Member_Student lms, Student s  WHERE s.sID = lms.sID AND s.sID = '" + textBox1.Text + "' ";

                SqlDataReader reader = cmd.ExecuteReader();
                string name = "";
                int counter = 0;
                while (reader.Read())
                {
                    name = (string)(reader[1]);
                    counter++;
                }

                if (counter == 0)
                {
                    MessageBox.Show("Not a valid Student member in library.");
                }
                textBox2.Text = name;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void radioStudent_CheckedChanged(object sender, EventArgs e)
        {
            lblStfID.Visible = false;
            lblStudentID.Visible = true;

            lblStaffName.Visible = false;
            lblStudentName.Visible = true;
            

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void radioStaff_CheckedChanged(object sender, EventArgs e)
        {
            lblStudentID.Visible = false;
            lblStfID.Visible = true;

            lblStudentName.Visible = false;
            lblStaffName.Visible = true;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillBookDetails();
            }
        }

        private void fillBookDetails()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                /*
                    SELECT *
                    FROM books_Info
                    WHERE Id = 1
                */

                cmd.CommandText = "SELECT * FROM books_Info WHERE Id = '" + textBox3.Text + "' ";

                SqlDataReader reader = cmd.ExecuteReader();
                string b_name = "";
                string a_name = "";
                int counter = 0;
                while (reader.Read())
                {
                    b_name = (string)(reader[1]);
                    a_name = (string)(reader[2]);
                    counter++;
                }

                if (counter == 0)
                {
                    MessageBox.Show("Not a valid Student member in library.");
                }
                textBox4.Text = b_name;
                textBox5.Text = a_name;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            disp_date();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Books_Issued where admissionNo like'%" + textBox6.Text.Trim() + "%'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex001)
            {
                MessageBox.Show("Error: "+ex001);
            }
            finally
            {
                con.Close();
            }
    

            
        }

        private void Book_Issue_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            textBox1.ReadOnly = false;
            textBox3.ReadOnly = false;

            sub.Visible = true;
        }
    }
}
