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
    public partial class Add_Books : Form
    {
       public string constring = "Data Source=DESKTOP-83SSJ0U;Initial Catalog=ConnectionDb;Integrated Security=True ";

        SqlConnection con = new SqlConnection(CommonConstants.connnectionString);
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AsokaCollegeDB\School_DataBase.mdf;Integrated Security=True;Connect Timeout=30");
        public Add_Books()
        {
            InitializeComponent();
        }
        User u;
        private void Add_Books_Load(object sender, EventArgs e)
        {
            u = UserSessionStore.Instance.getUser();
            display();        
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            int j;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("All should be filled.");
            }else if (!(Int32.TryParse(textBox5.Text, out  j)))
            {
                MessageBox.Show("Price should be a number");
            } else if (!(Int32.TryParse(textBox6.Text, out j)))
            {
                MessageBox.Show("Quantity should be a number");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into books_info values(" + textBox7.Text + ",'" + textBox3.Text + "','" + textBox2.Text + "','" + textBox1.Text + "','" + purchasePicker.Value.ToShortDateString() + "', " + textBox5.Text + ", " + textBox6.Text + " )";
                    cmd.ExecuteNonQuery();
                    

                    MessageBox.Show("Books added succesfully");
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    MessageBox.Show("This book id is already used.");
                }
                catch (Exception e001)
                {
                    MessageBox.Show("Error: " + e001);
                }
                finally{
                    if (con.State == ConnectionState.Open)
                            con.Close();
                }

                clearFields();
                display();
                
            }
        }

        private void clearFields()
        {
            textBox7.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        public void display()
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
        
        private void button2_Click(object sender, EventArgs e)
        {
            int j;
            if(textBox1.Text=="" || textBox2.Text == ""|| textBox3.Text == ""|| textBox5.Text == ""|| textBox6.Text == ""|| textBox7.Text == "")
            {
                MessageBox.Show("All should be filled.");
            }
            else if (!(Int32.TryParse(textBox5.Text, out j)))
            {
                MessageBox.Show("Price should be a number");
            }
            else if (!(Int32.TryParse(textBox6.Text, out j)))
            {
                MessageBox.Show("Quantity should be a number");
            }
            else
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
            
                cmd.CommandText = "update books_info set books_name='" +textBox3.Text + "',books_author_name='" +textBox2.Text + "',books_publication_name='" + textBox1.Text + "',books_purchase_date='" + purchasePicker.Value.ToShortDateString() + "',books_price=" + textBox5.Text + " ,books_quantity=" + textBox6.Text + " where Id='"+textBox7.Text+"'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Successfully updated");
                clearFields();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                purchasePicker.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Error while filling data."+ ex1);
            }
            

        }


        //search
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info where books_name like '%" + textBox9.Text + "%'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching: "+ ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Boolean succesfullyAdded = false;
            Boolean succesfullyRemoved = false;

            succesfullyAdded =  insertToDeleteBooks_detailsTbl();
            if(succesfullyAdded == true)
            {
                //Remove Existing record.
                succesfullyRemoved = removeExistingBook();
            }

            if(succesfullyAdded == true && succesfullyRemoved == true)
            {
                MessageBox.Show("Books Deleted Successfully.");
                clearFields();
            }
            
        }

        private Boolean removeExistingBook()
        {
            Boolean success = false;

            try
            {
                con.Open();
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandText = "Delete from books_info where Id  = '" + textBox7.Text + "'";
                cmd2.ExecuteNonQuery();
                success = true;
            }
            catch(Exception ex1)
            {
                MessageBox.Show("Error: " + ex1);
                success = false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return success;
            
        }

        private Boolean insertToDeleteBooks_detailsTbl()
        {

            Boolean success = false;
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into DeleteBooks_details values(" + textBox7.Text + ",'" + textBox3.Text + "','" + textBox2.Text + "','" + textBox1.Text + "','" + purchasePicker.Value.ToShortDateString() + "', " + textBox5.Text + ", " + textBox6.Text + " )";
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("This book deleted already.");
                success = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: "+ex);
                success = false;
            }
            finally{
                if(con.State == ConnectionState.Open)
                    con.Close();
            }
            return success;
            
        }

  
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            BooksDetails bdObj = new BooksDetails();
            bdObj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }

       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            display();
        }

    }
}