using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RailwayReservationManagement
{
    public partial class TrainMaster : Form
    {
        public TrainMaster()
        {
            InitializeComponent();
            populate();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Koton\OneDrive\Documents\RailwaysDb.mdf;Integrated Security=True;Connect Timeout=30"); 
        private void populate()
        {
            Con.Open();
            string query = "select * from TRAINTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            TrainDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string TrStatus="";
            if(TrNameTb.Text == "" || TrainCapTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }else
            {
                if (BusyRd.Checked == true)
                {
                    TrStatus = "Busy";
                }else if(FreeRd.Checked == true)
                {
                    TrStatus = "Available";
                }
                    try
                {

                    Con.Open();
                    string Query = "insert into TRAINTBL value('" + TrNameTb.Text + "'," + TrainCapTb.Text + ",'" + TrStatus + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Train Added Successfully");
                    Con.Close();
                    populate();

                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void reset()
        {
            TrNameTb.Text = "";
            TrainCapTb.Text = "";
            BusyRd.Checked = false;
            FreeRd.Checked = false;
            key = 0;
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int key = 0;
        private void TrainDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            TrNameTb.Text = TrainDGV.SelectedRows[0].Cells[1].ToString();
            TrainCapTb.Text = TrainDGV.SelectedRows[0].Cells[2].ToString();
            if(TrNameTb.Text == "")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(TrainDGV.SelectedRows[0].Cells[0].ToString());
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if(key == 0)
            {
                MessageBox.Show("Select The Train To Be Deleted");
            }
            else
            {
                try
                {

                    Con.Open();
                    string Query = "Delete from TRAINTBL where TrainId="+key+"";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Train Deleted Successfully");
                    Con.Close();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string TrStatus = "";
            if (TrNameTb.Text == "" || TrainCapTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                if (BusyRd.Checked == true)
                {
                    TrStatus = "Busy";
                }
                else if (FreeRd.Checked == true)
                {
                    TrStatus = "Available";
                }
                try
                {

                    Con.Open();
                    string Query = "update TRAINTBL set TrainName='"+TrNameTb.Text+"',TrainCap="+TrainCapTb.Text+",Trainstatus='"+TrStatus+"' where TrainId="+ key +";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Train Updated Successfully");
                    Con.Close();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            MainForm Main = new MainForm();
            Main.Show();
            this.Hide();
        }
    }
}
