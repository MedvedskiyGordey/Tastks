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
    /// Rectangle class
    /// </summary>
    class Rectangle : PaperFigure
    {
        private int[] sides;
        Color colorIndex;

        /// <summary>
        /// Constructor for creating
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Rectangle(int a, int b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new InvalidParamException();
            }
            sides = new int[2] { a, b };
            colorIndex = 0;
        }

        /// <summary>
        /// Constructor for cutting
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="figure"></param>
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

        /// <summary>
        /// return color figure
        /// </summary>
        /// <returns></returns>
        public Color GetColor()
        {
            return colorIndex;
        }

        /// <summary>
        /// return material figure
        /// </summary>
        /// <returns></returns>
        public string GetMaterial()
        {
            return "Paper";
        }

        /// <summary>
        /// return type figure
        /// </summary>
        /// <returns></returns>
        public string GetTypeFigure()
        {
            return "Rectangle";
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
