using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
                      
            User u = UserSessionStore.Instance.getUser();
            helloMsg.Text = "Hello " + u.getuserID();

            if (u.Type == "Admin"){
                lblPath.Text = "Admin Dashboard>";
            }
            else if (u.Type == "Academic_Staff"){

            }else if (u.Type== "Non_Academic_Staff"){

            }else if (u.Type== "Administrative_Staff"){

            }else{
                lblPath.Text = "";
            }
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            
        }

        private void Admin_Manage_Results_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin_ManageResults_Dashboard objAdmMngResultDashBoard = new Admin_ManageResults_Dashboard();
            objAdmMngResultDashBoard.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Student_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            StuDetails stuDetailsObj = new StuDetails();
            stuDetailsObj.Show();
        }

        private void Admin_Subject_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            Subject obj = new Subject();
            obj.Show();
        }

        private void Admin_Event_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            EventDashboard obj = new EventDashboard();
            obj.Show();
        }

        private void Admin_Staff_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            sub_staff_dashboard obj = new sub_staff_dashboard();
            obj.Show();
        }

        private void lblPath_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void Admin_OB_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            FormOldBoys1 obj = new FormOldBoys1();
            obj.Show();
        }

        private void Admin_Library_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            LibraryDashBoard obj = new LibraryDashBoard();
            obj.Show();
        }

        private void btnLoggedInUsers_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginTrack obj = new LoginTrack();
            obj.Show();
        }
    }
}
