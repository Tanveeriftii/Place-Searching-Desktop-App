using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
namespace Project
{
    public partial class Clogin : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        private ThreadStart openNewFrom1;

        public Clogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from registration where username=@username and password=@password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                ////login msg...........
                MessageBox.Show("Now home page will apear!!", "Lets Go!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                th = new Thread(openNewFrom);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                this.Close();


            }
            else
            {
                MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();

            
        }

        private void openNewFrom()
        {
            Application.Run(new Chome());
        }

        private void label4_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom2()
        {
            Application.Run(new Cregistration());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
