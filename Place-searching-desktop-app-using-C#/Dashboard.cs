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
    public partial class Dashboard : Form
    {
        Thread th;
        string cs = ConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        public Dashboard()
        {
            InitializeComponent();
            GetMax();
            GetMax1();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
        
       

        private void GetMax()
        {
            SqlConnection con = new SqlConnection(cs);
            
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(rent) from space", con);
            
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(rent) from space",con);
            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from space", con);
            //SqlDataAdapter sda2 = new SqlDataAdapter("select sum(deducted) from abill", con);
            SqlDataAdapter sda2 = new SqlDataAdapter("select Min(rent) from space", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            HighR.Text = dt.Rows[0][0].ToString();

            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TotalR.Text = dt1.Rows[0][0].ToString();

            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            Tplace.Text = dt2.Rows[0][0].ToString();

            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            label6.Text = dt3.Rows[0][0].ToString();



        }
        private void GetMax1()  //from bill table
        {
            SqlConnection con = new SqlConnection(cs);

            con.Open();
            SqlDataAdapter sda2 = new SqlDataAdapter("select sum(deducted) from abill", con);
            SqlDataAdapter sda3 = new SqlDataAdapter("select sum(rent) from abill", con);
            SqlDataAdapter sda4 = new SqlDataAdapter("select count(*) from abill", con);

            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            profit.Text = dt2.Rows[0][0].ToString();

            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            sellerp.Text = dt3.Rows[0][0].ToString();

            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            label9.Text = dt4.Rows[0][0].ToString();
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

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
