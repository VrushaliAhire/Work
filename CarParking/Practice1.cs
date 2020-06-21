using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace CarParking
{
    public partial class Practice1 : Form
    {
        public Practice1()
        {
            InitializeComponent();
        }

        private void Practice1_Load(object sender, EventArgs e)
        {
            RandomNumer();
        }
        private void RandomNumer()
        {
            int[] al = new int[20];
            string[] array = new string[4];
            ArrayList ZoneVaue = new ArrayList();
            int genRand;
            int elementcount = 0;
            Random r;
            for (int i = 0; i < 20; i++)
            {
                r = new Random();
                genRand = r.Next(0, 3);
                Task.Delay(200).Wait();
                al[i] = genRand;
               // String s = genRand.ToString();
               // MessageBox.Show(s);
            }
            for(int j = 0; j<5;j++)
            { 
            for(int i = 0; i<4; i++)
            {
                array[i] = al[elementcount].ToString();
                elementcount++;
               

            }
               // String[] strarray = Array.ConvertAll(array, ele => ele.ToString());
                String s = String.Join("", array);
                ZoneVaue.Add("Z"+j+s);

                MessageBox.Show(ZoneVaue[j].ToString());
               
            }

        }
    }
}
