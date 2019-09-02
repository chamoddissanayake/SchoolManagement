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
    public partial class Academic_Staff_Summary_Of_Results : Form
    {
        public Academic_Staff_Summary_Of_Results()
        {
            InitializeComponent();
        }
        User u;
        private void Academic_Staff_Summary_Of_Results_Load(object sender, EventArgs e)
        {
            u = UserSessionStore.Instance.getUser();
            helloMsg.Text = "Hello " + u.getuserID();

            fillTerm();
            
        }



        private void fillTerm()
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
            fillYear();
        }

        private void fillYear()
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

        private void calculateAverage()
        {
            
        }

        private void goBack_Click(object sender, EventArgs e)
        {
         
        }

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void generateSummary_Click(object sender, EventArgs e)
        {
            
            string selected_term = this.term.GetItemText(this.term.SelectedItem);
            string selected_year = this.year.GetItemText(this.year.SelectedItem);
            string loggedTeacherID = u.getuserID();
            string classID="";

            //getclassID - start
            string conString = CommonConstants.connnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                /*
                SELECT*
                FROM Class_Teacher
                WHERE stfID = 'STF001' AND year = 2019
                */

               command.CommandText = "SELECT * FROM Class_Teacher WHERE stfID = @stfID AND year = @year";

                SqlParameter stfID = new SqlParameter("@stfID", SqlDbType.VarChar, 100);
                stfID.Value = loggedTeacherID;
                command.Parameters.Add(stfID);

                SqlParameter year = new SqlParameter("@year", SqlDbType.Int, 100);
                year.Value = selected_year;
                command.Parameters.Add(year);

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    classID = reader["classID"].ToString();
                }
                connection.Close();
            }
            //getclassID - end

            /*
           
                SELECT s.sName AS 'Subject Code', AVG(sf.mark) AS 'Mark'
                FROM Student_follow_subject sf, Subject s, Class_Student cs , Student std, Class_Teacher ct
                WHERE s.sCode = sf.sCode AND sf.sID = cs.sid AND cs.sid = std.sID AND cs.classID = ct.classID AND ct.stfID ='STF001' AND ct.year = 2019 AND sf.term = 1 AND cs.classID = '06A'
                Group by s.sName
            */

            //Get Avearge results form db -start

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT s.sName AS 'Subject Name', AVG(sf.mark) AS 'AvgMark' FROM Student_follow_subject sf, Subject s, Class_Student cs , Student std, Class_Teacher ct WHERE s.sCode = sf.sCode AND sf.sID = cs.sid AND cs.sid = std.sID AND cs.classID = ct.classID AND ct.stfID = @stfID AND ct.year = @year AND sf.term = @term AND cs.classID = @classID Group by s.sName";
                 // @term @
                
                SqlParameter stfID = new SqlParameter("@stfID", SqlDbType.VarChar, 100);
                stfID.Value = loggedTeacherID;
                command.Parameters.Add(stfID);

                SqlParameter year = new SqlParameter("@year", SqlDbType.Int, 100);
                year.Value = selected_year;
                command.Parameters.Add(year);

                SqlParameter term = new SqlParameter("@term", SqlDbType.Int, 100);
                term.Value = selected_term;
                command.Parameters.Add(term);

                SqlParameter clsID = new SqlParameter("@classID", SqlDbType.VarChar, 100);
                clsID.Value = classID;
                command.Parameters.Add(clsID);

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();


                string[] Subject_Name_Array = new string[30];
                int[] Subject_Average_Mark_Array = new int[30];
                int counter = 0;

                while (reader.Read())
                {

                    Subject_Name_Array[counter] = reader["Subject Name"].ToString();
                    Subject_Average_Mark_Array[counter] = int.Parse( reader["AvgMark"].ToString());
                    counter++;
                }
                
                connection.Close();
                drawGraph(Subject_Name_Array, Subject_Average_Mark_Array, counter);
            }
            //Get Avearge results form db -end
            
       }

        private void drawGraph(string[] subject_Name_Array, int[] subject_Average_Mark_Array, int counter)
        {
            this.AverageBySubjectChart.Series["AverageMark"].Points.Clear();
            //for (int i = 0; i < counter; i++)
            //{
            //    this.AverageBySubjectChart.Series["AverageMark"].Points.AddXY(subject_Name_Array[i], subject_Average_Mark_Array[i]);
            //}


            Dictionary<string, int> AverageMarks = new Dictionary<string, int>();

            //AverageMarks.Add("Subject 1", 20);
            //AverageMarks.Add("Subject 2", 50);
            //AverageMarks.Add("Subject 3", 30);
            //AverageMarks.Add("Subject 4", 60);
            //AverageMarks.Add("Subject 5", 70);
            //AverageMarks.Add("Subject 6", 20);
            //AverageMarks.Add("Subject 7", 50);
            //AverageMarks.Add("Subject 8", 90);
            //AverageMarks.Add("Subject 9", 30);
            // AverageMarks.Add("Subject 10", 30);

            for (int i = 0; i < 9; i++)
            {
                AverageMarks.Add(subject_Name_Array[i], subject_Average_Mark_Array[i]);
            }


            foreach (KeyValuePair<string, int> avgMarks in AverageMarks)
                AverageBySubjectChart.Series[0].Points.AddXY(avgMarks.Key, avgMarks.Value);



        }

        private void AverageBySubjectChart_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backAA_Click(object sender, EventArgs e)
        {
            this.Close();
            Academic_Staff_ManageResults_Dashboard obj = new Academic_Staff_ManageResults_Dashboard();
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
