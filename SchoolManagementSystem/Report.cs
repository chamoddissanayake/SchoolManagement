using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            User u = UserSessionStore.Instance.getUser();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Subject Management> Report";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Subject Management> Report";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Subject Management> Report";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Subject Management> Report";
            }
            else
            {
                lblPath.Text = "";
            }
        }

       
        private void btnAll_Click(object sender, EventArgs e)
        {
            documentcreate();
            
        }

        private void documentcreate()
        {
          //  Document document = new Document();
            iTextSharp.text.Document document = new iTextSharp.text.Document();


            PdfWriter.GetInstance(document, new FileStream("D:/test123.pdf", FileMode.Create));
            document.Open();

            Document open;
            Paragraph p = new Paragraph("--- Reprot Of All Subjects Details ---");

            PdfPTable pdfTable = new PdfPTable(6);


            document.Add(p);

            //foreach (DataGridViewRow row in )
            //{
            //    foreach (DataGridViewCell celli in row.Cells)
            //    {
            //        try
            //        {
            //            pdfTable.AddCell(celli.Value.ToString());
            //        }
            //        catch { }
            //    }
            //}
            //document.Add(pdfTable);

            document.Close();

            MessageBox.Show("Report Successfully Saved");
        }

        private void btnSpecific_Click(object sender, EventArgs e)
        {
            this.Hide();
            SpesificReport sr = new SpesificReport();
            sr.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void backAE_Click(object sender, EventArgs e)
        {
            this.Close();
            Subject obj = new Subject();
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
