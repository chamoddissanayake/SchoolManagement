﻿using SchoolManagementSystem.Model;
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
    public partial class Subject : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AsokaCollageDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
       // SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6UT7SKT;Initial Catalog=SchoolManagement;Integrated Security=True");
        SqlConnection con = new SqlConnection(CommonConstants.connnectionString);

        public Subject()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please fill all feilds!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Subject values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "', '" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                diplay();

                MessageBox.Show("Successfully Inserted!");

            }
        }

        public void diplay()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Subject";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please fill all feilds!");
            }
            else{
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Subject set sName = '" + textBox2.Text + "',teacherIncharge = '" + textBox3.Text + "',email = '" + textBox4.Text + "',noOfTeachers =" + textBox5.Text + " ,forGrade= " + textBox6.Text + " where sCode = '" + textBox1.Text + "' ";
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                diplay();
                MessageBox.Show("Successfully Updated!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please fill all feilds!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Subject where sCode = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                diplay();
                MessageBox.Show("Successfully Deleted!");
            }
           
        }


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();



        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Subject where sCode = '" + textBox7.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            this.Close();
            Email email = new Email();
            email.ShowDialog();

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Close();
            Report re = new Report();
            re.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        User u;
        private void Form1_Load(object sender, EventArgs e)
        {
            diplay();

            u = UserSessionStore.Instance.getUser();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Subject Management>";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Subject Management>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Subject Management>";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Subject Management>";
            }
            else
            {
                lblPath.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void backAE_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }
    }
}
