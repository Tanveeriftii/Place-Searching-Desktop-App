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
    public partial class Ahome : Form
    {
        Thread th;
        public Ahome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom1);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();

            Sad c2 = new Sad();
            c2.Show();
        }

        private void openNewFrom1()
        {
            Application.Run(new Sad());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom2);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();

        }

        private void openNewFrom2()
        {
            Application.Run(new Alogin());
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
            Application.Run(new seller());
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
            Application.Run(new customer());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom5);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom5()
        {
            Application.Run(new Abooking());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom6);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();

        }

        private void openNewFrom6()
        {
            Application.Run(new Smessage());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom7);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom7()
        {
            Application.Run(new Dashboard());
        }
    }
}
