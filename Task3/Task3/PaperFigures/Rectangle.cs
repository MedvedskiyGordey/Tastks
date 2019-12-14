using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task3.Exceptions;

namespace Task3.PaperFigures
{
    class Rectangle : PaperFigure
    {
        private int[] sides;
        Color colorIndex;

        public Rectangle(int a, int b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new InvalidParamException();
            }
            sides = new int[2] { a, b };
            colorIndex = 0;
        }

        public Rectangle(int a, int b, Ifigures figure)
        {
            sides = new int[2] { a, b };

            if (a <= 0 || b <= 0)
            {
                throw new InvalidParamException();
            }

            Array.Sort(sides);

            if (figure.SquareFigure < SquareFigure)
            {
                throw new CutException();
            }
            colorIndex = ((PaperFigure)figure).GetColor();
        }

        public double SquareFigure
        {
            get { return sides[0] * sides[1]; }
        }

        public double Perimeter
        {
            get { return 2 * (sides[0] + sides[1]); }
        }

        public Color GetColor()
        {
            return colorIndex;
        }

        public string GetMaterial()
        {
            return "Paper";
        }

        public string GetTypeFigure()
        {
            return "Rectangle";
        }

        public bool Painted()
        {
            return (colorIndex != Color.None);
        }

        public void Paint(Color color)
        {
            if (!Painted())
            {
                colorIndex = color;
            }
            else
            {
                throw new PaintException();
            }
        }

        public override bool Equals(object obj)
        {
            Rectangle rectangle = obj as Rectangle;
            if (obj == null)
            {
                return false;
            }
            return sides == rectangle.sides && colorIndex == rectangle.colorIndex && SquareFigure == rectangle.SquareFigure;
        }

        public override int GetHashCode()
        {
            return sides[0] * 23 + sides[1] * 32 + GetMaterial().Length * 3;
        }

        public override string ToString()
        {
            string text = "";
            text += GetTypeFigure() + " " + GetMaterial() + " " + (int)GetColor() + " " + sides[0] + " " + sides[1];
            return text;
        }
    }
}
