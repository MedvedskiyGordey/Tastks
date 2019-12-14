using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task3.Exceptions;

namespace Task3.FilmFigures
{
    class Circle : FilmFigure
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;

            if (radius <= 0)
            {
                throw new InvalidParamException();
            }
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
        }

        public double SquareFigure
        {
            get { return Math.PI * radius * radius; }
        }

        public double Perimeter
        {
            get { return 2 * Math.PI * radius; }
        }

        public string GetMaterial()
        {
            return "Film";
        }

        public string GetTypeFigure()
        {
            return "Circle";
        }

        public override bool Equals(object obj)
        {
            Circle circle = obj as Circle;
            if (obj == null)
            {
                return false;
            }
            return radius == circle.radius && SquareFigure == circle.SquareFigure;
        }

        public override int GetHashCode()
        {
            return radius * 314 + GetMaterial().Length * 3;
        }

        public override string ToString()
        {
            string text = "";
            text += GetTypeFigure() + " " + GetMaterial() + " " + radius;
            return text;
        }
    }
}

