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

    public partial class Cmessage : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        public Cmessage()
        {
            InitializeComponent();
            BinderView();
        }

        private void button2_Click(object sender, EventArgs e)   // sending message
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into cmsg values (@id,@sender,@reciever,@message)";
            SqlCommand cmd = new SqlCommand(query, con);
             
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@sender", textBox2.Text);
            cmd.Parameters.AddWithValue("@reciever", textBox3.Text);
            cmd.Parameters.AddWithValue("@message", textBox4.Text);
             

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Message successfully sent");
            
            }
            else

                MessageBox.Show("Data is not successfully inserted");
        }


        void BinderView()         //to see the reply
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from smsgg";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();   //table fr display
            sda.Fill(data);
            dataGridView1.DataSource = data;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 30;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
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
