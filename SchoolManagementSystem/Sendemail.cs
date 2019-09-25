using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Mail;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public partial class Sendemail : Form
    {
        public Sendemail()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "")
            {
                MessageBox.Show("Please enter Email Address");
            }else if (txtAdmissionNo.Text =="")
            {
                MessageBox.Show("Please enter Admission Number");
            }else if (txtDetails.Text=="")
            {
                MessageBox.Show("Please enter details");
            }else
            {
                sendMail();
            }
        }

        private void sendMail()
        {
            try
            {
                //    this.Cursor = Cursors.WaitCursor;
                //    MailMessage mail = new MailMessage("asokacollegecolombo10@gmail.com", txtEmailAddress.Text, txtAdmissionNo.Text, txtDetails.Text);
                //    //SmtpClient client = new SmtpClient(smtp.Text);
                //    SmtpClient client = new SmtpClient("smtp.gmail.com");

                //    client.Port = 587;
                //    client.Credentials = new System.Net.NetworkCredential("asokacollegecolombo10@gmail.com", "itpproject");
                //    client.EnableSsl = true;
                //    client.Send(mail);

                //    this.Cursor = Cursors.Default;

                //    MessageBox.Show("Mail sent successfully");

   

                this.Cursor = Cursors.WaitCursor;
                MailMessage mail = new MailMessage("asokacollegecolombo10@gmail.com", txtEmailAddress.Text, txtAdmissionNo.Text, txtDetails.Text);
                //SmtpClient client = new SmtpClient(smtp.Text);
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("asokacollegecolombo10@gmail.com", "itpproject");
                client.EnableSsl = true;
                client.Send(mail);

            
                this.Cursor = Cursors.Default;

                MessageBox.Show("Mail sent successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured " + ex);
                this.Cursor = Cursors.Default;
            }



}

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void Sendemail_Load(object sender, EventArgs e)
        {
            User u = UserSessionStore.Instance.getUser();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Student Details> Send Email";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Student Details> Send Email";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Student Details> Send Email";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Student Details> Send Email";
            }
            else
            {
                lblPath.Text = "";
            }
        }

        private void backASM_Click(object sender, EventArgs e)
        {
            this.Close();
            StuDetails obj = new StuDetails();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }
    }
}
