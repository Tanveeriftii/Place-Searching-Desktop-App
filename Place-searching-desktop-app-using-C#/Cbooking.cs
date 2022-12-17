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
    public partial class Cbooking : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        public Cbooking()
        {
            InitializeComponent();
            //BinderView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into cbooking values (@placeid,@owner,@customer,@contactno)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@placeid", textBox10.Text);
            cmd.Parameters.AddWithValue("@owner", textBox11.Text);
            cmd.Parameters.AddWithValue("@customer", textBox12.Text);
            cmd.Parameters.AddWithValue("@contactno", textBox13.Text);


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Message successfully sent");

            }
            else

                MessageBox.Show("Data is not successfully inserted");

        }


         

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
             //showing data in tb
            
            SqlConnection con = new SqlConnection(cs);          
            string query = "select placetype,location,duration,rent,owner,contactno from space where placeid=@placeid ;";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            if (textBox8.Text != "")
            {
                cmd.Parameters.AddWithValue("@placeid", int.Parse(textBox8.Text));
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {

                    textBox1.Text = sda.GetValue(0).ToString();
                    textBox2.Text = sda.GetValue(1).ToString();
                    textBox3.Text = sda.GetValue(2).ToString();
                    textBox4.Text = sda.GetValue(3).ToString();
                    textBox5.Text = sda.GetValue(4).ToString();
                    textBox6.Text = sda.GetValue(5).ToString();

                }
            }


            con.Close(); 



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Cbooking_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom()
        {
            Application.Run(new Chome());
        }
    }
}
