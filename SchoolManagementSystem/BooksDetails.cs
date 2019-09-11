using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class BooksDetails : Form
    {
        public BooksDetails()
        {
            InitializeComponent();
        }
        User u;
        private void BooksDetails_Load(object sender, EventArgs e)
        {
            u = UserSessionStore.Instance.getUser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewBooks vb1 = new ViewBooks();
            vb1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Books ab = new Add_Books();
            ab.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Removed_Books rbObj = new Removed_Books();
            rbObj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LibraryDashBoard ld1 = new LibraryDashBoard();
            ld1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Book_Issue bi1 = new Book_Issue();
            bi1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();
        }
    }
}
