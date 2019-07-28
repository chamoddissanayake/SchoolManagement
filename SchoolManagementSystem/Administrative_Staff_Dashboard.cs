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
    public partial class AdministrativeStaffDashboard : Form
    {
        public AdministrativeStaffDashboard()
        {
            InitializeComponent();
        }

        private void AdministrativeStaffDashboard_Load(object sender, EventArgs e)
        {
            User u = UserSessionStore.Instance.getUser();
            helloMsg.Text = "Hello " + u.getuserID();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void Administrative_Staff_Manage_Results_Click(object sender, EventArgs e)
        {

            Administrative_Staff_ManageResults_Dashboard objAdmStfMngResultDashBoard = new Administrative_Staff_ManageResults_Dashboard();
            // this.Hide();
            objAdmStfMngResultDashBoard.Show();
        }
    }
}
