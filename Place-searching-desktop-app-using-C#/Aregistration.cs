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
    public partial class Aregistration : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        public Aregistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")///data will be inserted if all the fields are filled
            {
                SqlConnection con = new SqlConnection(cs);    //INSERT INTO DATA BASE...............
                string query = "insert into aregistration values (@name,@username,@password,@confirmpassword,@contactno,@address )";
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
                th = new Thread(openNewFrom);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Fill both fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void openNewFrom()
        {
            Application.Run(new Alogin());
        }

        private void label8_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
