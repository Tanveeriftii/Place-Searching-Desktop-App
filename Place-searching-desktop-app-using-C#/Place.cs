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
    public partial class Place : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        public Place()
        {
            InitializeComponent();
            BinderView();
            //label10.Text = Slogin.User;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Slogin f2 = new Slogin();
            f2.Show();
            //this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Shome f6 = new Shome();
            f6.Show();
            //this.Hide();
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                textBox7.Focus();
                errorProvider7.Icon = Properties.Resources.error;
                errorProvider7.SetError(this.textBox7, "Fill the field");
            }
            else
            {
                errorProvider7.Icon = Properties.Resources.check;
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

                        

        private void button7_Click(object sender, EventArgs e) ///picture
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select your photo";
            ofd.Filter = "ALL IMAGE FILE (*.*)|*.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)    //upload
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into space values (@placeid,@picture,@placetype,@location,@duration,@rent,@owner,@contactno )";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@placeid", textBox1.Text);
                cmd.Parameters.AddWithValue("@picture", SavePhoto());
                cmd.Parameters.AddWithValue("@placetype", textBox2.Text);
                cmd.Parameters.AddWithValue("@location", textBox3.Text);
                cmd.Parameters.AddWithValue("@duration", textBox4.Text);
                cmd.Parameters.AddWithValue("@rent", textBox5.Text);
                cmd.Parameters.AddWithValue("@owner", textBox6.Text);
                cmd.Parameters.AddWithValue("@contactno", textBox7.Text);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data successfully inserted");
                    BinderView();
                    ResetControl();
                }
                else

                    MessageBox.Show("Data is not successfully inserted");
            }

            else
            {
                MessageBox.Show("Please!!! Fill all the fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }



        private object SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            //throw new NotImplementedException();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        void BinderView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from space";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();   //table fr display
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dvg = new DataGridViewImageColumn();
            dvg = (DataGridViewImageColumn)dataGridView1.Columns[1];
            dvg.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 90;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        void ResetControl()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            pictureBox1.Image = Properties.Resources._18p;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text =dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[1].Value);
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update  space set placeid=@placeid,picture=@picture,placetype=@placetype,location=@location,duration=@duration,rent=@rent,owner=@owner,contactno=@contactno where placeid=@placeid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@placeid", textBox1.Text);
            cmd.Parameters.AddWithValue("@picture", SavePhoto());
            cmd.Parameters.AddWithValue("@placetype", textBox2.Text);
            cmd.Parameters.AddWithValue("@location", textBox3.Text);
            cmd.Parameters.AddWithValue("@duration", textBox4.Text);
            cmd.Parameters.AddWithValue("@rent", textBox5.Text);
            cmd.Parameters.AddWithValue("@owner", textBox6.Text);
            cmd.Parameters.AddWithValue("@contactno", textBox7.Text);
             
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data successfully Edited");
                BinderView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data is not successfully Edited");
            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from  space where owner=@owner";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@owner", textBox6.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data successfully Deleted");
                BinderView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data is not successfully Deleted");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
            Application.Run(new Shome());
        }
    }
}


