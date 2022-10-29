using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayReservationManagement
{
    public partial class CancellationMaster : Form
    {
        public CancellationMaster()
        {
            InitializeComponent();
            populate();
            FillTicketId();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Koton\OneDrive\Documents\RailwaysDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from CancellationTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            CancelDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FillTicketId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TicketId from ReservationTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TicketId", typeof(int));
            dt.Load(rdr);
            TidCb.ValueMember = "TicketId";
            TidCb.DataSource = dt;
            Con.Close();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (TidCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    Con.Open();
                    string Query = "insert into CancellationTbl values(" + TidCb.SelectedValue.ToString() + ",'" + DateTime.Today.Date + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ticket Cancelled");
                    Con.Close();
                    populate();
                    remove();
                    FillTicketId();
                    TidCb.SelectedIndex = -1;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void remove()
        {
            
                try
                {

                    Con.Open();
                    string Query = "Delete from ReservationTbl where TicketId=" + TidCb.SelectedValue.ToString() + "";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            
        }
        private void CancellationMaster_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            MainForm Main = new MainForm();
            Main.Show();
            this.Hide();
        }
    }
}
