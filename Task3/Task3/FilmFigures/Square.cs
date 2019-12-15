using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using static ExceptionsLibrary.Exceptions;

namespace Figures.FilmFigures
{
    /// <summary>
    /// Square class
    /// </summary>
    public class Square : FilmFigure
    {
        private int side;

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
        /// return material figure
        /// </summary>
        /// <returns></returns>
        public string GetMaterial()
        {
            return "Film";
        }

        /// <summary>
        /// return material figure
        /// </summary>
        /// <returns></returns>
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
