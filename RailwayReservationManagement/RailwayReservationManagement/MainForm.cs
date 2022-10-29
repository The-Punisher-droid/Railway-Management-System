using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayReservationManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            CancellationMaster Cancel = new CancellationMaster();
            Cancel.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            CancellationMaster Cancel = new CancellationMaster();
            Cancel.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ReservationMaster Res = new ReservationMaster();
            Res.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ReservationMaster Res = new ReservationMaster();
            Res.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            TravelMaster Tr = new TravelMaster();
            Tr.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TravelMaster Tr = new TravelMaster();
            Tr.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            PassengerMaster Ps = new PassengerMaster();
            Ps.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PassengerMaster PS = new PassengerMaster();
            PS.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            TrainMaster TM = new TrainMaster();
            TM.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TrainMaster TM = new TrainMaster();
            TM.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
