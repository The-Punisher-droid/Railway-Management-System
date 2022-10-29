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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(UnameTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Enter UserName and Password");
            }else if(UnameTb.Text == "Abdulghafur" && PassTb.Text == "Password")
            {
                MainForm Main = new MainForm();
                Main.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Wrong UserName Or Password");
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
