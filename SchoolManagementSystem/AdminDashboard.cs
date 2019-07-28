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

        }

        private void logOut_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void Admin_Manage_Results_Click(object sender, EventArgs e)
        {

            Admin_ManageResults_Dashboard objAdmMngResultDashBoard = new Admin_ManageResults_Dashboard();
           // this.Hide();
            objAdmMngResultDashBoard.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
