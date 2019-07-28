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
    public partial class updateResults : Form
    {
        Student std;
        
        internal Student Std
        {
            get{return std;}
            set{std = value;}
        }

        public updateResults()
        {
            InitializeComponent();
        }

        private void updateResults_Load(object sender, EventArgs e)
        {

            sID.Text = std.SID;
            sCode.Text = std.SubjectCode;
            sName.Text = std.SubjectName;
            grade.Text = std.StudentGrade;
            examID.Text = std.ExamID;
            Term.Text =  std.Term.ToString();
            newMark.Text = std.Mark.ToString();
            
        }

        private void UpdateMark_Click(object sender, EventArgs e)
        {
            string conString = CommonConstants.connnectionString;

            DialogResult dialogResult = MessageBox.Show("Do you want to update result?", "Confirm Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                int number2;
                if (int.TryParse(newMark.Text, out number2))
                {
                    if (int.Parse(newMark.Text) >= 0 && int.Parse(newMark.Text) <= 100)
                    {
                        //Update marks start
                        
                        using (SqlConnection connection = new SqlConnection(conString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(null, connection);

                            command.CommandText = "UPDATE Student_follow_subject SET mark =@mark WHERE sID = @stID AND sCode=@sbCode";
                            
                            SqlParameter mark = new SqlParameter("@mark", SqlDbType.Int, 100);
                            mark.Value = newMark.Text;
                            command.Parameters.Add(mark);

                            SqlParameter stID = new SqlParameter("@stID", SqlDbType.VarChar, 100);
                            stID.Value = sID.Text.ToString();
                            command.Parameters.Add(stID);

                            SqlParameter sbCode = new SqlParameter("@sbCode", SqlDbType.VarChar, 100);
                            sbCode.Value = sCode.Text.ToString();
                            command.Parameters.Add(sbCode);
                            

                            command.Prepare();
                            try
                            {
                                command.ExecuteNonQuery();
                                MessageBox.Show("Result updated Successfully");
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("Error while updating result." + ex);
                            }
                        }
                        //Update Marks End.
                    }
                    else
                    {
                        MessageBox.Show("Marks should be in 0 -100 range");
                    }
                }
                else
                {
                    MessageBox.Show("Mark entered is not numeric");
                }
                
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
