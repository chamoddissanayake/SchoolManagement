using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public partial class StaffEventDashboard : Form
    {
        public StaffEventDashboard()
        {
            InitializeComponent();
        }

        private void EMbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            StaffEventsDisplay sed1 = new StaffEventsDisplay();
            sed1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //StaffEventsDisplay sed1 = new StaffEventsDisplay();
            //sed1.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //StaffEventsDisplay sed1 = new StaffEventsDisplay();
            //sed1.ShowDialog();
        }

        private void NMbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            StaffNotificationDisplay obj = new StaffNotificationDisplay();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //StaffNotificationDisplay snd1 = new StaffNotificationDisplay();
            //snd1.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //StaffNotificationDisplay snd1 = new StaffNotificationDisplay();
            //snd1.ShowDialog();
        }

        private void SMbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            StaffSocietyDisplay ssd1 = new StaffSocietyDisplay();
            ssd1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //StaffSocietyDisplay ssd1 = new StaffSocietyDisplay();
            //ssd1.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //StaffSocietyDisplay ssd1 = new StaffSocietyDisplay();
            //ssd1.ShowDialog();
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            if (u.Type == "Admin")
            {
                this.Close();
                AdminDashboard obj = new AdminDashboard();
                obj.Show();
            }
            else if (u.Type == "Academic_Staff")
            {
                this.Close();
                AcademicStaffDashBoard obj = new AcademicStaffDashBoard();
                obj.Show();
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                this.Close();
                NonAcademicStaffDashboard obj = new NonAcademicStaffDashboard();
                obj.Show();
            }
            else if (u.Type == "Administrative_Staff")
            {
                this.Close();
                AdministrativeStaffDashboard obj = new AdministrativeStaffDashboard();
                obj.Show();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        User u;
        private void StaffEventDashboard_Load(object sender, EventArgs e)
        {
            u = UserSessionStore.Instance.getUser();

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
