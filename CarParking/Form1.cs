using Parkomate_Parking_Management_Software.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkomate_Parking_Management_Software
{
    public partial class MainWindow1 : Form
    {
        

        public MainWindow1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_Explore.TabStop = false;
            btn_Explore.FlatStyle = FlatStyle.Flat;
            btn_Explore.FlatAppearance.BorderSize = 0;
            btn_Explore.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            btn_toDashboard.TabStop = false;
            btn_toDashboard.FlatStyle = FlatStyle.Flat;
            btn_toDashboard.FlatAppearance.BorderSize = 0;
            btn_toDashboard.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            btn_toNotification.TabStop = false;
            btn_toNotification.FlatStyle = FlatStyle.Flat;
            btn_toNotification.FlatAppearance.BorderSize = 0;
            btn_toNotification.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            btn_ToReport.TabStop = false;
            btn_ToReport.FlatStyle = FlatStyle.Flat;
            btn_ToReport.FlatAppearance.BorderSize = 0;
            btn_ToReport.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            btn_ParkingProducts.TabStop = false;
            btn_ParkingProducts.FlatStyle = FlatStyle.Flat;
            btn_ParkingProducts.FlatAppearance.BorderSize = 0;
            btn_ParkingProducts.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);


            btn_toDashboard.Size = new Size(175, 350);
            btn_toDashboard.Location = new Point(75, 100);

            btn_toNotification.Size = new Size(175, 350);
            btn_toNotification.Location = new Point(300, 100);

            btn_ToReport.Size = new Size(175, 350);
            btn_ToReport.Location = new Point(525, 100);

            btn_ParkingProducts.Size = new Size(175, 350);
            btn_ParkingProducts.Location = new Point(750, 100);

       
            this.Location = new Point(0, 0);

            LandingPanel.Visible = true;
            MenuPanel.Visible = false;
            DashboardPanel.Visible = false;
            btn_Explore.Location = new Point(450, 300);

            LandingPanel.Dock = DockStyle.Fill;
            Width = 1024;
            Height = 768;
            //btn_Explore.Location= LandingPanel
            
        }

        private void btn_Explore_Click(object sender, EventArgs e)
        {
            LandingPanel.Visible = false;
            MenuPanel.Visible = true;
            DashboardPanel.Visible = false;

            MenuPanel.Dock = DockStyle.Fill;


        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();// this.Close();
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            LandingPanel.Visible = true;
            MenuPanel.Visible = false;
            DashboardPanel.Visible = false;
        }

        private void btn_toDashboard_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = true;
            LandingPanel.Visible = false;
            MenuPanel.Visible = false;
            DashboardPanel.Dock = DockStyle.Fill;
            showParkingStatus(sender, e);
            InitTimer();


        }


        private void callMethod(List<SensorData> lstZoneValues)
        {
            CallSP sp = new CallSP();
            sp.Test(lstZoneValues);
        }

        private System.Windows.Forms.Timer timer1;
        public void InitTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(showParkingStatus);
            timer1.Interval = 10000;
            timer1.Start();
        }

     


        private void showParkingStatus(object sender, EventArgs e)
        {
           // lblLoding.Visible = true;
           // progressBar1.Maximum = 40;
           // progressBar1.Value = 0;

            pnParkingSlots.Width = 400;
            pnParkingSlots.Height = 400;

            int[] al = new int[20];
            List<SensorData> lstZoneValues = new List<SensorData>();

            int genRand;
            Random r;
            for (int i = 0; i < 20; i++)
            {
                r = new Random();
                genRand = r.Next(0, 3);
                Task.Delay(200).Wait();
                al[i] = genRand;
                //progressBar1.Value++;
            }
            int rowcounter = 4;
            int columncounter = 5;
            int GreenCounter = 0;
            int YellowCounter = 0;
            int RedCounter = 0;
            string[] array = new string[columncounter];
            int totalcount = rowcounter * columncounter;
            int elementcount = 0;
            pnParkingSlots.Controls.Clear();

            SensorData sData = new SensorData();

            for (int i = 0; i < rowcounter; i++)
            {
                for (int j = 0; j < columncounter; j++)
                {

                    //progressBar1.Value++;
                    Button btn = new Button();
                    pnParkingSlots.Controls.Add(btn);
                    btn.Height = 50;
                    btn.Top = (i * 70);
                    btn.Width = 50;
                    btn.Left = j * 70;

                    // btn.BorderStyle = BorderStyle.Fixed3D;

                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.Text = "P" + elementcount;

                    if (al[elementcount] == 0)
                    {
                        btn.BackColor = Color.Green;
                        GreenCounter = GreenCounter + 1;
                    }
                    else if (al[elementcount] == 1)
                    {
                        btn.BackColor = Color.Yellow;
                        YellowCounter = YellowCounter + 1;
                    }
                    if (al[elementcount] == 2)
                    {
                        btn.BackColor = Color.Red;
                        RedCounter = RedCounter + 1;
                    }

                    array[j] = al[elementcount].ToString();
                    elementcount++;
                }

                String s = String.Join("", array);
                sData = new SensorData();
                sData.ZoneName = "Z" + i;
                sData.SensorString = "Z" + i + "#" + s;
                lstZoneValues.Add(sData);
                //ZName = sData.ZoneName;
                //SenString = sData.SensorString;

                // MessageBox.Show(ZoneVaue[i].ToString());


            }
            lblTotalAvailableSlots.Text = "Total Available Slots: " + totalcount;
            lblOccupiedSlots.Text = "Total Occupied Slots: " + YellowCounter;
            lblOccupiedSlots.BackColor = Color.Yellow;
            lblFreeSlots.Text = "Total Free Slots: " + GreenCounter;
            lblFreeSlots.BackColor = Color.Green;
            lblFaultySlots.Text = "Total Faulty Slots: " + RedCounter;
            lblFaultySlots.BackColor = Color.Red;

            //lblLoding.Visible = false;
            callMethod(lstZoneValues);

        }

        private void lblTotalSlot_Click(object sender, EventArgs e)
        {

        }

        private void DashboardPanel_Paint(object sender, EventArgs e)
        {
           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalSlots_Click(object sender, EventArgs e)
        {

        }
    }
}
