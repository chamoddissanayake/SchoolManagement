﻿using System;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SchoolManagementSystem
{
    public partial class Form1 : Form
    {

        public string constring = "Data Source=DESKTOP-83SSJ0U;Initial Catalog=ConnectionDb;Integrated Security=True ";

        SqlConnection con = new SqlConnection(CommonConstants.connnectionString);
        // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AsokaCollegeDB\School_DataBase.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
        }


        public void disp_date()
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select admissionNo,Id,issued_date,Due_Date from Books_Issued";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
                con.Close();

            }
        }
        private void sub_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("All Should be Filled!");
            }
            else
            {

                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Insert into Books_Issued values('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + dateTimePicker3.Text + "','" + groupBox1.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    dateTimePicker1.Text = "";
                    dateTimePicker2.Text = "";
                    groupBox1.Text = "";
                    disp_date();
                    MessageBox.Show("Record Inserted Successfully!!!");
                    con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error");
                    con.Close();

                }
            }
        }
        User u;
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Books_Issued where Id='" + textBox7.Text.Trim() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
            textBox7.Text = "";
        }



        private void insertbtn_Click(object sender, EventArgs e)
        {

        }
        private void updatebtn_Click(object sender, EventArgs e)
        {

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            disp_date();
            u = UserSessionStore.Instance.getUser();
            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Library> Books> Payments>";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Library> Books> Payments>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Library> Books> Payments>";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Library> Books> Payments>";
            }
            else
            {
                lblPath.Text = "";
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
        private void dataGridView1_DoubleClick(object sender, EvaluateException e)
        {
           
           }

        private void finedaysttb_TextChanged(object sender, EventArgs e)
        {

            try
            {
                int finedays = Int32.Parse(finedaysttb.Text);
                int finerate = Int32.Parse(fineratetb.Text);

                int sum = finerate * finedays;

                finelbl.Text = sum.ToString();
            }catch(Exception ex)
            {


            }
        }

        private void fineratetb_TextChanged(object sender, EventArgs e)
        {

            try
            {
                int finedays = Int32.Parse(finedaysttb.Text);
                int finerate = Int32.Parse(fineratetb.Text);

                int sum = finerate * finedays;

                finelbl.Text = sum.ToString();

                fineratetb.Text = "";
                finedaysttb.Text = "";
               



            }
            catch (Exception ex)
            {


            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                int number;
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("All Should be Filled!");
                }else if (!(Int32.TryParse(fineratetb.Text, out number)))
                {
                    MessageBox.Show("Fine Rate must be numbers");
                }
                else if (!(Int32.TryParse(finedaysttb.Text, out number)))
                {
                    MessageBox.Show("Days must be numbers");
                }
                else
                {

                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Insert into Payment values('"+textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + dateTimePicker3.Text + "','" + finelbl.Text + "')";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        disp_date();
                        MessageBox.Show("Record Inserted Successfully");

                        this.Hide();
                        Last d1 = new Last();
                        d1.Show();

                        con.Close();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error");
                        con.Close();

                    }

                }
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            BooksDetails Bd1 = new BooksDetails();
            Bd1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            documentcreate();
        }

        private void documentcreate()
        {

            try
            {
                var savefiledialog = new SaveFileDialog();
                savefiledialog.FileName = "Library Payment Report";
                savefiledialog.DefaultExt = ".pdf";

                if (savefiledialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefiledialog.FileName, FileMode.Create))
                    {
                        Document document = new Document();

                        PdfWriter.GetInstance(document, stream);
                        document.Open();

                        Paragraph p = new Paragraph("--- Report ---");

                        //Add school logo code start
                        iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance("C:/Users/User/Desktop/SchoolManagementSystem/SchoolManagementSystem/pictures/Library payment details report header.png");
                        //Fixed Positioning
                        image1.SetAbsolutePosition(0, 750);
                        //Scale to new height and new width of image
                        image1.ScaleAbsolute(600, 90);
                        //Add to document
                        document.Add(image1);
                        //Add school logo code end

                        Paragraph p1 = new Paragraph("\n\n\n\n\n\n\n\n\n\n\n");
                        document.Add(p1);

                        PdfPTable pdfTable1 = new PdfPTable(4);
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
    }
    }

