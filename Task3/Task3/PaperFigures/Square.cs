using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using static ExceptionsLibrary.Exceptions;

namespace Figures.PaperFigures
{
    /// <summary>
    /// Square class
    /// </summary>
    class Square : PaperFigure
    {
        private int side;
        Color colorIndex;

        /// <summary>
        /// Constructor for creating
        /// </summary>
        /// <param name="side"></param>
        public Square(int side)
        {
            if (side <= 0)
            {
                throw new InvalidParamException();
            }
            this.side = side;
            colorIndex = 0;
        }

        /// <summary>
        /// Constructor for cutting
        /// </summary>
        /// <param name="side"></param>
        /// <param name="figure"></param>
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

        /// <summary>
        /// Return color figure
        /// </summary>
        /// <returns></returns>
        public Color GetColor()
        {
            return colorIndex;
        }

        /// <summary>
        /// Return material figure
        /// </summary>
        /// <returns></returns>
        public string GetMaterial()
        {
            return "Paper";
        }

        /// <summary>
        /// Return paper figure
        /// </summary>
        /// <returns></returns>
        public string GetTypeFigure()
        {
            return "Square";
        }

        /// <summary>
        /// return is the figure painted
        /// </summary>
        /// <returns></returns>
        public bool Painted()
        {
            return (colorIndex != Color.None);
        }


        /// <summary>
        /// paint figure
        /// </summary>
        /// <param name="color"></param>
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

