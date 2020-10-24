using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.LSP
{
    class Rectangle
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }

    class Square : Rectangle
    {
        public int Side { get; set; }
    }

    class User
    {
        void RectangleArea()
        {
            var rectangle = new Rectangle();
            rectangle.Height = 5;
            rectangle.Width = 2;

            int area = rectangle.Height * rectangle.Width;
        }

        void SquareArea()
        {
            var rectangle = new Square();
            rectangle.Height = 5;
            rectangle.Width = 2;

            int area = rectangle.Height * rectangle.Width;
        }
    }
}
