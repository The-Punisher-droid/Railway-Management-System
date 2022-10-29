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
    public partial class TravelMaster : Form
    {
        public TravelMaster()
        {
            InitializeComponent();
            populate();
            FillTCode();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Koton\OneDrive\Documents\RailwaysDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from TRAVELTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            TravelDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FillTCode()
        {
            string TrStatus = "Busy";
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TrainId from TRAINTBL where TrainStatus='"+TrStatus+"'", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TrainId", typeof(int));
            dt.Load(rdr);
            TCode.ValueMember = "TrainId";
            TCode.DataSource = dt;
            Con.Close();
        }
        private void TravelMaster_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ChangeStatus()
        {
            string TrStatus = "Busy";
                try
                {

                    Con.Open();
                    string Query = "update TRAINTBL set Trainstatus='" + TrStatus + "' where TrainId=" + TCode.SelectedValue.ToString() + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Train Updated Successfully");
                    Con.Close();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (TCostTb.Text == "" || TCode.SelectedIndex == -1 || SrcCb.SelectedIndex == -1 || DestCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    Con.Open();
                    string Query = "insert into TRAVELTBL value('" + TravDate.Text + "'," + TCode.SelectedValue.ToString() + ",'" + SrcCb.SelectedItem.ToString() + "','" + DestCb.SelectedItem.ToString() + "'," + TCostTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Travel Added Successfully");
                    Con.Close();
                    populate();
                    ChangeStatus();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Reset()
        {
            SrcCb.SelectedIndex = -1;
            DestCb.SelectedIndex = -1;
            TCode.SelectedIndex = -1;
            TCostTb.Text = "";
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (SrcCb.SelectedIndex == -1 || DestCb.SelectedIndex == -1 || TCostTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    Con.Open();
                    string Query = "update TRAVELTBL set TravDate='" + TravDate.Text + "',Train='" + TCode.SelectedValue.ToString() + "',Src='" + SrcCb.SelectedItem.ToString() + "',Dest='" + DestCb.SelectedItem.ToString() + "',Cost='" + TCostTb.Text + "' where TravCode=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Travel Updated Successfully");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void TravelDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TravDate.Text = TravelDGV.SelectedRows[0].Cells[1].ToString();
            TCode.SelectedValue = TravelDGV.SelectedRows[0].Cells[2].ToString();
            SrcCb.SelectedItem = TravelDGV.SelectedRows[0].Cells[3].ToString();
            DestCb.SelectedItem = TravelDGV.SelectedRows[0].Cells[4].ToString();
            TCostTb.Text = TravelDGV.SelectedRows[0].Cells[5].ToString();
            if (TCode.SelectedIndex == -1)
            {
                key = 0;
                TCostTb.Text = "";
                SrcCb.SelectedIndex = -1;
                DestCb.SelectedIndex = -1;
            }
            else
            {
                key = Convert.ToInt32(TravelDGV.SelectedRows[0].Cells[0].ToString());
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            MainForm Main = new MainForm();
            Main.Show();
            this.Hide();
        }
    }
}
