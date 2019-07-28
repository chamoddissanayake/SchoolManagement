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
        public AcademicStaffDashBoard()
        {
            InitializeComponent();
        }

        private void AcademicStaffDashBoard_Load(object sender, EventArgs e)
        {
            User u = UserSessionStore.Instance.getUser();
            helloMsg.Text = "Hello "+u.getuserID();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();

            
        }

        private void sendMessage_Click(object sender, EventArgs e)
        {
            
            EmailSendInterface objEmailsend = new EmailSendInterface();
            objEmailsend.Show();
        }

        private void Academic_Staff_Manage_Results_Click(object sender, EventArgs e)
        {
            Academic_Staff_ManageResults_Dashboard objAcdStfMngResultDashboard = new Academic_Staff_ManageResults_Dashboard();
            objAcdStfMngResultDashboard.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
