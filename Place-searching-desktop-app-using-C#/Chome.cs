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
    public partial class Chome : Form
    {
        Thread th;
        public Chome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFrom1);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
          
        }

        private void openNewFrom1()
        {
            Application.Run(new Sad());
        }

        private void button5_Click(object sender, EventArgs e)
        {
             
            th = new Thread(openNewFrom2);      //redirection
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openNewFrom2()
        {
            Application.Run(new Cmessage());
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
            Application.Run(new Cbooking());
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
