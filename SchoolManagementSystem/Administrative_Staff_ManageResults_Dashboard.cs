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
    public partial class Administrative_Staff_ManageResults_Dashboard : Form
    {
        public Administrative_Staff_ManageResults_Dashboard()
        {
            InitializeComponent();
        }

        private void Administrative_Staff_ManageResults_Dashboard_Load(object sender, EventArgs e)
        {
            User u = UserSessionStore.Instance.getUser();
            helloMsg.Text = "Hello " + u.getuserID();

            teacherNamelbl.Visible = false;

            fillTopStudentsDGV();

            fillClassIDCombobox();
        }

        private void fillClassIDCombobox()
        {
            fillClassIDComboboxCompleteCode();
            fillTermCombobox();
        }

        private void fillTermCombobox()
        {
            fillTermComboboxCompleteCode();
            fillYearCombobox();
        }


        private void fillYearCombobox()
        {
            fillYearComboboxCompleteCode();
        }


        private void fillClassIDComboboxCompleteCode()
        {
            //Fill class ID - start
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT classID FROM ClassRoom";

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String classRoom = reader["classID"].ToString();
                    classID.Items.Add(classRoom);
                }
                classID.SelectedIndex = 0;
                connection.Close();
            }
            //Fill class ID - end
        }

        private void fillTermComboboxCompleteCode()
        {
            //Fill Term - start
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT distinct term FROM Student_follow_subject";

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String trm = reader["term"].ToString();
                    term.Items.Add(trm);
                }
                term.SelectedIndex = 0;
                connection.Close();
            }
            //Fill Term - end
        }

        private void fillYearComboboxCompleteCode()
        {
            //Fill Year - start
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT distinct year FROM Class_Student";

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String yr = reader["year"].ToString();
                    year.Items.Add(yr);
                }
                year.SelectedIndex = 0;
                connection.Close();
            }
            //Fill Year - end
        }



        private void fillTopStudentsDGV() 
        {
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                SELECT Student.sID, Student.fName, Student.mName, Student.lName, Class_Student.classID, Student_Rank.year, Student_Rank.rank
                FROM Student, Class_Student,Student_Rank
                WHERE Student.sID = Student_Rank.sID AND Class_Student.sid = Student.sID
                AND rank in(1,2,3,4,5)
                ORDER BY classID,rank
                */

                command.CommandText = "SELECT Student.sID, Student.fName, Student.mName, Student.lName, Class_Student.classID, Student_Rank.year, Student_Rank.rank,  Student_Rank.term FROM Student, Class_Student, Student_Rank WHERE Student.sID = Student_Rank.sID AND Class_Student.sid = Student.sID AND rank in(1,2,3) ORDER BY classID,term,rank";

                command.Prepare();

                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                topStudentsDGV.DataSource = dt;
                
                connection.Close();
            }
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void goBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ASTFMarksAddUpdateDelete_Click(object sender, EventArgs e)
        {
            Administrative_Staff_Marks_CRUD_Dashboard objAstfCrudDashboard = new Administrative_Staff_Marks_CRUD_Dashboard();
            objAstfCrudDashboard.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void generateSummary_Click(object sender, EventArgs e)
        {

            string selected_classID = this.classID.GetItemText(this.classID.SelectedItem);
            string selected_term = this.term.GetItemText(this.term.SelectedItem);
            string selected_year = this.year.GetItemText(this.year.SelectedItem);
           

            string teacher_name = findClassTeacher(selected_classID , selected_year);
            //MessageBox.Show(teacher_name);
            teacherNamelbl.Visible = true;
            teacherNamelbl.Text = "Class Teacher of "+ selected_classID +" in "+ selected_year +" => "+ teacher_name;



        }

        private string findClassTeacher(string selected_classID , string selected_year)
        {
            string conString = CommonConstants.connnectionString;
            string teacher_name="";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                    SELECT Staff.stfID AS 'stfID', Staff.fName AS 'fName', Staff.lName AS 'lName', Class_Teacher.classID AS 'classID', Class_Teacher.year AS 'year'
                    FROM Staff, Academic_Staff, Class_Teacher
                    WHERE Staff.stfID = Academic_Staff.stfID AND Academic_Staff.stfID = Class_Teacher.stfID
                    AND Class_Teacher.classID= '06A' AND Class_Teacher.year = 2019
                */

                command.CommandText = "SELECT Staff.stfID AS 'stfID', Staff.fName AS 'fName', Staff.lName AS 'lName', Class_Teacher.classID AS 'classID', Class_Teacher.year AS 'year'   FROM Staff, Academic_Staff, Class_Teacher    WHERE Staff.stfID = Academic_Staff.stfID AND Academic_Staff.stfID = Class_Teacher.stfID     AND Class_Teacher.classID = @classID AND Class_Teacher.year = @year";

                SqlParameter classID = new SqlParameter("@classID", SqlDbType.VarChar, 100);
                classID.Value = selected_classID;
                command.Parameters.Add(classID);

                SqlParameter year = new SqlParameter("@year", SqlDbType.Int, 100);
                year.Value = selected_year;
                command.Parameters.Add(year);

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    teacher_name = reader["fName"].ToString()+" " + reader["lName"].ToString();
                }
                connection.Close();
            }
            return teacher_name;
        }
    }
}
