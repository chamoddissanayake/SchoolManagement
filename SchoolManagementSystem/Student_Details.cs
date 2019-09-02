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
using System.Globalization;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public partial class StuDetails : Form
    {
        User u;
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3P2NFTI\SQLEXPRESS;Initial Catalog=connection;Integrated Security=True");
        //Working
        // SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6UT7SKT;Initial Catalog=SchoolManagement;Integrated Security=True");
        SqlConnection con = new SqlConnection(CommonConstants.connnectionString);
        public StuDetails()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disp_data();
            txtFnmae.Focus();

            u = UserSessionStore.Instance.getUser();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Student Details>";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Student Details>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Student Details>";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Student Details>";
            }
            else
            {
                lblPath.Text = "";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int j;
            if(txtSid.Text =="" || txtFnmae.Text==""|| txtMname.Text==""|| txtLname.Text==""|| txtDOB.Text==""|| txtYOR.Text==""|| txtAddress.Text==""|| txtTel.Text==""|| txtEmail.Text==""|| txtBloodGroup.Text==""|| txtParentName.Text==""|| txtNationalism.Text==""|| txtReligion.Text=="")
            {
                MessageBox.Show("All fields must be filled");
            }else if(! Int32.TryParse(txtYOR.Text, out  j))
            {
                MessageBox.Show("Year of register is not a number.");
            }else if ( Int32.Parse(txtYOR.Text) <1983 || Int32.Parse(txtYOR.Text) > 2100)
            {
                MessageBox.Show("Year is not in valid range.");
            }else if (!Int32.TryParse(txtTel.Text, out j))
            {
                MessageBox.Show("Please input valid telephone number.");
            } else if (txtTel.Text.Length != 10)
            {
                MessageBox.Show("Telephone number must be a 10 digit number.");
            }
            else if (txtBloodGroup.Text.Length != 2)
            {
                MessageBox.Show("Please enter correct blood group.");
            }else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Student values('" + txtSid.Text + "','" + txtFnmae.Text + "','" + txtMname.Text + "','" + txtLname.Text + "', '" + txtDOB.Text + "'," + txtYOR.Text + ",'" + txtAddress.Text + "','" + txtTel.Text + "','" + txtEmail.Text + "','" + txtBloodGroup.Text + "','" + txtParentName.Text + "','" + txtNationalism.Text + "','" + txtReligion.Text + "')";
                
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Details added Successfully!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong.");
                }

                con.Close();
                disp_data();
                
            }

           
            



        }
        public void disp_data() {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Student";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            con.Close();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            disp_data_search(txtSid.Text);
        }

        private void disp_data_search(string text)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Student where sId LIKE '%" + text+ "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtSid.Text == "")
            {
                MessageBox.Show("Please enter student ID");
            }else{
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Delete from Student where sID='" + txtSid.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    disp_data();
                    MessageBox.Show("Record Delete Successfully!");

                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message, "Eorror");
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtSid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtFnmae.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtMname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtLname.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDOB.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtYOR.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtAddress.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtBloodGroup.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtParentName.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtNationalism.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtReligion.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int j;
            if (txtSid.Text == "" || txtFnmae.Text == "" || txtMname.Text == "" || txtLname.Text == "" || txtDOB.Text == "" || txtYOR.Text == "" || txtAddress.Text == "" || txtTel.Text == "" || txtEmail.Text == "" || txtBloodGroup.Text == "" || txtParentName.Text == "" || txtNationalism.Text == "" || txtReligion.Text == "")
            {
                MessageBox.Show("All fields must be filled");
            }
            else if (!Int32.TryParse(txtYOR.Text, out j))
            {
                MessageBox.Show("Year of register is not a number.");
            }
            else if (Int32.Parse(txtYOR.Text) < 1983 || Int32.Parse(txtYOR.Text) > 2100)
            {
                MessageBox.Show("Year is not in valid range.");
            }
            else if (!Int32.TryParse(txtTel.Text, out j))
            {
                MessageBox.Show("Please input valid telephone number.");
            }
            else if (txtTel.Text.Length != 10)
            {
                MessageBox.Show("Telephone number must be a 10 digit number.");
            }
            else if (txtBloodGroup.Text.Length != 2)
            {
                MessageBox.Show("Please enter correct blood group.");
            }
            else
            {
                    //Update part - start
                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Update Student set fName ='" + txtFnmae.Text + "',mName='" + txtMname.Text + "',lName='" + txtLname.Text + "',dob= '" + txtDOB.Text + "',yor=" + txtYOR.Text + ",address='" + txtAddress.Text + "',tel='" + txtTel.Text + "',email='" + txtEmail.Text + "',bloodgroup='" + txtBloodGroup.Text + "',parent_Name='" + txtParentName.Text + "',nationalism='" + txtNationalism.Text + "',religion='" + txtReligion.Text + "'where sID='" + txtSid.Text + "'";
                        
                        cmd.ExecuteNonQuery();
                        con.Close();
                        disp_data();
                        MessageBox.Show("Record Update Successfully!");
                    }
                    catch (Exception msg)
                    {
                        MessageBox.Show(msg.Message, "Error");
                    }
                    //Update part - end
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            var newForm = new Sendemail();  
            newForm.Show();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            var newForm = new printdetails();
            newForm.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void backASM_Click(object sender, EventArgs e)
        {
            if (u.Type == "Admin")
            {
                this.Close();
                AdminDashboard obj = new AdminDashboard();
                obj.Show();
            }
            else if (u.Type == "Academic_Staff")
            {
                this.Close();
                AcademicStaffDashBoard obj = new AcademicStaffDashBoard();
                obj.Show();
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                this.Close();
                NonAcademicStaffDashboard obj = new NonAcademicStaffDashboard();
                obj.Show();
            }
            else if (u.Type == "Administrative_Staff")
            {
                this.Close();
                AdministrativeStaffDashboard obj = new AdministrativeStaffDashboard();
                obj.Show();
            }
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }
    }
}
