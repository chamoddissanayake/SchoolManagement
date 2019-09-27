using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using SchoolManagementSystem.Model;

namespace SchoolManagementSystem
{
    public partial class Societies : Form
    {

        //SqlConnection sqlConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AsokaCollegeDB\School_DataBase.mdf;Integrated Security=True;Connect Timeout=30");

        SqlConnection sqlConn = new SqlConnection(CommonConstants.connnectionString);

        public Societies()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int intNo;
            try
            {

                if (txtName.Text == "" || txtNumber.Text == "" || txtTeacher.Text == "" || txtPresident.Text == "" || txtSecretary.Text == "" || txtTreasurer.Text == "")
                {
                    MessageBox.Show("Please fill all feilds!");
                }

                else if (!Int32.TryParse(txtNumber.Text, out intNo))
                {
                    MessageBox.Show("Please enter valid number!");
                }

                else if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("AssociationInsert_Procedure", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Insert");
                sqlCmd.Parameters.AddWithValue("@AssociationID", 0);
                sqlCmd.Parameters.AddWithValue("@AssociationName", txtName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@NoOfStudent", txtNumber.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Teacher", txtTeacher.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@President", txtPresident.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Secretary", txtSecretary.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Treasurer", txtTreasurer.Text.Trim());
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("AssociationSearch_Procedure", sqlConn);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@AssociationName", txtSearch.Text.Trim());

            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;

            sqlConn.Close();
        }

        void reset()
        {
            txtName.Text = txtTeacher.Text = txtPresident.Text = txtSecretary.Text = txtTreasurer.Text = "";
            txtNumber.ResetText();
            txtID.ResetText();
            btnDelete.Enabled = false;


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                //NotificationID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtNumber.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtTeacher.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtPresident.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtSecretary.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtTreasurer.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                btnUpdate.Text = "Update";
                btnDelete.Enabled = true;

            }
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
                SqlCommand sqlCmd = new SqlCommand("AssociationUpdate_Procedure", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Update");
                sqlCmd.Parameters.AddWithValue("@AssociationID", txtID.Text);
                sqlCmd.Parameters.AddWithValue("@AssociationName", txtName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@NoOfStudent", txtNumber.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Teacher", txtTeacher.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@President", txtPresident.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Secretary", txtSecretary.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Treasurer", txtTreasurer.Text.Trim());
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

                if (MessageBox.Show("Do you want to delete this Society ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand sqlCmd = new SqlCommand("AssociationDelete_Procedure", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@AssociationID", txtID.Text);

                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show("Deleted Successfully.");

                    fillDataGridView();
                    reset();
                }

                else
                {
                    MessageBox.Show("Society not deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void exportDataGrid()
        {
            try
            {
                var savefiledialog = new SaveFileDialog();
                savefiledialog.FileName = "School Societies Report";
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
                        iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance("C:/Users/User/Desktop/SchoolManagementSystem/SchoolManagementSystem/pictures/School societies report header.png");
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

        private void Societies_Load(object sender, EventArgs e)
        {
            fillDataGridView();

            User u = UserSessionStore.Instance.getUser();

            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Event Management> Societies";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Event Management> Societies";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Event Management> Societies";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Event Management> Societies";
            }
            else
            {
                lblPath.Text = "";
            }
        }
    }
}
