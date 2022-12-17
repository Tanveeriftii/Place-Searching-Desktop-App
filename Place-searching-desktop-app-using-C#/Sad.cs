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
    public partial class Sad : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        public Sad()
        {
            InitializeComponent();
            BinderView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Slogin f2 = new Slogin();
            f2.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Shome f6 = new Shome();
            f6.Show();
            //this.Hide();

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
            dataGridView1.RowTemplate.Height = 70;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cbooking f7 = new Cbooking();
            f7.Show();



        }

        private void Sad_Load(object sender, EventArgs e)
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
            Application.Run(new Shome());
        }
    }
}
