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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SchoolManagementSystem
{
    public partial class ViewBooks : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AsokaCollegeDB\School_DataBase.mdf;Integrated Security=True;Connect Timeout=30");
        public string constring = "Data Source=DESKTOP-83SSJ0U;Initial Catalog=ConnectionDb;Integrated Security=True ";

        SqlConnection con = new SqlConnection(CommonConstants.connnectionString);

        public ViewBooks()
        {
            InitializeComponent();
        }
        User u;
        private void ViewBooks_Load(object sender, EventArgs e)
        {
            u = UserSessionStore.Instance.getUser();
            radioID.Checked = true;

            loadAllBooksInfo();

            btnSpecificReport.Visible = false;


            if (u.Type == "Admin")
            {
                lblPath.Text = "Admin Dashboard> Library> Books> View Books>";
            }
            else if (u.Type == "Academic_Staff")
            {
                lblPath.Text = "Academic Staff Dashboard> Library> Books> Vew Books>";
            }
            else if (u.Type == "Non_Academic_Staff")
            {
                lblPath.Text = "Non Academic Staff Dashboard> Library> Books> View Books>";
            }
            else if (u.Type == "Administrative_Staff")
            {
                lblPath.Text = "Administrative Staff Dashboard> Library> Books> View Books>";
            }
            else
            {
                lblPath.Text = "";
            }
        }

        private void loadAllBooksInfo()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            BooksDetails bdObj = new BooksDetails();
            bdObj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            fillBySearchResults();
        }

        private void fillBySearchResults()
        {
            if(radioID.Checked == true)
            {
                fillResultsWithType("Id");
            }else if(radioName.Checked == true)
            {
                fillResultsWithType("books_name");
            }
            else if(radioAuthor.Checked == true)
            {
                fillResultsWithType("books_author_name");
            }
            else if (radioPublication.Checked == true)
            {
                fillResultsWithType("books_publication_name");
            }
            else
            {
                MessageBox.Show("Plese select a category to search");
            }

         
        }

        private void fillResultsWithType(string type)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info where "+ type + " like '%" + textBox9.Text + "%'";

                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching: " + ex);
            }
        }


        private void ViewBooks_Click(object sender, EventArgs e)
        {
            btnSpecificReport.Visible = false;
        }

        String BooksIDForReport="", BooksNameForReport="";
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            btnSpecificReport.Visible = true;
             BooksIDForReport = dataGridView1.CurrentRow.Cells[0].Value.ToString();
             BooksNameForReport = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            btnSpecificReport.Text = "Get a Report Of "+ BooksNameForReport;
            
        }

        private void btnSpecificReport_Click(object sender, EventArgs e)
        {
            generateReportOfSpecificBook(BooksIDForReport);
        }

        private void btnAllReport_Click(object sender, EventArgs e)
        {
            generateReportOfAllBooks();
        }

        private void generateReportOfAllBooks()
        {
            try
            {
                var savefiledialog = new SaveFileDialog();
                string n = "LibraryAllBooksDetails";
                savefiledialog.FileName = n;
                savefiledialog.DefaultExt = ".pdf";

                if (savefiledialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefiledialog.FileName, FileMode.Create))
                    {
                   
                        Document document = new Document();

                        //document.SetPageSize(PageSize.A3); // for vertical layout
                        document.SetPageSize(PageSize.A3.Rotate());
                        //document.SetPageSize(PageSize.A4.Rotate());

                        //PdfWriter.GetInstance(document, new FileStream("E:/LibraryAllBooksDetails.pdf", FileMode.Create));
                        PdfWriter.GetInstance(document, stream);
                        document.Open();
                        //Document open


                        //Add school logo code start
                        iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance("C:/Users/User/Desktop/SchoolManagementSystem/SchoolManagementSystem/pictures/Library book details report header.png");
                        //Fixed Positioning
                        image1.SetAbsolutePosition(0, 750);
                        //Scale to new height and new width of image
                        image1.ScaleAbsolute(600, 90);
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



                        //Final note start
                        DateTime now = DateTime.Now;
                        Paragraph pEnd = new Paragraph("- System generated book details sheet on " + now + " - ");
                        document.Add(pEnd);
                        //Final note end


                        //Document close
                        document.Close();
                        stream.Close();

                        MessageBox.Show(n + ".pdf saved successfully");
                    }
                }

               
            }
            catch (IOException ioex)
            {
                MessageBox.Show("File already open. Please close it.");
            }catch(Exception e001)
            {
                MessageBox.Show("Error: " + e001);
            }


        }
        string b_id = "", b_name = "", b_author = "", b_publication = "", b_purchasedate = "", b_price = "", b_quantity = "";
        private void generateReportOfSpecificBook(string booksIDForReport)
        {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    /*
                    SELECT*
                    FROM books_Info
                    WHERE Id = 1
                    */

                    cmd.CommandText = "SELECT * FROM books_Info WHERE Id = "+ booksIDForReport;


                    SqlDataReader reader = cmd.ExecuteReader();
             
                    int counter = 0;
                    while (reader.Read())
                    {
                        b_id = (reader[0]).ToString();
                        b_name = (string)(reader[1]);
                        b_author = (string)(reader[2]);
                        b_publication = (string)(reader[3]);
                        b_purchasedate = (reader[4]).ToString();
                        b_price = (reader[5]).ToString();
                        b_quantity = (reader[6]).ToString();
                        counter++;
                    }

                    if (counter == 0)
                    {
                        MessageBox.Show("Not a valid Book ID");
                    }else
                    {
                        drawSpecificPDF();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }

        }

        private void drawSpecificPDF()
        {
            try
            {

                var savefiledialog = new SaveFileDialog();
                savefiledialog.FileName = b_id + " - " + b_name;
                savefiledialog.DefaultExt = ".pdf";

                if (savefiledialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefiledialog.FileName, FileMode.Create))
                    {


                        Document document = new Document();

                        // PdfWriter.GetInstance(document, new FileStream("E:/Book Details - "+ b_id +" - "+  b_name  + ".pdf", FileMode.Create));
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

                        Paragraph pDetails = new Paragraph(
                            "\nBook ID: "+ b_id+
                            "\nBook Name: "+b_name+
                            "\nBook Author: "+b_author+
                            "\nPublication: "+b_publication+
                            "\nBook Purchase Date: "+b_purchasedate+
                            "\nPrice: "+b_price+
                            "\nQuantity: "+b_quantity+
                            "\n\n\n\n\n"
                            );

                        document.Add(pDetails);
                



                        //Final note start
                        DateTime now = DateTime.Now;
                        Paragraph pEnd = new Paragraph("- System generated book details sheet on " + now + " - ");
                        document.Add(pEnd);
                        //Final note end


                        //Document close
                        document.Close();

                        MessageBox.Show(b_id + " - " + b_name+" ");
                        stream.Close();
                    }
                }

            }
            catch (IOException ioex)
            {
                MessageBox.Show("file already open. please close it.");
            }
            catch (Exception e001)
            {
                MessageBox.Show("Error: " + e001);
            }
                
        }
    }
}
