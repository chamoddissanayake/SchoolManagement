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
    public partial class EmailSendInterface : Form
    {
        User u;
        public EmailSendInterface()
        {
            InitializeComponent();
        }

        private void EmailSendInterface_Load(object sender, EventArgs e)
        {
            u = UserSessionStore.Instance.getUser();
            helloMsg.Text = "Hello " + u.getuserID();
            
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sendEmail_Click(object sender, EventArgs e)
        {
            try
            {      
                sendEmail.Enabled = false;
                
                this.Cursor = Cursors.WaitCursor;
                     MailMessage mail = new MailMessage("asokacollegecolombo10@gmail.com", "dissanayakechamod@gmail.com", emailSubject.Text+"  FROM: " + u.getuserID(), emailBody.Text);
                    //SmtpClient client = new SmtpClient(smtp.Text);
                    SmtpClient client = new SmtpClient("smtp.gmail.com");
                    client.Port = 587;
                    client.Credentials = new System.Net.NetworkCredential("asokacollegecolombo10@gmail.com", "itpproject");
                    client.EnableSsl = true;
                    client.Send(mail);

                sendEmail.Enabled = true;
                this.Cursor = Cursors.Default;
                
                MessageBox.Show("Mail sent successfully");
            }
            catch(Exception ex) {
                
                MessageBox.Show("Error while sending message - " + ex.Message);
            }
           
        }

        private void emailSubject_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
