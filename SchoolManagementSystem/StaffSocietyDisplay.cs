using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class StaffSocietyDisplay : Form
    {
        //SqlConnection sqlConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AsokaCollegeDB\School_DataBase.mdf;Integrated Security=True;Connect Timeout=30");

        SqlConnection sqlConn = new SqlConnection(CommonConstants.connnectionString);

        public StaffSocietyDisplay()
        {
            InitializeComponent();
            fillDataGridView();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            StaffEventDashboard Sed1 = new StaffEventDashboard();
            Sed1.ShowDialog();
        }

        void fillDataGridView()
        {
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("AssociationSearch_Procedure", sqlConn);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@AssociationName", txtSearch.Text.Trim());


            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;

            sqlConn.Close();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                fillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void StaffSocietyDisplay_Load(object sender, EventArgs e)
        {
            User u = UserSessionStore.Instance.getUser();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Event Management> Societies ";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Event Management> Societies";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Event Management> Societies";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Event Management> Societies";
            }
            else
            {
                lblPath.Text = "";
            }
        }
    }
}
