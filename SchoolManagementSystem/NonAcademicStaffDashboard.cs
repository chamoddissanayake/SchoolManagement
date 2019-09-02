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
    public partial class NonAcademicStaffDashboard : Form
    {
        public NonAcademicStaffDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void OBMemberDashboard_Load(object sender, EventArgs e)
        {
            User u = UserSessionStore.Instance.getUser();
            helloMsg.Text = "Hello " + u.getuserID();

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

        private void NonAcademic_Staff_OB_Management_Click(object sender, EventArgs e)
        {
            FormOldBoys1 obj = new FormOldBoys1();
            obj.Show();
        }

        private void Academic_Staff_Staff_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            Non_academic_Account obj = new Non_academic_Account();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
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
            StaffEventDashboard obj = new StaffEventDashboard();
            obj.Show();
        }

        private void Admin_Library_Management_Click(object sender, EventArgs e)
        {
            this.Close();
            LibraryDashBoard obj = new LibraryDashBoard();
            obj.Show();
        }
    }
}
