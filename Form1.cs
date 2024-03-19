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

namespace GUI_Serial_Interface
{
    public partial class Form1 : Form
    {
        private int pointX = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.AddXY(pointX, 20);
            pointX++;
        }

        private void AddPointToChart(int x, int y) 
        {
            chart1.Series["Series1"].Points.AddXY(x, y);
        }

        public void ChartChildThread()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                while (true)
                {
                    chart1.Series["Series1"].Points.AddXY(pointX, 20);
                    pointX++;
                }
            }).Start();

        }
    }
}
