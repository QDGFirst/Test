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

        /// <summary>
        ///  Converts the text in the text area into a string and excutes the read command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string command = textBox1.Text;
            read(command);
        }


        /// <summary>
        /// Splits the string made from the input of the text field and checks if it is a valid command. 
        /// If it is, it retreives the necessary variables from the input
        /// </summary>
        /// <param name="command"></param>
        public void read(string command)
        {
            try
            {
                command = command.ToLower();
                String[] commandline = command.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < commandline.Length; k++)
                {
                    string[] commands = commandline[k].Split(' ');

                    ///command: moveto
                    ///syntax: moveto xCoordinate,yCoordinate
                    ///Moves the pen to the new coordinate

                    if (commands[0].Equals("moveto"))
                    {
                        string[] coordinates = commands[1].Split(',');
                        int x = 0, y = 0;
                        x = Int32.Parse(coordinates[0]);
                        y = Int32.Parse(coordinates[1]);
                        moveTo(x, y);
                        Console.WriteLine(x + "," + y);
                    }
                    else

                    ///command: drawto
                    ///syntax: drawto xCoordinate,yCoordinate
                    ///Draws a line from the currant coordinate to the new coordinate

                    if (commands[0].Equals("drawto"))
                    {
                        string[] coordinates = commands[1].Split(',');
                        int x, y;
                        x = Int32.Parse(coordinates[0]);
                        y = Int32.Parse(coordinates[1]);
                        drawLine(x, y);
                        Console.WriteLine(x + "," + y);
                    }
                    else

                    ///command: rectangle
                    ///syntax: rectangle width,height
                    ///Draws a rectangle with the entered width and height frm the top right hand corner
                    ///Can be used with either integers or preset width and height parameters

                    if (commands[0].Equals("rectangle"))
                    {
                        string[] dimensions = commands[1].Split(',');
                        if (!dimensions[0].Equals("width"))
                        {
                            width = Int32.Parse(dimensions[0]);
                        }
                        if (!dimensions[1].Equals("height"))
                        {
                            height = Int32.Parse(dimensions[1]);
                        }
                        drawRectangle(width, height);
                    }
                    else

                    ///command: circle
                    ///syntax: circle radius
                    ///Draws a circle with the entered radius from the centre
                    ///Can be used with either integers or preset radius parameter

                    if (commands[0].Equals("circle"))
                    {
                        if (!commands[1].Equals("radius"))
                        {
                            radius = Int32.Parse(commands[1]);
                        }
                        drawCircle(radius);
                    }
                    else

                    ///command: triangle
                    ///syntax: triangle width,height
                    ///Draws a right angled triangle
                    ///Can be used with either integers or preset width and height parameters

                    if (commands[0].Equals("triangle"))
                    {
                        string[] dimensions = commands[1].Split(',');
                        if (!dimensions[0].Equals("width"))
                        {
                            width = Int32.Parse(dimensions[0]);
                        }
                        if (!dimensions[1].Equals("height"))
                        {
                            height = Int32.Parse(dimensions[1]);
                        }
                        drawTriangle(width, height);
                    }
                    else

                     ///command: polygon
                     ///syntax: polygon point1XCoordinate,point1YCoordinate,point2XCoordinate,point2YCoordinate...
                     ///Draws a polygon connecting the coodinates

                     if (commands[0].Equals("polygon"))
                    {
                        string[] points = commands[1].Split(',');
                        if (points.Length > 2 && points.Length % 2 == 0)
                        {
                            Point[] p = new Point[points.Length / 2];
                            int j = 0;
                            for (int i = 0; i < points.Length; i = i + 2)
                            {
                                int point = Int32.Parse(points[i]);
                                p[j].X = point;
                                point = Int32.Parse(points[i + 1]);
                                p[j].Y = point;
                                j++;
                            }
                            drawPolygon(p);
                        }
                    }
                    else

                    ///command: radius
                    ///Syntax: radius = x
                    ///Syntax: radius + x
                    ///Syntax: radius - x
                    ///Sets radius to integer or adds ot subtracts from currant radius

                        if (commands[0].Equals("radius"))
                    {
                        if (commands[1].Equals("="))
                        {
                            radius = Int32.Parse(commands[2]);
                            Console.WriteLine(radius);
                        }
                        else
                        if (commands[1].Equals("+"))
                        {
                            int r;
                            r = Int32.Parse(commands[2]);
                            radius = radius + r;
                            Console.WriteLine(radius);
                        }
                        else
                        if (commands[1].Equals("-"))
                        {
                            int r;
                            r = Int32.Parse(commands[2]);
                            radius = radius - r;
                        }

                    }
                    else

                    ///command: width
                    ///Syntax: width = x
                    ///Syntax: width + x
                    ///Syntax: width - x
                    ///Sets width to integer or adds ot subtracts from currant width

                        if (commands[0].Equals("width"))
                    {
                        if (commands[1].Equals("="))
                        {
                            width = Int32.Parse(commands[2]);
                            Console.WriteLine(width);
                        }
                        else
                        if (commands[1].Equals("+"))
                        {
                            int w;
                            w = Int32.Parse(commands[2]);
                            width = width + w;
                        }
                        else
                        if (commands[1].Equals("-"))
                        {
                            int w;
                            w = Int32.Parse(commands[2]);
                            width = width - w;
                        }
                    }
                    else

                    ///command: height
                    ///Syntax: height = x
                    ///Syntax: height + x
                    ///Syntax: height - x
                    ///Sets height to integer or adds ot subtracts from currant height

                        if (commands[0].Equals("height"))
                    {
                        if (commands[1].Equals("="))
                        {
                            height = Int32.Parse(commands[2]);
                            Console.WriteLine(height);
                        }
                        else
                        if (commands[1].Equals("+"))
                        {
                            int h;
                            h = Int32.Parse(commands[2]);
                            height = height + h;
                        }
                        else
                        if (commands[1].Equals("-"))
                        {
                            int h;
                            h = Int32.Parse(commands[2]);
                            height = height - h;
                        }
                    }
                    else

                    ///command: repeat
                    ///syntax: repeat shape radius/height/width +/- x
                    ///repeats the drawing of circles or rectangles by changing one variable
                        if (commands[0].Equals("repeat"))
                    {
                        int repeat;
                        Int32.TryParse(commands[1], out repeat);
                        for (int m = 0; m < repeat; m++)
                        {
                            if (commands[2].Equals("circle"))
                            {
                                drawCircle(radius);
                                if (commands[3].Equals("radius"))
                                {
                                    if (commands[4].Equals("+"))
                                    {
                                        int r;
                                        r = Int32.Parse(commands[5]);
                                        radius = radius + r;
                                        Console.WriteLine(radius);
                                    }
                                    else
                                    if (commands[4].Equals("-"))
                                    {
                                        int r;
                                        r = Int32.Parse(commands[5]);
                                        radius = radius - r;
                                    }

                                }
                            }
                            else
                            if (commands[2].Equals("rectangle"))
                            {
                                drawRectangle(width, height);
                                if (commands[3].Equals("width"))
                                {
                                    if (commands[4].Equals("+"))
                                    {
                                        int w;
                                        w = Int32.Parse(commands[5]); ;
                                        width = width + w;
                                    }
                                    else
                                    if (commands[4].Equals("-"))
                                    {
                                        int w;
                                        w = Int32.Parse(commands[5]);
                                        width = width - w;
                                    }
                                }
                                else
                                if (commands[3].Equals("height"))
                                {
                                    if (commands[4].Equals("+"))
                                    {
                                        int h;
                                        h = Int32.Parse(commands[5]);
                                        height = height + h;
                                    }
                                    else
                                    if (commands[4].Equals("-"))
                                    {
                                        int h;
                                        h = Int32.Parse(commands[5]);
                                        height = height - h;
                                    }
                                }
                            }
                        }

                    }
                    else
                    ///command: loop
                    ///syntax:  loop x
                    ///         commands
                    ///         end
                    ///         repeats the commands between loop and end a set number of times (x)
                        if (commands[0].Equals("loop"))
                    {
                        if (loop == 0)
                        {
                            counter = Int32.Parse(commands[1]);
                            kStart = k;
                        }

                    }
                    else
                        if (commands[0].Equals("if"))
                    {
                        if (commands[1].Equals("counter") && commands[2].Equals("=") && commands[4].Equals("then"))
                        {
                            Int32.TryParse(commands[3], out ifcounter);
                            if (ifcounter == (loop + 1))
                            {
                                if (commands[5].Equals("radius"))
                                {
                                    if (commands[6].Equals("="))
                                    {
                                        radius = Int32.Parse(commands[7]);
                                        Console.WriteLine(radius);
                                    }
                                    else
                                    if (commands[6].Equals("+"))
                                    {
                                        int r;
                                        r = Int32.Parse(commands[7]);
                                        radius = radius + r;
                                        Console.WriteLine(radius);
                                    }
                                    else
                                    if (commands[6].Equals("-"))
                                    {
                                        int r;
                                        r = Int32.Parse(commands[7]);
                                        radius = radius - r;
                                    }

                                }
                                else
                        if (commands[5].Equals("width"))
                                {
                                    if (commands[6].Equals("="))
                                    {
                                        width = Int32.Parse(commands[7]);
                                        Console.WriteLine(width);
                                    }
                                    else
                                    if (commands[6].Equals("+"))
                                    {
                                        int w;
                                        w = Int32.Parse(commands[7]);
                                        width = width + w;
                                    }
                                    else
                                    if (commands[6].Equals("-"))
                                    {
                                        int w;
                                        w = Int32.Parse(commands[7]);
                                        width = width - w;
                                    }
                                }
                                else
                        if (commands[5].Equals("height"))
                                {
                                    if (commands[6].Equals("="))
                                    {
                                        height = Int32.Parse(commands[7]);
                                        Console.WriteLine(height);
                                    }
                                    else
                                    if (commands[6].Equals("+"))
                                    {
                                        int h;
                                        h = Int32.Parse(commands[7]);
                                        height = height + h;
                                    }
                                    else
                                    if (commands[6].Equals("-"))
                                    {
                                        int h;
                                        h = Int32.Parse(commands[7]);
                                        height = height - h;
                                    }
                                }
                            }
                        }

                    }
                    else
                    ///command: endif
                    ///syntax: endif radius/width/height = x
                    ///ends a loop command only if a certain condition is met
                    if (commands[0].Equals("endif"))
                    {
                        if (commands[1].Equals("radius"))
                        {
                            if (commands[2].Equals("="))
                            {
                                int endifvar;
                                endifvar = Int32.Parse(commands[3]);
                                if (radius == endifvar)
                                {
                                    break;
                                }
                            }

                        }
                        else
                        if (commands[1].Equals("width"))
                        {
                            if (commands[2].Equals("="))
                            {
                                int endifvar;
                                endifvar = Int32.Parse(commands[3]);
                                if (width == endifvar)
                                {
                                    break;
                                }
                            }

                        }
                        else
                        if (commands[1].Equals("height"))
                        {
                            if (commands[2].Equals("="))
                            {
                                int endifvar;
                                endifvar = Int32.Parse(commands[3]);
                                if (height == endifvar)
                                {
                                    break;
                                }
                            }

                        }

                    }
                    else
                    if (commands[0].Equals("end"))
                    {
                        if (counter > 0)
                        {
                            loop++;
                        }
                        if (counter == loop)
                        {
                            counter = 0;
                            loop = 0;

                        }
                        else
                        {
                            k = kStart;
                        }

                    }
                    else
                    ///If no commands are entered on the first line nothing will run
                        if (!commands[0].Equals(null))
                    {
                        int errorLine = k + 1;
                        MessageBox.Show("Command not recognised on line " + errorLine, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            catch (IndexOutOfRangeException e)
            {
                MessageBox.Show("Command not recognised.  Please check your syntax.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException e)
            {
                MessageBox.Show("Command not recognised.  Please check your syntax.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// returns the x value of the pen
        /// </summary>
        /// <returns>x</returns>
        public int getX()
        {
            return x;
        }

        /// <summary>
        /// returns the y value of the pen
        /// </summary>
        /// <returns>y</returns>
        public int getY()
        {
            return y;
        }
        /// <summary>
        /// movse the pen to the new coordinate
        /// </summary>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        public void moveTo(int toX, int toY)
        {
            x = toX;
            y = toY;
        }
        /// <summary>
        /// draws a line from the current coordinate to the corrdinates entered
        /// </summary>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        public void drawLine(int toX, int toY)
        {
            Graphics graphicsObj = this.CreateGraphics();
            graphicsObj.DrawLine(myPen, x, y, toX, toY);
            moveTo(toX, toY);
        }
        /// <summary>
        /// Draws a rectangle with the entered width and height frm the top left hand corner
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void drawRectangle(int width, int height)
        {
            Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            graphicsObj.DrawRectangle(myPen, x, y, width, height);
            x = x + width;
            y = y + height;
        }
        /// <summary>
        /// draws a circle with the entered radius from the centre of the circle
        /// </summary>
        /// <param name="radius"></param>
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
        /// <summary>
        /// Draws a right angled triangle from the currant coordinate with the entered width and height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
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
        /// <summary>
        /// Draws a polygon from the currant coordinate to the points entered in an array
        /// </summary>
        /// <param name="sides"></param>
        public void drawPolygon(Point[] sides)
        {
            Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            graphicsObj.DrawPolygon(myPen, sides);
        }
    }
}
