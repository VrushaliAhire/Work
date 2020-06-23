using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using CarParking.Model;

namespace CarParking
{
    public partial class CarParkingApp : Form
    {
        public CarParkingApp()
        {
            InitializeComponent();
        }
        String ZName;
        String SenString;

        public void callMethod()
        {
            CallSP sp = new CallSP();
            sp.Test(ZName, SenString);
        }

        private System.Windows.Forms.Timer timer1;
        public void InitTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(renderPanel);
            timer1.Interval = 10000;
            timer1.Start(); 
        }
        
        private void CarParkingApp_Load(object sender, EventArgs e)
        {
          renderPanel(sender, e);
            InitTimer();
            
        }
        
        private void renderPanel(object sender, EventArgs e)
        {
            lblLoding.Visible = true;
            progressBar1.Maximum = 40;
            progressBar1.Value = 0;
            
            int[] al = new int[20];
            ArrayList ZoneVaue = new ArrayList();
           
            int genRand;
            Random r;
            for (int i = 0; i < 20; i++)
            {
                r = new Random();
                genRand = r.Next(0, 3);
                Task.Delay(200).Wait();
                al[i] = genRand;
                progressBar1.Value++;
            }
            int rowcounter = 5;
            int columncounter = 4;
            string[] array = new string[columncounter];
            // int totalcount = 18;
            int elementcount = 0;
            Panel1.Controls.Clear();

            SensorData sData = new SensorData();

            for (int i = 0; i < rowcounter; i++)
            {
                for (int j = 0; j < columncounter; j++)
                {

                    progressBar1.Value++;
                   
                    Label lable = new Label();
                    Panel1.Controls.Add(lable);
                    lable.Top = (i * 50);
                    lable.Width = 80;
                    lable.Left = j * 90;
                    lable.BackColor = Color.Aqua;
                    lable.TextAlign = ContentAlignment.MiddleCenter;
                    lable.Text = "P" + elementcount;

                    if (al[elementcount] == 0)
                    {
                        lable.BackColor = Color.Green;
                    }
                    else if (al[elementcount] == 1)
                    {
                        lable.BackColor = Color.Yellow;
                    }
                    if (al[elementcount] == 2)
                    {
                        lable.BackColor = Color.Red;
                    }
                    array[j] = al[elementcount].ToString();
                    elementcount++;
                }
               
                String s = String.Join("", array);
                sData = new SensorData();
                sData.ZoneName = "Z" + i;
                sData.SensorString = "Z" + i + "#" + s;
                ZoneVaue.Add(sData);
                 ZName = sData.ZoneName;
                 SenString = sData.SensorString;
                callMethod();
                
               // MessageBox.Show(ZoneVaue[i].ToString());


            }
            lblLoding.Visible = false;
        }
        
       
      
        private void btn_Exist_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
