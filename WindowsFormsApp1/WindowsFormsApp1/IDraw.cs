using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    interface IDraw
    {
        int getX();

        int getY();

        void moveTo(int x, int y);

        void drawLine(int x, int y);

        void drawRectangle(int width, int height);

        void drawCircle(int radius);

        void drawTriangle(int b, int height);

        void drawPolygon(Point[] p);
    }
}
