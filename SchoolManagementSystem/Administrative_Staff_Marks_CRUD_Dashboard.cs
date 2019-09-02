using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class Administrative_Staff_Marks_CRUD_Dashboard : Form
    {
        bool found = false;

        public Administrative_Staff_Marks_CRUD_Dashboard()
        {
            InitializeComponent();
        }

        private void Administrative_Staff_Marks_CRUD_Dashboard_Load(object sender, EventArgs e)
        {
            Fill_addResult_class();
            fillDataGridView_Results_All_Students();
        }

        private void fillDataGridView_Results_All_Students()
        {
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                        SELECT sf.sID AS 'Student ID', sf.sCode AS 'Subject Code', s.sName AS 'Subject Name',sf.mark AS 'Mark', sf.term AS 'Term', s.forGrade AS 'Grade', cs.classID AS 'ClassID',sf.examID AS 'ExamID'
                        FROM Student_follow_subject sf, Subject s, Class_Student cs
                        WHERE s.sCode = sf.sCode AND sf.sID = cs.sid
                        ORDER BY ClassID
                 */


                command.CommandText = "SELECT sf.sID AS 'Student ID', sf.sCode AS 'Subject Code', s.sName AS 'Subject Name',sf.mark AS 'Mark', sf.term AS 'Term', s.forGrade AS 'Grade', cs.classID AS 'ClassID',sf.examID AS 'ExamID'  FROM Student_follow_subject sf, Subject s, Class_Student cs  WHERE s.sCode = sf.sCode AND sf.sID = cs.sid  ORDER BY ClassID";

                command.Prepare();

                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                dataGridView_Results_All_Students.DataSource = dt;

                connection.Close();
            }
        }

        private void Fill_addResult_class()
        {
            addResult_class.Items.Clear();

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
                addResult_class.SelectedIndex = 0;
            }
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            
        }

        private void addMark_Click(object sender, EventArgs e)
        {
            int tempResult;

            if (found == false)
            {
                //MessageBox.Show("Not Found");
                //Adding marks to the database - start

                if (addResult_class.SelectedIndex == -1 || addResult_subject.SelectedIndex == -1 || addResult_Year.SelectedIndex == -1 || addResult_ExamID.SelectedIndex == -1 || addResult_Term.SelectedIndex == -1 || addResult_student.SelectedIndex == -1 || addResult_mark.Text == "")
                {
                    MessageBox.Show("All columns should be filled.");
                }
                else if (!(int.TryParse(addResult_mark.Text, out tempResult)))
                {
                    MessageBox.Show("Mark is not a valid number.");
                }
                else if (int.Parse(addResult_mark.Text) > 100 || int.Parse(addResult_mark.Text) < 0)
                {
                    MessageBox.Show("Mark should be in between 0 - 100");
                }
                else
                {
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
                        connection.Close();
                    }

                }
                //Adding marks to the database - end
            }
            else if (found==true){

                //MessageBox.Show("Found");

                if (addResult_class.SelectedIndex == -1 || addResult_subject.SelectedIndex == -1 || addResult_Year.SelectedIndex == -1 || addResult_ExamID.SelectedIndex == -1 || addResult_Term.SelectedIndex == -1 || addResult_student.SelectedIndex == -1 || addResult_mark.Text == "")
                {
                    MessageBox.Show("All columns should be filled.");
                }
                else if (!(int.TryParse(addResult_mark.Text, out tempResult)))
                {
                    MessageBox.Show("Mark is not a valid number.");
                }
                else if (int.Parse(addResult_mark.Text) > 100 || int.Parse(addResult_mark.Text) < 0)
                {
                    MessageBox.Show("Mark should be in between 0 - 100");
                }
                else
                {

                    //update mark of found student - start
                    string selectedStudent = this.addResult_student.GetItemText(this.addResult_student.SelectedItem);
                    string selectedSubject = this.addResult_subject.GetItemText(this.addResult_subject.SelectedItem);
                    string selectedExamID = this.addResult_ExamID.GetItemText(this.addResult_ExamID.SelectedItem);
                    string selectedTerm = this.addResult_Term.GetItemText(this.addResult_Term.SelectedItem);
                    string inputMark = addResult_mark.Text;


                    string conString = CommonConstants.connnectionString;

                    using (SqlConnection connection = new SqlConnection(conString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(null, connection);

                        /*
                        UPDATE Student_follow_subject
                        SET mark = 93
                        WHERE sID = 'S00001' AND sCode = 'A001' AND examID = 'E002' AND term = 1
                        */

                        command.CommandText = "UPDATE Student_follow_subject SET mark = @mark WHERE sID = @sid AND sCode = @scode AND examID = @examid AND term = @term";

                        SqlParameter mark = new SqlParameter("@mark", SqlDbType.Int, 100);
                        mark.Value = int.Parse(inputMark);
                        command.Parameters.Add(mark);

                        SqlParameter sid = new SqlParameter("@sid", SqlDbType.VarChar, 100);
                        sid.Value = selectedStudent;
                        command.Parameters.Add(sid);

                        SqlParameter scode = new SqlParameter("@scode", SqlDbType.VarChar, 100);
                        scode.Value = selectedSubject;
                        command.Parameters.Add(scode);

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
                            MessageBox.Show("marks updated successfully.");
                            addResult_mark.Text = "";
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Error while updating marks.");
                        }
                        connection.Close();
                    }

                }

                //update mark of found student - end
            }
            fillDataGridView_Results_All_Students();
        }

        private void addResult_class_SelectedValueChanged(object sender, EventArgs e)
        {
            fillSubjects();
           
        }



        private void fillSubjects()
        {
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                string selected_class = addResult_class.SelectedItem.ToString();

                //SELECT subject  FROM ClassRoom_Subjects HERE classID = '06A'

                command.CommandText = "SELECT subject FROM ClassRoom_Subjects WHERE classID = @class";



                SqlParameter sclass = new SqlParameter("@class", SqlDbType.VarChar, 100);
                sclass.Value = selected_class;
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
        }

        private void addResult_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            addResult_Year.Items.Clear();
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                string selected_class = addResult_class.SelectedItem.ToString();
                
                command.CommandText = "SELECT distinct year FROM Class_Student";

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String years = reader["year"].ToString();
                    addResult_Year.Items.Add(years);
                }
                addResult_Year.SelectedIndex = 0;
            }

            
        }

        private void addResult_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            addResult_ExamID.Items.Clear();
            string conString = CommonConstants.connnectionString;
            
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);
                
                command.CommandText = "SELECT distinct examID FROM Exam";

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String examID = reader["examID"].ToString();
                    addResult_ExamID.Items.Add(examID);
                }
                addResult_ExamID.SelectedIndex = 0;
            }


            addResult_Term.SelectedIndex = 0;

            fillStudents();
            addResult_mark.Text = "";
        }

                private void fillStudents()
                {
                    string conString = CommonConstants.connnectionString;

                    using (SqlConnection connection = new SqlConnection(conString))
                    {
                        addResult_student.Items.Clear();
                        connection.Open();
                        SqlCommand command = new SqlCommand(null, connection);

                        string selected_class = addResult_class.SelectedItem.ToString();
                        string selected_year = addResult_Year.SelectedItem.ToString();

                        /*
                        SELECT sid
                        FROM Class_Student
                        WHERE classID = '06A' AND year = 2019
                        */

                        command.CommandText = "SELECT sid FROM Class_Student WHERE classID = @studentClass AND year = @studentYear";


                        SqlParameter studentClass = new SqlParameter("@studentClass", SqlDbType.VarChar, 100);
                        studentClass.Value = selected_class;
                        command.Parameters.Add(studentClass);

                        SqlParameter studentYear = new SqlParameter("@studentYear", SqlDbType.Int, 100);
                        studentYear.Value = selected_year;
                        command.Parameters.Add(studentYear);
                
                        // Call Prepare after setting the Commandtext and Parameters.
                        command.Prepare();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            String sid = reader["sid"].ToString();
                            addResult_student.Items.Add(sid);
                        }
                        
                        //if (counterSelectedStudentLoop != 0)
                        //{
                        //    addResult_student.SelectedIndex = 0;
                        //}
                        // counterSelectedStudentLoop++;           

                        connection.Close();
                    }
             }

        private void addResult_student_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillMarksboxIfAvailable();
        }

        private void fillMarksboxIfAvailable()
        {
            string selectedClass = this.addResult_class.GetItemText(this.addResult_class.SelectedItem);
            string selectedSubject = this.addResult_subject.GetItemText(this.addResult_subject.SelectedItem);
            string selectedYear = this.addResult_Year.GetItemText(this.addResult_Year.SelectedItem);
            string selectedExamID = this.addResult_ExamID.GetItemText(this.addResult_ExamID.SelectedItem);
            string selectedTerm = this.addResult_Term.GetItemText(this.addResult_Term.SelectedItem);
            string selectedStudent = this.addResult_student.GetItemText(this.addResult_student.SelectedItem);
            string inputMark = addResult_mark.Text;

            

            //Checking marks in db
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                SELECT*
                FROM Student_follow_subject
                WHERE sID = 'S00001' AND sCode = 'A002' AND examID = 'E002' AND term = 1
                */

                // command.CommandText = "SELECT * FROM Student_follow_subject WHERE sID = 'S00001' AND sCode = 'A002' AND examID = 'E002' AND term = 1";
                // MessageBox.Show(selectedStudent+" "+ selectedSubject+" "+ selectedExamID+" "+ selectedTerm);

                command.CommandText = "SELECT * FROM Student_follow_subject WHERE sID = @sid AND sCode = @scode AND examID = @examid AND term = @term";

                SqlParameter sid = new SqlParameter("@sid", SqlDbType.VarChar, 100);
                sid.Value = selectedStudent;
                command.Parameters.Add(sid);

                SqlParameter scode = new SqlParameter("@scode", SqlDbType.VarChar, 100);
                scode.Value = selectedSubject;
                command.Parameters.Add(scode);

                SqlParameter examid = new SqlParameter("@examid", SqlDbType.VarChar, 100);
                examid.Value = selectedExamID;
                command.Parameters.Add(examid);

                SqlParameter term = new SqlParameter("@term", SqlDbType.Int, 100);
                term.Value = selectedTerm;
                command.Parameters.Add(term);

                // call prepare after setting the commandtext and parameters.

                command.Prepare();

                SqlDataReader reader = command.ExecuteReader();

                found = false;

                while (reader.Read())
                {
                    String mark = reader["mark"].ToString();
                    addResult_mark.Text = mark;
                    found = true;
                }
                if (found == false)
                {
                    addResult_mark.Text = "";
                }
                
                connection.Close();
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void deleteResult_Click(object sender, EventArgs e)
        {
            string Stdclass = addResult_class.SelectedItem.ToString();
            string Stdsubject = addResult_subject.SelectedItem.ToString();
            string StdYear = addResult_Year.SelectedItem.ToString();
            string StdExamID = addResult_ExamID.SelectedItem.ToString();
            string StdTerm = addResult_Term.SelectedItem.ToString();
            string Std = addResult_student.SelectedItem.ToString();

            if(Stdclass==""|| Stdsubject==""|| StdYear==""|| StdExamID== "" || StdTerm == ""|| Std == "")
            {
                MessageBox.Show("All fields must be selected");
            }else
            {
                    //Delete result - code start
                    string conString = CommonConstants.connnectionString;

                    using (SqlConnection connection = new SqlConnection(conString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(null, connection);

                    //DELETE FROM Student_follow_subject WHERE sID='S00001' AND sCode='A002' AND examID ='E002' AND term = 1;

             

                        command.CommandText = "DELETE FROM Student_follow_subject WHERE sID=@sid AND sCode=@scode AND examID =@examid AND term = @term";

                        SqlParameter sid = new SqlParameter("@sid", SqlDbType.VarChar, 100);
                        sid.Value = Std;
                        command.Parameters.Add(sid);

                        SqlParameter scode = new SqlParameter("@scode", SqlDbType.VarChar, 100);
                        scode.Value = Stdsubject;
                        command.Parameters.Add(scode);

                        SqlParameter examid = new SqlParameter("@examid", SqlDbType.VarChar, 100);
                        examid.Value = StdExamID;
                        command.Parameters.Add(examid);

                        SqlParameter term = new SqlParameter("@term", SqlDbType.Int, 100);
                        term.Value = StdTerm;
                        command.Parameters.Add(term);

                        // call prepare after setting the commandtext and parameters.

                        command.Prepare();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Result Deleted Successfully");
                        connection.Close();
                    }
                    //Delete result - code end
            }
            fillDataGridView_Results_All_Students();
        }

        private void refreshDatagridView_Click(object sender, EventArgs e)
        {
            fillDataGridView_Results_All_Students();
        }

        private void addResult_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            addResult_student.Items.Clear();
            addResult_mark.Text = "";
        }

        private void SearchResultByStudentID_TextChanged(object sender, EventArgs e)
        {
            //Search Result By Student ID - start
            string conString = CommonConstants.connnectionString;
            string studentIDForSearchResult = SearchResultByStudentID.Text.ToString();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                       SELECT sf.sID AS 'Student ID', sf.sCode AS 'Subject Code', s.sName AS 'Subject Name',sf.mark AS 'Mark', sf.term AS 'Term', s.forGrade AS 'Grade', cs.classID AS 'ClassID',sf.examID AS 'ExamID'
                       FROM Student_follow_subject sf, Subject s, Class_Student cs
                       WHERE s.sCode = sf.sCode AND sf.sID = cs.sid AND sf.sID=@sid
                       ORDER BY ClassID
                */

                command.CommandText = "SELECT sf.sID AS 'Student ID', sf.sCode AS 'Subject Code', s.sName AS 'Subject Name',sf.mark AS 'Mark', sf.term AS 'Term', s.forGrade AS 'Grade', cs.classID AS 'ClassID',sf.examID AS 'ExamID' FROM Student_follow_subject sf, Subject s, Class_Student cs WHERE s.sCode = sf.sCode AND sf.sID = cs.sid AND sf.sID LIKE @sid ORDER BY ClassID";

                SqlParameter sid = new SqlParameter("@sid", SqlDbType.VarChar, 100);
                sid.Value = "%"+studentIDForSearchResult+"%";
                command.Parameters.Add(sid);

                command.Prepare();
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                dataGridView_Results_All_Students.DataSource = dt;

                connection.Close();
            }

            //Search Result By Student ID - end
        }

        private void backASM_Click(object sender, EventArgs e)
        {
            this.Close();
            Administrative_Staff_ManageResults_Dashboard obj = new Administrative_Staff_ManageResults_Dashboard();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();

        }
    }



}
