using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form, IDraw
    {
        public Form1()
        {
            InitializeComponent();
        }

        Pen myPen = new Pen(System.Drawing.Color.Black);
        int x = 0, y = 0, radius = 0, width = 0, height = 0, counter = 0;
        int loop = 0, kStart = 0, ifcounter = 0;



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string command = textBox1.Text;
            read(command);
        }

        public void read(string command)
        {

        }

        public int getX()
        {
            throw new NotImplementedException();
        }

        public int getY()
        {
            throw new NotImplementedException();
        }

        public void moveTo(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void drawLine(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void drawRectangle(int width, int height)
        {
            throw new NotImplementedException();
        }

        public void drawCircle(int radius)
        {
            throw new NotImplementedException();
        }

        public void drawTriangle(int b, int height)
        {
            throw new NotImplementedException();
        }

        public void drawPolygon(Point[] p)
        {
            throw new NotImplementedException();
        }
    }
}
