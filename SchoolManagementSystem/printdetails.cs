using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolManagementSystem.Model;


namespace SchoolManagementSystem
{
    public partial class printdetails : Form
    {
        //Working
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6UT7SKT;Initial Catalog=SchoolManagement;Integrated Security=True");
        SqlConnection con = new SqlConnection(CommonConstants.connnectionString);
        public printdetails()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtSid.Text == "")
            {
                MessageBox.Show("Please enter student ID");
            }else
            {
                    Student s = new Model.Student();
                    s = null;
                    s = fetchResultfromDB();
                    if (s == null)
                    {
                        MessageBox.Show("Student Not found");
                    }
                    else
                    {
                        generateReport(s);
                    }
            }
            
        }

        private Student fetchResultfromDB()
        {
            // fetchResultfromDB start
            
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Student where sID = '" + txtSid.Text + "'";
            //cmd.ExecuteNonQuery();
            SqlDataReader reader =  cmd.ExecuteReader();

            Student stdObj = new Student();
            stdObj = null;
            while (reader.Read())
            {
                stdObj = new Student();

                stdObj.SID = reader["sID"].ToString(); 
                stdObj.FName= reader["fName"].ToString();
                stdObj.MName = reader["mName"].ToString();
                stdObj.LName = reader["lName"].ToString();
                stdObj.Dob = reader["dob"].ToString();
                stdObj.Yor = int.Parse( reader["yor"].ToString());
                stdObj.Address = reader["address"].ToString();
                stdObj.Tel= reader["tel"].ToString();
                stdObj.Email = reader["email"].ToString();
                stdObj.Bloodgroup = reader["bloodgroup"].ToString();
                stdObj.Parent_Name  = reader["parent_Name"].ToString();
                stdObj.Nationalism = reader["nationalism"].ToString();
                stdObj.Religion = reader["religion"].ToString();
                
            }

            
            con.Close();

            return stdObj;
            // fetchResultfromDB end
        }

        private void generateReport(Student s)
        {
            try
            {
                var savefiledialog = new SaveFileDialog();
                savefiledialog.FileName = "SubjectsReport";
                savefiledialog.DefaultExt = ".pdf";

                if (savefiledialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefiledialog.FileName, FileMode.Create))
                    {
                        Document document = new Document();

                        PdfWriter.GetInstance(document, stream);

                        document.Open();
                        //Document open

                        //Add school logo code start
                        iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance("C:/Users/User/Desktop/SchoolManagementSystem/SchoolManagementSystem/pictures/logo.png");
                        //Fixed Positioning
                        image1.SetAbsolutePosition(210, 650);
                        //Scale to new height and new width of image
                        image1.ScaleAbsolute(150, 150);
                        //Add to document
                        document.Add(image1);
                        //Add school logo code end



                        Paragraph p = new Paragraph("\n\n\n\n\n\n\n\n\n\n\n" +
                            "Student ID   = " + s.SID + "\n" +
                            "First Name   = " + s.FName + "\n" +
                            "Middle Name   = " + s.MName + "\n" +
                            "Last Name   = " + s.LName + "\n" +
                            "Date of Birth   = " + s.Dob + "\n" +
                            "Year of Register   = " + s.Yor + "\n" +
                            "Address   = " + s.Address + "\n" +
                            "Telephone No   = " + s.Tel + "\n" +
                            "Email   = " + s.Email + "\n" +
                            "Blood Group   = " + s.Bloodgroup + "\n" +
                            "Parent Name  = " + s.Parent_Name + "\n" +
                            "Nationalism   = " + s.Nationalism + "\n" +
                            "Religion   = " + s.Religion + "\n"


                            );
                        document.Add(p);

                        //Document close
                        document.Close();

                        MessageBox.Show(savefiledialog.FileName + "saved successfully.");


                        stream.Close();
                    }
                }
            }
            catch (IOException ex1)
            {
                MessageBox.Show("File Already open, Please close it.");
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error: " + e1);
            }
            finally
            {

            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void printdetails_Load(object sender, EventArgs e)
        {
            User u = UserSessionStore.Instance.getUser();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Student Details> Print Details";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Student Details> Print Details";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Student Details> Print Details";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Student Details> Print Details";
            }
            else
            {
                lblPath.Text = "";
            }
        }

        private void backAE_Click(object sender, EventArgs e)
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
