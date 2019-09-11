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
    public partial class LibraryDashBoard : Form
    {
        public LibraryDashBoard()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        User u;
        private void LibraryDashBoard_Load(object sender, EventArgs e)
        {
            u = UserSessionStore.Instance.getUser();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Library>";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Library>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Library>";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Library>";
            }
            else
            {
                lblPath.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BooksDetails bk = new BooksDetails();
            bk.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //this.Hide();
            //library_StudentDetails lsd1 = new library_StudentDetails();
            //lsd1.Show();

            //temporary Connection
            this.Hide();
            library_StudentDetails libStudentOb = new library_StudentDetails();
            libStudentOb.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            // this.hide();
            // memberdetails mbrd = new memberdetails();
            //mbrd.show();

            this.Close();
            MemberDetails memberDetailsObj = new MemberDetails();
            memberDetailsObj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
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
    }
}
