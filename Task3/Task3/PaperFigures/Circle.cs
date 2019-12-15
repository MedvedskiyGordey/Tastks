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
    /// Circle class
    /// </summary>
    class Circle : PaperFigure
    {
        private int radius;
        Color colorIndex;

        /// <summary>
        /// Constructor for creating
        /// </summary>
        /// <param name="radius"></param>
        public Circle(int radius)
        {
            this.radius = radius;

            if (radius <= 0)
            {
                throw new InvalidParamException();
            }

            colorIndex = 0;
        }

        /// <summary>
        /// Constructor for cutting
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="figure"></param>
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


        /// <summary>
        /// Square figure
        /// </summary>
        public double SquareFigure
        {
            get { return Math.PI * radius * radius; }
        }

        /// <summary>
        /// Perimeter figure
        /// </summary>
        public double Perimeter
        {
            get { return 2 * Math.PI * radius; }
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
        /// Return type figure
        /// </summary>
        /// <returns></returns>
        public string GetTypeFigure()
        {
            return "Circle";
        }

        /// <summary>
        /// return is the figure painted
        /// </summary>
        /// <returns></returns>
        public bool Painted()
        {
            return (GetColor() != Color.None);
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
