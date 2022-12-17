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
    public partial class seller : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        public seller()
        {
            InitializeComponent();
            BinderView();
        }

        private void seller_Load(object sender, EventArgs e)
        {

        }
        void BinderView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from sregistration";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();   //table fr display
            sda.Fill(data);
            dataGridView1.DataSource = data;

            

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 35;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom1);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom1()
        {
            Application.Run(new Ahome());
        }
    }
}
