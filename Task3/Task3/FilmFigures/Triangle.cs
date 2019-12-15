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
    /// Triangle class
    /// </summary>
    public class Triangle : FilmFigure
    {
        private int[] sides;

        /// <summary>
        /// Constructor for creating
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public Triangle(int a, int b, int c)
        {
            sides = new int[3] { a, b, c };

            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new InvalidParamException();
            }
        }

        /// <summary>
        /// Constructor for cutting
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="figure"></param>
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
        }

        public double SquareFigure
        {
            get { return Math.Sqrt(Perimeter / 2 * (Perimeter / 2 - sides[0]) * (Perimeter / 2 - sides[1]) * (Perimeter / 2 - sides[2])); }
        }

        public double Perimeter
        {
            get { return sides[0] + sides[1] + sides[2]; }
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
        /// return type figure
        /// </summary>
        /// <returns></returns>
        public string GetTypeFigure()
        {
            return "Triangle";
        }

        public override bool Equals(object obj)
        {
            Triangle triangle = obj as Triangle;

            if (obj == null)
            {
                return false;
            }

            return sides == triangle.sides && SquareFigure == triangle.SquareFigure;
        }

        public override int GetHashCode()
        {
            return sides[0] * 9 + sides[1] * 54 + sides[2] * 13 + GetMaterial().Length * 3;
        }

        public override string ToString()
        {
            string text = "";
            text += GetTypeFigure() + " " + GetMaterial() + " " + sides[0] + " " + sides[1] + " " + sides[2];
            return text;
        }
    }
}
