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
    /// Circle class
    /// </summary>
    public class Circle : FilmFigure
    {
        private int radius;

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
        /// Return material figure
        /// </summary>
        /// <returns></returns>
        public string GetMaterial()
        {
            return "Film";
        }

        /// <summary>
        /// Return type figure
        /// </summary>
        /// <returns></returns>
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

