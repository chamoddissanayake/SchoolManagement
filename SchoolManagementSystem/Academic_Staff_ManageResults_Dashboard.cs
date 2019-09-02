using SchoolManagementSystem.Model;
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
    public partial class Academic_Staff_ManageResults_Dashboard : Form
    {
        public Academic_Staff_ManageResults_Dashboard()
        {
            InitializeComponent();
        }
        User u;
        private void Academic_Staff_ManageResults_Dashboard_Load(object sender, EventArgs e)
        {
             u = UserSessionStore.Instance.getUser();
            helloMsg.Text = "Hello " + u.getuserID();

            filldataGridViewClassResult();
        }

        private void filldataGridViewClassResult()
        {
            //filling data grid view - start
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                        SELECT sf.sID AS 'Student ID',std.fName AS 'First Name',std.mName AS 'Middle Name',std.lName AS 'Last Name',sf.sCode AS 'Subject Code', s.sName AS 'Subject Name',sf.mark AS 'Mark', sf.term AS 'Term', s.forGrade AS 'Grade',sf.examID AS 'ExamID'
                        FROM Student_follow_subject sf, Subject s, Class_Student cs , Student std
                        WHERE s.sCode = sf.sCode AND sf.sID = cs.sid AND cs.sid = std.sID AND cs.classID IN(
																					                        SELECT classID
																					                        FROM Class_Teacher
																					                        WHERE stfID ='STF001'
																					                        )
                        Order by sf.term, sf.sID
                 */


                command.CommandText = "SELECT sf.sID AS 'Student ID',std.fName AS 'First Name',std.mName AS 'Middle Name',std.lName AS 'Last Name',sf.sCode AS 'Subject Code', s.sName AS 'Subject Name',sf.mark AS 'Mark', sf.term AS 'Term', s.forGrade AS 'Grade',sf.examID AS 'ExamID'  FROM Student_follow_subject sf, Subject s, Class_Student cs , Student std    WHERE s.sCode = sf.sCode AND sf.sID = cs.sid AND cs.sid = std.sID AND cs.classID IN( SELECT classID FROM Class_Teacher  WHERE stfID = @stfID ) Order by sf.term, sf.sID";

                SqlParameter stfID = new SqlParameter("@stfID", SqlDbType.VarChar, 100);
                stfID.Value = u.getuserID();
                command.Parameters.Add(stfID);

                command.Prepare();

                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                dataGridViewClassResult.DataSource = dt;

                connection.Close();
            }
            //filling data grid view - end
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            this.Close();
            AcademicStaffDashBoard obj = new AcademicStaffDashBoard();
            obj.Show();
        }

        private void sendMessage_Click(object sender, EventArgs e)
        {
            EmailSendInterface objEmailsend = new EmailSendInterface();
            objEmailsend.Show();
        }

        private void summaryOfResults_Click(object sender, EventArgs e)
        {
            this.Hide();
            Academic_Staff_Summary_Of_Results ObjAcdStfSumResult = new Academic_Staff_Summary_Of_Results();
            ObjAcdStfSumResult.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void teacherSearchStudentResultByID_TextChanged(object sender, EventArgs e)
        {
            //Teacher seratch Student Result By ID - start
            string conString = CommonConstants.connnectionString;
            string studentIDForSearchResult = teacherSearchStudentResultByID.Text.ToString();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                       SELECT sf.sID AS 'Student ID',std.fName AS 'First Name',std.mName AS 'Middle Name',std.lName AS 'Last Name',sf.sCode AS 'Subject Code', s.sName AS 'Subject Name',sf.mark AS 'Mark', sf.term AS 'Term', s.forGrade AS 'Grade',sf.examID AS 'ExamID'
                        FROM Student_follow_subject sf, Subject s, Class_Student cs , Student std
                        WHERE s.sCode = sf.sCode AND sf.sID = cs.sid AND cs.sid = std.sID AND sf.sID LIKE @sid AND cs.classID IN(
																					                                            SELECT classID
																					                                            FROM Class_Teacher
																					                                            WHERE stfID ='STF001'
																					                                            )  
                        Order by sf.term, sf.sID
                */

                command.CommandText = "SELECT sf.sID AS 'Student ID',std.fName AS 'First Name',std.mName AS 'Middle Name',std.lName AS 'Last Name',sf.sCode AS 'Subject Code', s.sName AS 'Subject Name',sf.mark AS 'Mark', sf.term AS 'Term', s.forGrade AS 'Grade',sf.examID AS 'ExamID' FROM Student_follow_subject sf, Subject s, Class_Student cs , Student std  WHERE s.sCode = sf.sCode AND sf.sID = cs.sid AND cs.sid = std.sID AND sf.sID LIKE @sid AND cs.classID IN( SELECT classID FROM Class_Teacher  WHERE stfID = @tid) Order by sf.term, sf.sID";

                SqlParameter sid = new SqlParameter("@sid", SqlDbType.VarChar, 100);
                sid.Value = "%" + studentIDForSearchResult + "%";
                command.Parameters.Add(sid);

                SqlParameter tid = new SqlParameter("@tid", SqlDbType.VarChar, 100);
                tid.Value = u.getuserID() ;
                command.Parameters.Add(tid);
                
                command.Prepare();
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                dataGridViewClassResult.DataSource = dt;

                connection.Close();
            }
            //Teacher seratch Student Result By ID - end
        }

        private void teacherSearchStudentResultByName_TextChanged(object sender, EventArgs e)
        {
            //Teacher seratch Student Result By ID - start
            string conString = CommonConstants.connnectionString;
            string studentNameForSearchResult = teacherSearchStudentResultByName.Text.ToString();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                       SELECT sf.sID AS 'Student ID',std.fName AS 'First Name',std.mName AS 'Middle Name',std.lName AS 'Last Name',sf.sCode AS 'Subject Code', s.sName AS 'Subject Name',sf.mark AS 'Mark', sf.term AS 'Term', s.forGrade AS 'Grade',sf.examID AS 'ExamID'
                        FROM Student_follow_subject sf, Subject s, Class_Student cs , Student std
                        WHERE s.sCode = sf.sCode AND sf.sID = cs.sid AND cs.sid = std.sID AND sf.sID LIKE @sid AND cs.classID IN(
																					                                            SELECT classID
																					                                            FROM Class_Teacher
																					                                            WHERE stfID ='STF001'
																					                                            )  
                        Order by sf.term, sf.sID





                // New
                SELECT sf.sID AS 'Student ID',std.fName AS 'First Name',std.mName AS 'Middle Name',std.lName AS 'Last Name',sf.sCode AS 'Subject Code', s.sName AS 'Subject Name',sf.mark AS 'Mark', sf.term AS 'Term', s.forGrade AS 'Grade',sf.examID AS 'ExamID'
                FROM Student_follow_subject sf, Subject s, Class_Student cs , Student std
                WHERE s.sCode = sf.sCode AND sf.sID = cs.sid AND cs.sid = std.sID AND (std.fName LIKE 'Kasun' OR  std.mName LIKE 'Kasun' OR std.lName LIKE 'Kasun')
	            AND cs.classID IN(
					            SELECT classID
					            FROM Class_Teacher
					            WHERE stfID ='STF001'
					            ) 
                */

                command.CommandText = "SELECT sf.sID AS 'Student ID',std.fName AS 'First Name',std.mName AS 'Middle Name',std.lName AS 'Last Name',sf.sCode AS 'Subject Code', s.sName AS 'Subject Name',sf.mark AS 'Mark', sf.term AS 'Term', s.forGrade AS 'Grade',sf.examID AS 'ExamID' FROM Student_follow_subject sf, Subject s, Class_Student cs , Student std   WHERE s.sCode = sf.sCode AND sf.sID = cs.sid AND cs.sid = std.sID AND(std.fName LIKE @stdNameForSearchResult OR  std.mName LIKE @stdNameForSearchResult OR std.lName LIKE @stdNameForSearchResult)  AND cs.classID IN( SELECT classID  FROM Class_Teacher  WHERE stfID = @tid ) Order by sf.term, sf.sID";

                SqlParameter sName = new SqlParameter("@stdNameForSearchResult", SqlDbType.VarChar, 100);
                sName.Value = "%" + studentNameForSearchResult + "%";
                command.Parameters.Add(sName);

                SqlParameter tid = new SqlParameter("@tid", SqlDbType.VarChar, 100);
                tid.Value = u.getuserID();
                command.Parameters.Add(tid);

                command.Prepare();
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                dataGridViewClassResult.DataSource = dt;

                connection.Close();
            }
            //Teacher seratch Student Result By ID - end
        }

        private void backAA_Click(object sender, EventArgs e)
        {
            this.Close();
            AcademicStaffDashBoard obj = new AcademicStaffDashBoard();
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
