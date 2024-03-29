﻿using System;
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
    public partial class Last : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AsokaCollegeDB\School_DataBase.mdf;Integrated Security=True;Connect Timeout=30");

        public string constring = "Data Source=DESKTOP-83SSJ0U;Initial Catalog=ConnectionDb;Integrated Security=True ";

        SqlConnection con = new SqlConnection(CommonConstants.connnectionString);

        public Last()
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
                cmd.CommandText = "select * from Payment";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
                con.Close();

            }
        }
        private void search_Click(object sender, EventArgs e)
        {
           
        }
       

        private void Last_Load(object sender, EventArgs e)
        {
            disp_date();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void Double(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
        User u;
        private void Last_Load_1(object sender, EventArgs e)
        {
            u = UserSessionStore.Instance.getUser();
            disp_date();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Library> Books> Payments> Payments Done>";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Library> Books> Payments> Payments Done>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Library> Books> Payments> Payments Done>";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Library> Books> Payments> Payments Done>";
            }
            else
            {
                lblPath.Text = "";
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Payment where BookId ='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                disp_date();
                MessageBox.Show("Record Deleted Successfully!!!");
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
                con.Close();

            }
        }

        private void search_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Payment where BookId='" + textBox8.Text.Trim() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
           
            con.Close();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            BooksDetails Bd1 = new BooksDetails();
            Bd1.ShowDialog();
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
