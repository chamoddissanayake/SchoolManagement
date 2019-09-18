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
    }
}
