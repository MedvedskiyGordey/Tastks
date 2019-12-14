using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task3.Exceptions;

namespace Task3.FilmFigures
{
    class Rectangle : FilmFigure
    {
        private int[] sides;

        public Rectangle(int a, int b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new InvalidParamException();
            }
            sides = new int[2] { a, b };

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
        }

        public double SquareFigure
        {
            get { return sides[0] * sides[1]; }
        }

        public double Perimeter
        {
            get { return 2 * (sides[0] + sides[1]); }
        }

        public string GetMaterial()
        {
            return "Film";
        }

        public string GetTypeFigure()
        {
            return "Rectangle";
        }

        public override bool Equals(object obj)
        {
            Rectangle rectangle = obj as Rectangle;
            if (obj == null)
            {
                return false;
            }
            return sides == rectangle.sides && SquareFigure == rectangle.SquareFigure;
        }

        public override int GetHashCode()
        {
            return sides[0] * 23 + sides[1] * 32 + GetMaterial().Length * 3;
        }

        public override string ToString()
        {
            string text = "";
            text += GetTypeFigure() + " " + GetMaterial() + " " + sides[0] + " " + sides[1];
            return text;
        }
    }
}
