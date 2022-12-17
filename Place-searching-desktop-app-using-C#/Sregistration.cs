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
using System.IO;
using System.Threading;

namespace Project
{
    public partial class Sregistration : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;  
        public Sregistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")///data will be inserted if all the fields are filled
            {
                SqlConnection con = new SqlConnection(cs);    //INSERT INTO DATA BASE...............
                string query = "insert into sregistration values (@name,@username,@password,@confirmpassword,@contactno,@address )";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@username", textBox2.Text);
                cmd.Parameters.AddWithValue("@password", textBox3.Text);
                cmd.Parameters.AddWithValue("@confirmpassword", textBox4.Text);
                cmd.Parameters.AddWithValue("@contactno", textBox5.Text);
                cmd.Parameters.AddWithValue("@address", textBox6.Text);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data successfully inserted");

                }
                else

                MessageBox.Show("Data is not successfully inserted");
                MessageBox.Show("Registration Successfull!!", "Lets Go!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Slogin F2 = new Slogin();    //Redirection to login page.......
                //F2.Show();
                // this.Hide();
                th = new Thread(openNewFrom);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please!!! Fill all the fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            
        }

        private void openNewFrom()
        {
            Application.Run(new Slogin());
        }

        private void label8_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
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
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.error;
                errorProvider2.SetError(this.textBox2, "Fill the field");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.check;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                errorProvider3.Icon = Properties.Resources.error;
                errorProvider3.SetError(this.textBox3, "Fill the field");
            }
            else
            {
                errorProvider3.Icon = Properties.Resources.check;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Focus();
                errorProvider4.Icon = Properties.Resources.error;
                errorProvider4.SetError(this.textBox4, "Fill the field");
            }
            else
            {
                errorProvider4.Icon = Properties.Resources.check;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.Focus();
                errorProvider5.Icon = Properties.Resources.error;
                errorProvider5.SetError(this.textBox5, "Fill the field");
            }
            else
            {
                errorProvider5.Icon = Properties.Resources.check;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.Focus();
                errorProvider6.Icon = Properties.Resources.error;
                errorProvider6.SetError(this.textBox6, "Fill the field");
            }
            else
            {
                errorProvider6.Icon = Properties.Resources.check;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }
    }
}
