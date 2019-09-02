using iTextSharp.text;
using iTextSharp.text.pdf;
using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class SpesificReport : Form
    {
        public SpesificReport()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            documentcreate();
        }

        private void documentcreate()
        {
            //  Document document = new Document();
            iTextSharp.text.Document document = new iTextSharp.text.Document();


            PdfWriter.GetInstance(document, new FileStream("D:/testReport.pdf", FileMode.Create));
            document.Open();

            Document open;
            Paragraph p = new Paragraph("--- Reprot Of All Subjects Details ---");

            PdfPTable pdfTable = new PdfPTable(6);


            document.Add(p);
            document.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void SpesificReport_Load(object sender, EventArgs e)
        {
            User u = UserSessionStore.Instance.getUser();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Subject Management> Report> Specific Report";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Subject Management> Report> Specific Report";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Subject Management> Report> Specific Report";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Subject Management> Report> Specific Report";
            }
            else
            {
                lblPath.Text = "";
            }
        }

        private void backAE_Click(object sender, EventArgs e)
        {
            this.Close();
            Report obj = new Report();
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
