using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task3.Exceptions;

namespace Task3
{
    class Triangle : PaperFigure
    {
        private int[] sides;
        Color colorIndex;

        public Triangle(int a, int b, int c)
        {
            sides = new int[3] { a, b, c };

            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new InvalidParamException();
            }

            colorIndex = 0;
        }

        public Triangle(int a, int b, int c, Ifigures figure)
        {
            sides = new int[3] { a, b, c };

            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new InvalidParamException();
            }

            if (figure.SquareFigure < SquareFigure)
            {
                throw new CutException();
            }
            colorIndex = ((PaperFigure)figure).GetColor();
        }

        public double SquareFigure
        {
            get { return Math.Sqrt(Perimeter / 2 * (Perimeter / 2 - sides[0]) * (Perimeter / 2 - sides[1]) * (Perimeter / 2 - sides[2])); }
        }

        public double Perimeter
        {
            get { return sides[0] + sides[1] + sides[2]; }
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
            return "Triangle";
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
            Triangle triangle = obj as Triangle;

            if (obj == null)
            {
                return false;
            }

            return sides == triangle.sides && colorIndex == triangle.colorIndex && SquareFigure == triangle.SquareFigure;
        }

        public override int GetHashCode()
        {
            return sides[0] * 9 + sides[1] * 54 + sides[2] * 13 + GetMaterial().Length * 3;
        }

        public override string ToString()
        {
            string text = "";
            text += GetTypeFigure() + " " + GetMaterial() + " " + (int)GetColor() + " " + sides[0] + " " + sides[1] + " " + sides[2];
            return text;
        }
    }
}
