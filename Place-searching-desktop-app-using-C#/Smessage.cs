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
    public partial class Smessage : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        public Smessage()
        {
            InitializeComponent();
            BinderView();
        }

        private void Smessage_Load(object sender, EventArgs e)
        {

        }


        void BinderView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from cmsg";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();   //table fr display
            sda.Fill(data);
            dataGridView1.DataSource = data;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 30;


        }

        //private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  //values in text box
        //{
        //    textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();     //id
        //    textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();    //sender
        //    textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();   //reciever
        //    textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();  //msg
         
             
        //}

        private void button1_Click(object sender, EventArgs e)   //reply
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into smsgg values (@id,@sender,@reciever,@reply)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", textBox6.Text);
            cmd.Parameters.AddWithValue("@sender", textBox7.Text);
            cmd.Parameters.AddWithValue("@reciever", textBox8.Text);
            cmd.Parameters.AddWithValue("@reply", textBox9.Text);


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Message successfully sent");

            }
            else

                MessageBox.Show("Data is not successfully inserted");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            Application.Run(new Ahome());
        }
    }
}
