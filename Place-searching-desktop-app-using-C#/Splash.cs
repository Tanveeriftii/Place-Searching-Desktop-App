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
    public partial class Splash : Form
    {
        Thread th;
        public Splash()
        {
            InitializeComponent();
        }
        
        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void MyProgress_Click(object sender, EventArgs e)
        {

        }
        int startpoint = 3;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            startpoint += 1;
            MyProgress.Value = startpoint;
            if (MyProgress.Value == 90)
            {
                MyProgress.Value = 0;
                timer1.Stop();
                
                th = new Thread(openNewFrom);      //redirection
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                this.Close();

            }


        }

        private void openNewFrom()
        {
            Application.Run(new openning());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }






        //private void Splash_Load(object sender, EventArgs e)
        //{
        //    timer1.Start();
        //}
    }
}
