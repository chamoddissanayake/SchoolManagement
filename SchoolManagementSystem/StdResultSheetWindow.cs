using SchoolManagementSystem.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SchoolManagementSystem
{
    public partial class StdResultSheetWindow : Form
    {
        String fName_from_db;
        String mName_from_db; 
        String lName_from_db; 
        String email_from_db;

        bool s = false;

        static int colapse = 0;

        public StdResultSheetWindow()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(450, 0);
        }

        private void SearchResultByStudentID_Click(object sender, EventArgs e)
        {
            if (studentIDForSearchResult.Text == "")
            {
                MessageBox.Show("Please enter student ID:");
            }
            else
            {
                s = getStudent(studentIDForSearchResult.Text);
                if (s)
                {
                    getResults(studentIDForSearchResult.Text);

                    fillStudentGrades();

                }
                else
                {
                    MessageBox.Show("Student Not found");
                }
                
            }
        }

        private void fillStudentGrades()
        {
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                SELECT DISTINCT Subject.forGrade
                FROM Subject, Student_follow_subject
                WHERE Student_follow_subject.sCode = Subject.sCode AND Student_follow_subject.sID = 'S00001'
                */

                command.CommandText = "SELECT DISTINCT Subject.forGrade AS 'studentGrades' FROM Subject, Student_follow_subject WHERE Student_follow_subject.sCode = Subject.sCode AND Student_follow_subject.sID = 'S00001'";

                SqlParameter sID = new SqlParameter("@sID", SqlDbType.VarChar, 100);
                sID.Value = studentIDForSearchResult.Text;
                command.Parameters.Add(sID);

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    String grades = reader["studentGrades"].ToString();
                    studentGrade.Items.Add(grades);
                }
                studentGrade.SelectedIndex = 0;
                connection.Close();
            }
        }

        private void getResults(string text)
        {
            string conString = CommonConstants.connnectionString;
            //Fill dataTable start
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand command1 = new SqlCommand(null, con);

                /*
                SELECT Subject.sCode,Subject.sName, Subject.forGrade,Student_follow_subject.term,
                Student_follow_subject.examID, Student_follow_subject.mark
                FROM Subject, Student_follow_subject 
                WHERE Subject.sCode = Student_follow_subject.sCode AND 
                Student_follow_subject.sID = 'S00001'
                ORDER BY Subject.forGrade , Student_follow_subject.term
                
                /*
                 All columns
                 SELECT * FROM Subject, Student_follow_subject WHERE Subject.sCode = Student_follow_subject.sCode AND Student_follow_subject.sID = @sID
                 */


                command1.CommandText = "SELECT Student_follow_subject.examID, Subject.sCode,Subject.sName, Subject.forGrade,Student_follow_subject.term , Student_follow_subject.mark  FROM Subject, Student_follow_subject  WHERE Subject.sCode = Student_follow_subject.sCode AND  Student_follow_subject.sID = @sID ORDER BY Subject.forGrade , Student_follow_subject.term";

                SqlParameter stdID = new SqlParameter("@sID", SqlDbType.VarChar, 100);
                stdID.Value = studentIDForSearchResult.Text;
                command1.Parameters.Add(stdID);

                command1.Prepare();

                DataTable dt = new DataTable();
                
                SqlDataAdapter da = new SqlDataAdapter(command1);
                da.Fill(dt);
                dataGridViewResultSheet.DataSource = dt;

                con.Close();
            }
        }

        private bool getStudent(string text)
        {
            string conString = CommonConstants.connnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM Student WHERE sID= @sID";

                SqlParameter sID = new SqlParameter("@sID", SqlDbType.VarChar, 100);
                sID.Value = studentIDForSearchResult.Text;
                command.Parameters.Add(sID);

                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    //student found start
                     fName_from_db = reader["fName"].ToString();
                     mName_from_db = reader["mName"].ToString();
                     lName_from_db = reader["lName"].ToString();
                     email_from_db = reader["email"].ToString();

                    studentID.Text = studentIDForSearchResult.Text;
                    fName.Text = fName_from_db;
                    mName.Text = mName_from_db;
                    lName.Text = lName_from_db;
                    email.Text = email_from_db;
                    return true;
                }
                reader.Close();
                connection.Close();  
            }
            return false;
        }

        private void StdResultSheetWindow_Load(object sender, EventArgs e)
        {
            User u = UserSessionStore.Instance.getUser();

            studentID.Text = "";
            fName.Text = "";
            mName.Text = "";
            lName.Text = "";
            email.Text = "";

            studentIDForSearchResult.Select();

            
        }


        private void showChart_Click(object sender, EventArgs e)
        {
            
            
            if (studentIDForSearchResult.Text == "")
            {
                MessageBox.Show("Plese enter student ID");
            }
            else if (s == false)
            {
                MessageBox.Show("Student not found. Please provide correct student ID");
            }
            else
            {
                if (colapse == 0)
                {
                    this.Size = new Size(680, 900);
                    colapse = 1;
                }

                string studentID = studentIDForSearchResult.Text;
                string selectedGrade = this.studentGrade.GetItemText(this.studentGrade.SelectedItem);
                string selectedTerm = this.term.GetItemText(this.term.SelectedItem);

                    //Delete if old data exists
                    this.studentResultChartByGradeAndTerm.Series["Mark"].Points.Clear();

                getDataForChart(studentID, selectedGrade, selectedTerm);
               
            }


        }

        private void getDataForChart(string studentID, string selectedGrade, string selectedTerm)
        {
            
            //Get results of the student from db - start
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                SELECT Subject.sName  AS 'SubName', Student_follow_subject.mark AS 'Mark'
                FROM Subject, Student_follow_subject
                WHERE Subject.sCode = Student_follow_subject.sCode AND 
				Student_follow_subject.sID = 'S00001' AND 
				Subject.forGrade = 6 AND
				Student_follow_subject.term = 1
                */

                command.CommandText = "SELECT Subject.sName AS 'SubName', Student_follow_subject.mark AS 'Mark' FROM Subject, Student_follow_subject WHERE Subject.sCode = Student_follow_subject.sCode AND Student_follow_subject.sID = @sID AND  Subject.forGrade = @grade AND Student_follow_subject.term = @term";
                  

                SqlParameter sID = new SqlParameter("@sID", SqlDbType.VarChar, 100);
                sID.Value = studentID;
                command.Parameters.Add(sID);

                SqlParameter grade = new SqlParameter("@grade", SqlDbType.Int, 100);
                grade.Value = int.Parse(selectedGrade);
                command.Parameters.Add(grade);

                SqlParameter term = new SqlParameter("@term", SqlDbType.Int, 100);
                term.Value = int.Parse(selectedTerm);
                command.Parameters.Add(term);

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();
               
                String[] subjectNameArray = new String[30];
                int[] markArray = new int[30];
                int counter = 0;
                
                while (reader.Read())
                {
                    String SubName = reader["SubName"].ToString();
                    String markString = reader["Mark"].ToString();
                    int mark = int.Parse(markString);

                    subjectNameArray[counter] = SubName;
                    markArray[counter] = mark;
                    counter++;
                }
               
                drawingGraph(subjectNameArray, markArray, counter);
                connection.Close();
            }
            //Get results of the student from db - end
        }

        private void drawingGraph(string[] subjectNameArray, int[] markArray, int counter)
        {
            //studentResultChartByGradeAndTerm
            for(int i=0; i < counter; i++)
            {
                this.studentResultChartByGradeAndTerm.Series["Mark"].Points.AddXY(subjectNameArray[i],markArray[i]);
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveResult_Click(object sender, EventArgs e)
        {
            if(studentIDForSearchResult.Text == "")
            {
                MessageBox.Show("Plese enter student ID");
            }else if (s == false) {
                MessageBox.Show("Student not found. Please provide correct student ID");
            }else{
                documentCreate();
            }
        }

        private void documentCreate()
        {
            Document document = new Document();

            PdfWriter.GetInstance(document, new FileStream("E:/" + studentIDForSearchResult.Text + " - ResultSheet.pdf", FileMode.Create));
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

            //Add school logo code end
            Paragraph p = new Paragraph("\n\n\n\n\n\n\n\n\n\n\n" +
                                        "Student ID   = " + studentIDForSearchResult.Text + "\n" +
                                        "Full Name    = " + fName_from_db + " " + mName_from_db + " " + lName_from_db + "\n" +
                                        "Email         = " + email_from_db + "\n\n");
            document.Add(p);


            //Table Add start
            PdfPTable pdfTable = new PdfPTable(6);
            foreach (DataGridViewRow row in dataGridViewResultSheet.Rows)
            {
                foreach (DataGridViewCell celli in row.Cells)
                {
                    try
                    {
                        pdfTable.AddCell(celli.Value.ToString());
                    }
                    catch { }
                }
            }
            document.Add(pdfTable);

            //Table add end



            //Final note start
            DateTime now = DateTime.Now;
            Paragraph pEnd = new Paragraph("- System generated result sheet on " + now + " - ");
            document.Add(pEnd);
            //Final note end


            //Document close
            document.Close();

            MessageBox.Show("Result sheet saved on E:/" + studentIDForSearchResult.Text + " - ResultSheet.pdf");
        }

        private void studentGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillStudentExamTerms();
        }

        private void fillStudentExamTerms()
        {
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                    SELECT DISTINCT Student_follow_subject.term AS 'terms'
                    FROM Subject, Student_follow_subject
                    WHERE Student_follow_subject.sCode = Subject.sCode AND 
		                    Student_follow_subject.sID = 'S00001' AND
		                    Subject.forGrade=6
                    ORDER BY terms

                */

                command.CommandText = "SELECT DISTINCT Student_follow_subject.term AS 'terms' FROM Subject, Student_follow_subject WHERE Student_follow_subject.sCode = Subject.sCode AND Student_follow_subject.sID = @sID AND Subject.forGrade = @grade ORDER BY terms";
                
                SqlParameter sID = new SqlParameter("@sID", SqlDbType.VarChar, 100);
                sID.Value = studentIDForSearchResult.Text;
                command.Parameters.Add(sID);

                SqlParameter grade = new SqlParameter("@grade", SqlDbType.Int, 100);
                grade.Value =int.Parse( studentGrade.SelectedItem.ToString());
                command.Parameters.Add(grade);


                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    String terms = reader["terms"].ToString();
                    term.Items.Add(terms);
                }
                
                term.SelectedIndex = 0;
                connection.Close();
            }
        }

        private void studentIDForSearchResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchResultByStudentID_Click(sender, e);
            }
        }
    }

        
    
}
