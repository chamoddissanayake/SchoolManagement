using iTextSharp.text;
using iTextSharp.text.pdf;
using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class Notification : Form
    {
        //SqlConnection sqlConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AsokaCollegeDB\School_DataBase.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection sqlConn = new SqlConnection(CommonConstants.connnectionString);

        public Notification()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTag.Text == "" || comboBox1.Text == "" || txtNoti.Text == "")
                {
                    MessageBox.Show("Please fill all feilds!");
                }
                else if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("NotificationInsert_Procedure", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Insert");
                sqlCmd.Parameters.AddWithValue("@NotificationID", 0);
                sqlCmd.Parameters.AddWithValue("@NotificationTag", txtTag.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@RelevantParties", comboBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Notification", txtNoti.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                sqlCmd.ExecuteNonQuery();

                MessageBox.Show("Inserted Successfully.");

                fillDataGridView();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message.");
            }
            finally
            {
                sqlConn.Close();
            }
        }

        void fillDataGridView()
        {
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("NotificationSearch_Procedure", sqlConn);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@NotiTag", txtSearch.Text.Trim());

            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;

            sqlConn.Close();
        }


        void reset()
        {
            txtTag.Text = comboBox1.Text = txtNoti.Text = "";
            dateTimePicker1.ResetText();
            txtID.ResetText();
            btnDelete.Enabled = false;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                fillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("NotificationUpdate_Procedure", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Update");
                sqlCmd.Parameters.AddWithValue("@NotificationID", txtID.Text);
                sqlCmd.Parameters.AddWithValue("@NotificationTag", txtTag.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@RelevantParties", comboBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Notification", txtNoti.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                sqlCmd.ExecuteNonQuery();

                MessageBox.Show("Updated Successfully.");

                fillDataGridView();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message.");
            }
            finally
            {
                sqlConn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();
                if (MessageBox.Show("Do you want to delete this Notification ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    SqlCommand sqlCmd = new SqlCommand("NotificationDelete_Procedure", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@NotificationID", txtID.Text);

                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show("Deleted Successfully.");

                    fillDataGridView();
                    reset();
                }

                else
                {
                    MessageBox.Show("Notification not deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message.");
            }
            finally
            {
                sqlConn.Close();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                //NotificationID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTag.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtNoti.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                btnUpdate.Text = "Update";
                btnDelete.Enabled = true;

            }
        }


        private void exportDataGrid()
        {
            try
            {
                var savefiledialog = new SaveFileDialog();
                savefiledialog.FileName = "Event Notifications Report";
                savefiledialog.DefaultExt = ".pdf";

                if (savefiledialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefiledialog.FileName, FileMode.Create))
                    {
                        Document document = new Document();

                        PdfWriter.GetInstance(document, stream);
                        document.Open();

                        Paragraph p = new Paragraph("--- Reprot ---");

                        //Add school logo code start
                        iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance("C:/Users/User/Desktop/SchoolManagementSystem/SchoolManagementSystem/pictures/Event notification report header.png");
                        //Fixed Positioning
                        image1.SetAbsolutePosition(0, 750);
                        //Scale to new height and new width of image
                        image1.ScaleAbsolute(600, 90);
                        //Add to document
                        document.Add(image1);
                        //Add school logo code end

                        Paragraph p1 = new Paragraph("\n\n\n\n\n\n\n\n\n\n\n");
                        document.Add(p1);

                        PdfPTable pdfTable1 = new PdfPTable(6);
                        //Adding Header row
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                            pdfTable1.AddCell(cell);
                        }


                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell celli in row.Cells)
                            {
                                try
                                {
                                    pdfTable1.AddCell(celli.Value.ToString());
                                }
                                catch { }
                            }
                        }

                        document.Add(pdfTable1);

                        document.Close();

                        stream.Close();
                    }
                }

                MessageBox.Show(savefiledialog.FileName + " saved successfully.");

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


        private void btnReport_Click(object sender, EventArgs e)
        {
            exportDataGrid();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            EventDashboard Ed1 = new EventDashboard();
            Ed1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            fillDataGridView();

            User u = UserSessionStore.Instance.getUser();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Event Management> Notification ";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Event Management> Notification";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Event Management> Notification";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Event Management> Notification";
            }
            else
            {
                lblPath.Text = "";
            }
        }
    }
}
