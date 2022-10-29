using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayReservationManagement
{
    public partial class ReservationMaster : Form
    {
        public ReservationMaster()
        {
            InitializeComponent();
            populate();
            FillPid();
            FillTravCode();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Koton\OneDrive\Documents\RailwaysDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from RESERVATIONTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            ReservationDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FillPid()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Pid from PassengerTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Pid", typeof(int));
            dt.Load(rdr);
            PIdCb.ValueMember = "Pid";
            PIdCb.DataSource = dt;
            Con.Close();
        }
        private void FillTravCode()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TravCode from TravelTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TravCode", typeof(int));
            dt.Load(rdr);
            TravelCb.ValueMember = "TravCode";
            TravelCb.DataSource = dt;
            Con.Close();
        }
        string pname;
        private void GetPName()
        {
            Con.Open();
            string mysql = "select = from PassengerTbl where Pid=" + PIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(mysql, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                pname = dr["PName"].ToString();
            }
            Con.Close();
            //MessageBox.Show(pname);
        }
        string Date, Src, Dest;
        int Cost;
        private void GetTravel()
        {
            Con.Open();
            string mysql = "select = from TravelTbl where TravCode=" + TravelCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(mysql, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Date = dr["TravDate"].ToString();
                Src = dr["TravDate"].ToString();
                Dest = dr["Dest"].ToString();
                Cost = Convert.ToInt32(dr["Cost"].ToString());
            }
            Con.Close();
            //MessageBox.Show(Date + Src + Dest+ Cost);
        }

        private void TravelCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetTravel();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (TravelCb.SelectedIndex == -1 || PIdCb.SelectedIndex == -1 )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {               
                try
                {

                    Con.Open();
                    string Query = "insert into RESERVATIONTBL values(" + PIdCb.SelectedValue.ToString() + ",'" + pname + "','" + TravelCb.SelectedValue.ToString() + "','" + Date + "','" + Src + "','" + Dest + "'," + Cost + ")";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Reservation Accepted");
                    Con.Close();
                    populate();
                    //Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            MainForm Main = new MainForm();
            Main.Show();
            this.Hide();
        }

        private void ReservationMaster_Load(object sender, EventArgs e)
        {

        }

        private void PIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetPName();
        }
    }
}
