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
    public partial class AcademicStaffDashBoard : Form
    {
        User u;
        public AcademicStaffDashBoard()
        {
            InitializeComponent();
        }

        private void AcademicStaffDashBoard_Load(object sender, EventArgs e)
        {
            Academic_Staff_Library_Management.Visible = false;

            u = UserSessionStore.Instance.getUser();
            helloMsg.Text = "Hello "+u.getuserID();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard>";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard>";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard>";
            }
            else
            {
                lblPath.Text = "";
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
           

            
        }

        private void sendMessage_Click(object sender, EventArgs e)
        {
            
            EmailSendInterface objEmailsend = new EmailSendInterface();
            objEmailsend.Show();
        }

        private void Academic_Staff_Manage_Results_Click(object sender, EventArgs e)
        {
            this.Hide();
            Academic_Staff_ManageResults_Dashboard objAcdStfMngResultDashboard = new Academic_Staff_ManageResults_Dashboard();
            objAcdStfMngResultDashboard.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void Academic_Staff_Student_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            StuDetails obj = new StuDetails();
            obj.Show();
        }

        private void Academic_Staff_Subject_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            Subject obj = new Subject();
            obj.Show();
        }

        private void Academic_Staff_Event_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            StaffEventDashboard obj = new StaffEventDashboard();
            obj.Show();
        }

        private void Academic_Staff_Staff_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            Academic_staff_Account obj = new Academic_staff_Account();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void Academic_Staff_OB_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            //FormOldBoys1 obj = new FormOldBoys1();
            //obj.Show();
            OldBoysDashboard oldBoysDashObj = new OldBoysDashboard();
            oldBoysDashObj.Show();
        }

        private void Academic_Staff_Library_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            LibraryDashBoard obj = new LibraryDashBoard();
            obj.Show();
        }
    }
}
