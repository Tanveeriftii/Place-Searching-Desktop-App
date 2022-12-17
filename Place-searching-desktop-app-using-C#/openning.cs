using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Project
{
    public partial class openning : Form
    {
        Thread th;
        public openning()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)   //Seller
        {
            th = new Thread(openNewFrom);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
            //Sregistration f = new Sregistration();
            //f.Show();
            ////this.Hide();
        }

        private void openNewFrom()
        {
            Application.Run(new Sregistration());
        }

        private void button3_Click(object sender, EventArgs e) //Customer
        {
            th = new Thread(openNewFrom1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom1()
        {
            Application.Run(new Cregistration());
        }

        private void button1_Click(object sender, EventArgs e)  //Admin
        {
            th = new Thread(openNewFrom2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom2()
        {
            Application.Run(new Aregistration());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom3()
        {
           Application.Run(new about());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
