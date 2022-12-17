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
    public partial class Abooking : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        public Abooking()
        {
            InitializeComponent();
            BinderView();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void BinderView()         //to see the reply
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from cbooking";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();   //table fr display
            sda.Fill(data);
            dataGridView1.DataSource = data;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 30;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)  //SHOWING DATA IN TXT BOX
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select placetype,location,owner,rent from space where placeid=@placeid ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            if (textBox1.Text != "")
            {
                cmd.Parameters.AddWithValue("@placeid", int.Parse(textBox1.Text));
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {

                    
                    textBox2.Text = sda.GetValue(0).ToString();
                    textBox3.Text = sda.GetValue(1).ToString();
                    textBox4.Text = sda.GetValue(2).ToString();
                    textBox5.Text = sda.GetValue(3).ToString();
                    

                }
            }


            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);    //INSERT INTO DATA BASE...............
                string query = "insert into abill values (@owner,@place,@location,@arent,@customer,@deducted,@rent )";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@owner", textBox2.Text);
                cmd.Parameters.AddWithValue("@place", textBox3.Text);
                cmd.Parameters.AddWithValue("@location", textBox4.Text);
                cmd.Parameters.AddWithValue("@arent", textBox5.Text);
                cmd.Parameters.AddWithValue("@customer", textBox6.Text);
                cmd.Parameters.AddWithValue("@deducted", textBox7.Text);
                cmd.Parameters.AddWithValue("@rent", textBox8.Text);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data successfully inserted");

                }
                else

                    MessageBox.Show("Data is not successfully inserted");

            }
            else
            {
                MessageBox.Show("Please Fill both fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["placeid"].FormattedValue.ToString());
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from  cbooking where owner=@owner";
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@owner", textBox6.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data successfully Deleted");
                BinderView();
               // ResetControl();
            }
            else
            {
                MessageBox.Show("Data is not successfully Deleted");
            }

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
