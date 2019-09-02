using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class sub_staff_dashboard : Form
    {
        public sub_staff_dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Non_Academic_Staff_Mng non_aca_mng = new Non_Academic_Staff_Mng();
            non_aca_mng.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            AcademicToDash aca_dash = new AcademicToDash();
            aca_dash.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Account_dashboard accd = new Account_dashboard();
            //accd.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            Adm_Stf_Staff_Mng obj = new Adm_Stf_Staff_Mng();
            obj.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void backAE_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard obj = new AdminDashboard();
            obj.Show();
        }
    }
}
