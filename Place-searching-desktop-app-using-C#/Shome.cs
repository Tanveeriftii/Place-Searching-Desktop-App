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
    public partial class Shome : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        public Shome()
        {
            InitializeComponent();
            BinderView();
            label5.Text = Slogin.User;      ////////////
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Slogin f2 = new Slogin();
            f2.Show();
            //this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)  //my product list
        {
            
            th = new Thread(openNewFrom1);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom1()
        {
            Application.Run(new Sad());
        }

        private void button3_Click(object sender, EventArgs e)
        {
             
            th = new Thread(openNewFrom2);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom2()
        {
            Application.Run(new Place());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select your photo";
            ofd.Filter = "ALL IMAGE FILE (*.*)|*.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
               // pictureBox1.Image = new Bitmap(ofd.FileName);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        void BinderView()   //showing data in tb
        {
            SqlConnection con = new SqlConnection(cs);

            con.Open();
            string query = "select name,username,contactno,address from sregistration ;";



            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sda = cmd.ExecuteReader();
            //cmd.Parameters.AddWithValue("@username", textBox2.Text);

            sda.Read();
            textBox1.Text = sda.GetValue(0).ToString();
            textBox2.Text = sda.GetValue(1).ToString();
            textBox3.Text = sda.GetValue(2).ToString();
            textBox4.Text = sda.GetValue(3).ToString();



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
             
            th = new Thread(openNewFrom3);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom3()
        {
            Application.Run(new Sbooking());
        }

        private void button5_Click(object sender, EventArgs e)
        {
             
            th = new Thread(openNewFrom4);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom4()
        {
            Application.Run(new Dashboard());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)  //back button
        {
            th = new Thread(openNewFrom);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom()
        {
            Application.Run(new Slogin());
        }
    }
}