using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task3.Exceptions;

namespace Task3.FilmFigures
{
    class Square : FilmFigure
    {
        private int side;

        public Square(int side)
        {
            if (side <= 0)
            {
                throw new InvalidParamException();
            }
            this.side = side;
        }

        public Square(int side, Ifigures figure)
        {
            this.side = side;

            if (side <= 0)
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
            get { return side * side; }
        }

        public double Perimeter
        {
            get { return 4 * side; }
        }

        public string GetMaterial()
        {
            return "Film";
        }

        public string GetTypeFigure()
        {
            return "Square";
        }

        public override bool Equals(object obj)
        {
            Square square = obj as Square;

            if (obj == null)
            {
                return false;
            }

            return side == square.side && SquareFigure == square.SquareFigure;
        }

        public override int GetHashCode()
        {
            return 34 * side + 2 * GetMaterial().Length * 3;
        }

        public override string ToString()
        {
            string text = "";
            text += GetTypeFigure() + " " + GetMaterial() + " " + side;
            return text;
        }
    }
}
