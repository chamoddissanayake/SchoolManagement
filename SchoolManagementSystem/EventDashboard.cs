using SchoolManagementSystem.Model;
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
    public partial class EventDashboard : Form
    {
        public EventDashboard()
        {
            InitializeComponent();
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {

            this.Close();
            AdminDashboard obj = new AdminDashboard();
            obj.Show();

        }

        private void NMbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Notification n1 = new Notification();
            n1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Notification n1 = new Notification();
            //n1.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Notification n1 = new Notification();
            //n1.ShowDialog();
        }

        private void EMbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Event v1 = new Event();
            v1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Event v1 = new Event();
            //v1.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Event v1 = new Event();
            //v1.ShowDialog();
        }

        private void SMbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Societies s1 = new Societies();
            s1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Societies s1 = new Societies();
            //s1.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Societies s1 = new Societies();
            //s1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void EventDashboard_Load(object sender, EventArgs e)
        {
            User u = UserSessionStore.Instance.getUser();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Event Management> ";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Event Management>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Event Management>";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Event Management>";
            }
            else
            {
                lblPath.Text = "";
            }
        }
    }
}
