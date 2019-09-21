using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SchoolManagementSystem.Model;
using System.Collections;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SchoolManagementSystem
{
    public partial class Admin_ManageResults_Dashboard : Form
    {
        public Admin_ManageResults_Dashboard()
        {
            InitializeComponent();
        }

        private void Admin_ManageResults_Dashboard_Load(object sender, EventArgs e)
        {
            User u = UserSessionStore.Instance.getUser();
            helloMsg.Text = "Hello " + u.getuserID();

            Fill_addResult_class();
            Fill_addResult_examID();

            addResult_subject.Enabled = false;
            addResult_Year.Enabled = false;
            addResult_student.Enabled = false;
            addResult_ExamID.Enabled = false;
            addResult_Term.Enabled = false;
            addResult_mark.Enabled = false;

            fillDataGridView();
        }

        private void fillDataGridView()
        {
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                        SELECT sf.sID, sf.sCode, s.sName,sf.mark, sf.term, s.forGrade, sf.examID
                        FROM Student_follow_subject sf, Subject s
                        WHERE s.sCode = sf.sCode 
                        
                        SELECT sf.sID AS 'Student ID', sf.sCode AS 'Subject Code', s.sName AS 'Subject Name',sf.mark AS 'Mark', sf.term AS 'Term', s.forGrade AS 'Grade', sf.examID AS 'ExamID'
                        FROM Student_follow_subject sf, Subject s
                        WHERE s.sCode = sf.sCode
                 */


                command.CommandText = "SELECT sf.sID AS 'Student ID', sf.sCode AS 'Subject Code', s.sName AS 'Subject Name',sf.mark AS 'Mark', sf.term AS 'Term', s.forGrade AS 'Grade', sf.examID AS 'ExamID' FROM Student_follow_subject sf, Subject s WHERE s.sCode = sf.sCode";
               
                command.Prepare();

                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                connection.Close();
            }
        }

        private void Fill_addResult_examID()
        {
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM Exam";

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String examID = reader["examID"].ToString();
                    addResult_ExamID.Items.Add(examID);
                }
            }
        }

        void Fill_addResult_class()
        {
            string conString = CommonConstants.connnectionString;
           
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM ClassRoom";

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String classID = reader["classID"].ToString();
                    addResult_class.Items.Add(classID);
                }
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void addResult_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            addResult_subject.Enabled = true;
            addResult_Year.Enabled = true;
            addResult_ExamID.Enabled = true;
            addResult_Term.Enabled = true;

            string selectedItem = this.addResult_class.GetItemText(this.addResult_class.SelectedItem);

            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM Classroom_Subjects WHERE classID = @sclass";

                SqlParameter sclass = new SqlParameter("@sclass", SqlDbType.VarChar, 100);
                sclass.Value = selectedItem;
                command.Parameters.Add(sclass);

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String subject = reader["subject"].ToString();
                    addResult_subject.Items.Add(subject);
                }
                addResult_subject.SelectedIndex = 0;
            }




            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT DISTINCT year FROM Class_Student";

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                addResult_Year.Items.Clear();

                while (reader.Read())
                {
                    String year = reader["year"].ToString();
                    addResult_Year.Items.Add(year);
                }
                addResult_Year.SelectedIndex = 0;
            }
            

        }

        private void addResult_student_SelectedIndexChanged(object sender, EventArgs e)
        {
            addResult_mark.Enabled = true;
        }

        private void addResult_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            addResult_student.Enabled = true;

            string selectedClass = this.addResult_class.GetItemText(this.addResult_class.SelectedItem);
            string yr = this.addResult_Year.GetItemText(this.addResult_Year.SelectedItem);

            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM Class_Student WHERE year = @year AND classID = @class";

                SqlParameter year = new SqlParameter("@year", SqlDbType.Int, 100);
                year.Value = yr;
                command.Parameters.Add(year);

                SqlParameter class1 = new SqlParameter("@class", SqlDbType.VarChar, 100);
                class1.Value = selectedClass;
                command.Parameters.Add(class1);

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String sid = reader["sid"].ToString();
                    addResult_student.Items.Add(sid);
                }
                addResult_student.SelectedIndex = 0;
            }
        }

        private void addMark_Click(object sender, EventArgs e)
        {
            int tempResult;
            if (addResult_class.SelectedIndex == -1 ||  addResult_subject.SelectedIndex == -1 || addResult_Year.SelectedIndex == -1 ||  addResult_ExamID.SelectedIndex == -1 || addResult_Term.SelectedIndex == -1 || addResult_student.SelectedIndex == -1 || addResult_mark.Text == "")  {
                MessageBox.Show("All columns should be filled.");
            }
            else if (!(int.TryParse(addResult_mark.Text, out tempResult))) {
                MessageBox.Show("Mark is not a valid number");
            }
            else if (int.Parse(addResult_mark.Text) > 100 || int.Parse(addResult_mark.Text) < 0){
                MessageBox.Show("Mark should be in between 0 - 100");
            }
            else{
                string selectedClass = this.addResult_class.GetItemText(this.addResult_class.SelectedItem);
                string selectedSubject = this.addResult_subject.GetItemText(this.addResult_subject.SelectedItem);
                string selectedYear = this.addResult_Year.GetItemText(this.addResult_Year.SelectedItem);
                string selectedExamID = this.addResult_ExamID.GetItemText(this.addResult_ExamID.SelectedItem);
                string selectedTerm = this.addResult_Term.GetItemText(this.addResult_Term.SelectedItem);
                string selectedStudent = this.addResult_student.GetItemText(this.addResult_student.SelectedItem);
                string inputMark = addResult_mark.Text;

             //   MessageBox.Show("CLASS="+selectedClass+" SUBJECT="+selectedSubject+" YEAR="+selectedYear+" EXAMID="+selectedExamID+" TERM="+selectedTerm+ "STUDENT="+selectedStudent+" MARK="+inputMark);          
            
                //Adding student results to db
                string conString = CommonConstants.connnectionString;

               using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection);
                   
                    command.CommandText = "insert into student_follow_subject values(@sid,@scode,@mark,@examid,@term)";
                    SqlParameter sid = new SqlParameter("@sid", SqlDbType.VarChar, 100);
                    sid.Value = selectedStudent;
                    command.Parameters.Add(sid);

                    SqlParameter scode = new SqlParameter("@scode", SqlDbType.VarChar, 100);
                    scode.Value = selectedSubject;
                    command.Parameters.Add(scode);

                    SqlParameter mark = new SqlParameter("@mark", SqlDbType.Int, 100);
                    mark.Value = int.Parse(inputMark);
                    command.Parameters.Add(mark);

                    SqlParameter examid = new SqlParameter("@examid", SqlDbType.VarChar, 100);
                    examid.Value = selectedExamID;
                    command.Parameters.Add(examid);

                    SqlParameter term = new SqlParameter("@term", SqlDbType.Int, 100);
                    term.Value = int.Parse(selectedTerm);
                    command.Parameters.Add(term);

                    // call prepare after setting the commandtext and parameters.
                    
                    command.Prepare();
                    
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("student results added successfully.");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Result is already in the database.");
                    }
                }
               // adding student results end

            }
            fillDataGridView();
        }



        private void SearchStudent_Click(object sender, EventArgs e)
        {
            StdResultSheetWindow srs = new StdResultSheetWindow();
            srs.Show();
        }

        private void deleteRes_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to delete student result?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Deleting Student Result Start
                string conString = CommonConstants.connnectionString;
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection);

                    command.CommandText = "DELETE FROM Student_follow_subject WHERE sID = @sID AND sCode=@sCode";




                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string studentID_from_table = Convert.ToString(selectedRow.Cells["Student ID"].Value);
                    string subjectCode_from_table = Convert.ToString(selectedRow.Cells["Subject Code"].Value);




                    SqlParameter sID = new SqlParameter("@sID", SqlDbType.VarChar, 100);
                    sID.Value = studentID_from_table;
                    command.Parameters.Add(sID);

                    SqlParameter sCode = new SqlParameter("@sCode", SqlDbType.VarChar, 100);
                    sCode.Value = subjectCode_from_table;
                    command.Parameters.Add(sCode);

                    command.Prepare();
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Result Deleted Successfully");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error while deleting result." + ex);
                    }
                }
                //Deleting student Result End    
                fillDataGridView();
            }
            else if (dialogResult == DialogResult.No)
            {
            
            }
        }

        private void updateRes_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            string studentID_from_table = Convert.ToString(selectedRow.Cells["Student ID"].Value);
            string subjectCode_from_table = Convert.ToString(selectedRow.Cells["Subject Code"].Value);
            string subjectName_from_table = Convert.ToString(selectedRow.Cells["Subject Name"].Value);
            string studentGrade_from_table = Convert.ToString(selectedRow.Cells["Grade"].Value);
            string examID_from_table = Convert.ToString(selectedRow.Cells["ExamID"].Value);
            int mark_from_db = Convert.ToInt32(selectedRow.Cells["Mark"].Value);
            int term_from_db = Convert.ToInt32(selectedRow.Cells["Term"].Value);

            updateResults objUpdateResults = new updateResults();

            Student stdtemp = new Student();
            stdtemp.SID = studentID_from_table;
            stdtemp.SubjectCode = subjectCode_from_table;
            stdtemp.SubjectName = subjectName_from_table;
            stdtemp.StudentGrade = studentGrade_from_table;
            stdtemp.ExamID = examID_from_table;
            stdtemp.Mark = mark_from_db;
            stdtemp.Term = term_from_db;

            objUpdateResults.Std = stdtemp;
            objUpdateResults.Show(); 
            

        }

        private void refresh_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            fillDataGridView();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void backASM_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminDashboard obj = new AdminDashboard();
            obj.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();

        }

        private void btnReportAll_Click(object sender, EventArgs e)
        {
            generateReportAllResults();
        }

        private void generateReportAllResults()
        {
            try
            {
                var savefiledialog = new SaveFileDialog();
                savefiledialog.FileName = "ResultSheet of All Students";
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

                        //Add school logo code end
                        Paragraph p = new Paragraph("\n\n\n\n\n\n\n\n\n\n\n");
                        document.Add(p);


                        //Table Add start
                        PdfPTable pdfTable = new PdfPTable(7);

                        //Adding Header row
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                            pdfTable.AddCell(cell);
                        }

                        foreach (DataGridViewRow row in dataGridView1.Rows)
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


                        Paragraph p1 = new Paragraph("\n\n\n\n\n\n\n\n\n\n\n");
                        document.Add(p1);

                        //Final note start
                        DateTime now = DateTime.Now;
                        Paragraph pEnd = new Paragraph("- System generated result sheet on " + now + " - ");
                        document.Add(pEnd);
                        //Final note end


                        //Document close
                        document.Close();

                        stream.Close();
                    }
                }

                MessageBox.Show("ResultSheet of All Students.pdf saved successfully.");
            }
            catch(IOException ex1)
            {
                MessageBox.Show("File Already open. Please close it.");
            }catch(Exception e1)
            {
                MessageBox.Show("Error: " + e1);
            }


        }
    }
}
