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
    public partial class Sbooking : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        public Sbooking()
        {
            InitializeComponent();
            BinderView();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Print bill details", new Font("Arial" , 12,FontStyle.Bold), Brushes.Blue, new Point(10,10));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void Sbooking_Load(object sender, EventArgs e)
        {

        }
        void BinderView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from abill";
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
            Application.Run(new Shome());
        }
    }
}
