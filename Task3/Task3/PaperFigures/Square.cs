using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task3.Exceptions;

namespace Task3.PaperFigures
{
    class Square : PaperFigure
    {
        private int side;
        Color colorIndex;

        public Square(int side)
        {
            if (side <= 0)
            {
                throw new InvalidParamException();
            }
            this.side = side;
            colorIndex = 0;
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
            colorIndex = ((PaperFigure)figure).GetColor();
        }

        public double SquareFigure
        {
            get { return side * side; }
        }

        public double Perimeter
        {
            get { return 4 * side; }
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
            return "Square";
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
            Square square = obj as Square;

            if (obj == null)
            {
                return false;
            }

            return side == square.side && colorIndex == square.colorIndex && SquareFigure == square.SquareFigure;
        }

        public override int GetHashCode()
        {
            return 34 * side + 2 * GetMaterial().Length * 3;
        }

        public override string ToString()
        {
            string text = "";
            text += GetTypeFigure() + " " + GetMaterial() + " " + (int)GetColor() + " " + side;
            return text;
        }
    }
}

