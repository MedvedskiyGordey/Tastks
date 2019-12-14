using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task3.Exceptions;

namespace Task3
{
    class Circle : PaperFigure
    {
        private int radius;
        Color colorIndex;

        public Circle(int radius)
        {
            this.radius = radius;

            if (radius <= 0)
            {
                throw new InvalidParamException();
            }

            colorIndex = 0;
        }

        public Circle(int radius, Ifigures figure)
        {
            this.radius = radius;

            if (radius <= 0)
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
            get { return Math.PI * radius * radius; }
        }

        public double Perimeter
        {
            get { return 2 * Math.PI * radius; }
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
            return "Circle";
        }

        public bool Painted()
        {
            return (GetColor() != Color.None);
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
            Circle circle = obj as Circle;
            if (obj == null)
            {
                return false;
            }
            return radius == circle.radius && SquareFigure == circle.SquareFigure && colorIndex == circle.colorIndex;
        }

        public override int GetHashCode()
        {
            return radius * 314 + GetMaterial().Length * 3;
        }

        public override string ToString()
        {
            string text = "";
            text += GetTypeFigure() + " " + GetMaterial() + " " + (int)GetColor() + " " + radius;
            return text;
        }
    }
}
