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
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void moveTo(int toX, int toY)
        {
            x = toX;
            y = toY;
        }

        public void drawLine(int toX, int toY)
        {
            Graphics graphicsObj = this.CreateGraphics();
            graphicsObj.DrawLine(myPen, x, y, toX, toY);
            moveTo(toX, toY);
        }

        public void drawRectangle(int width, int height)
        {
            Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            graphicsObj.DrawRectangle(myPen, x, y, width, height);
            x = x + width;
            y = y + height;
        }

        public void drawCircle(int radius)
        {
            Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            x = x - radius / 2;
            y = y - radius / 2;
            graphicsObj.DrawEllipse(myPen, x, y, radius / 2, radius / 2);
            x = x + radius / 2;
            y = y + radius / 2;
        }

        public void drawTriangle(int width, int height)
        {
            Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Point[] p = new Point[3];
            p[0].X = x;
            p[0].Y = y;

            p[1].X = x + width;
            p[1].Y = y;

            p[2].X = x + width;
            p[2].Y = y - height;

            graphicsObj.DrawPolygon(myPen, p);

        }

        public void drawPolygon(Point[] sides)
        {
            Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            graphicsObj.DrawPolygon(myPen, sides);
        }
    }
}
