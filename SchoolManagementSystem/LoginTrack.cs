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
    public partial class LoginTrack : Form
    {
        SqlConnection con = new SqlConnection(CommonConstants.connnectionString);
        public LoginTrack()
        {
            InitializeComponent();
        }
        User u;
      
        private void backAA_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminDashboard obj = new AdminDashboard();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserSessionStore.Instance.setUser(null);
            frmLogin frmLoginObj = new frmLogin();
            this.Hide();
            frmLoginObj.Show();

        }

        private void LoginTrack_Load(object sender, EventArgs e)
        {
            u = UserSessionStore.Instance.getUser();
            helloMsg.Text = "Hello " + u.getuserID();
            fillgrid();
        }

        private void fillgrid()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM LoginTrack Order by id desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
