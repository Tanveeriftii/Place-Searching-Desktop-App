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
    
    public partial class Slogin : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        public Slogin()
        {
            InitializeComponent();
        }


        public static string User;  /// declaed
        private void button1_Click(object sender, EventArgs e)   //submit button
        {
            SqlConnection con = new SqlConnection(cs);
           
            if (textBox1.Text != "" && textBox2.Text != "")
            {
               // SqlConnection con = new SqlConnection(cs);
                string query = "select * from sregistration where username=@username and password=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    User = textBox1.Text;

                    ////login msg...........
                    // MessageBox.Show("Now home page will apear!!", "Lets Go!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            else
            {
                MessageBox.Show("Please Fill both fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            ////................................

           
        }

        private void openNewFrom()
        {
            Application.Run(new Shome());
        }

        private void label4_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom1()
        {
            Application.Run(new Sregistration());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch(status)
            {
                case true:
                textBox2.UseSystemPasswordChar = false;
                break;

                default:
                textBox2.UseSystemPasswordChar = true;
                break;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.error;
                errorProvider1.SetError(this.textBox1, "Fill the field");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.check;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox1.Focus();
                errorProvider2.Icon = Properties.Resources.error;
                errorProvider2.SetError(this.textBox2, "Fill the field");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.check;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
