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

            fillTopStudentsDGV();
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
    }
}
