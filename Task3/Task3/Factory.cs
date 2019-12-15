using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using static ExceptionsLibrary.Exceptions;
using Circle1 = Figures.PaperFigures.Circle;
using Circle2 = Figures.FilmFigures.Circle;
using Rectangle1 = Figures.PaperFigures.Rectangle;
using Rectangle2 = Figures.FilmFigures.Rectangle;
using Triangle1 = Figures.PaperFigures.Triangle;
using Triangle2 = Figures.FilmFigures.Triangle;
using Square1 = Figures.PaperFigures.Square;
using Square2 = Figures.FilmFigures.Square;

namespace Figures
{
    /// <summary>
    /// Factory method for figures
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// return figure from paper
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public Ifigures CutPaperFigure(string figure, params int[] values)
        {
            Ifigures createdFigure = null;
            switch (figure)
            {
                case "Circle":
                    createdFigure = new Circle1(values[0]);
                    break;
                case "Rectangle":
                    createdFigure = new Rectangle1(values[0], values[1]);
                    break;
                case "Square":
                    createdFigure = new Square1(values[0]);
                    break;
                case "Triangle":
                    createdFigure = new Triangle1(values[0], values[1], values[2]);
                    break;
                default:
                    throw new Exception();
            }
            return createdFigure;
        }

        /// <summary>
        /// return figure from film
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public Ifigures CutFilmFigure(string figure, params int[] values)
        {

            Ifigures createdFigure = null;
            switch (figure)
            {
                case "Circle":
                    createdFigure = new Circle2(values[0]);
                    break;
                case "Rectangle":
                    createdFigure = new Rectangle2(values[0], values[1]);
                    break;
                case "Square":
                    createdFigure = new Square2(values[0]);
                    break;
                case "Triangle":
                    createdFigure = new Triangle2(values[0], values[1], values[2]);
                    break;
                default:
                    throw new Exception();
            }
            return createdFigure;
        }

        /// <summary>
        /// return of a figure cut from another figure
        /// </summary>
        /// <param name="sourceFigure"></param>
        /// <param name="cuttingFigure"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public Ifigures CutFigure(Ifigures sourceFigure, string cuttingFigure, params int[] values)
        {
            Ifigures createdFigure = null;
            switch (cuttingFigure)
            {
                case "Circle":
                    if (sourceFigure.GetMaterial() == "Paper") createdFigure = new Circle1(values[0], sourceFigure);
                    else createdFigure = new Circle2(values[0], sourceFigure);
                    break;
                case "Rectangle":
                    if (sourceFigure.GetMaterial() == "Paper") createdFigure = new Rectangle1(values[0], values[1], sourceFigure);
                    else createdFigure = new Rectangle2(values[0], values[1], sourceFigure);
                    break;
                case "Square":
                    if (sourceFigure.GetMaterial() == "Paper") createdFigure = new Square1(values[0], sourceFigure);
                    else createdFigure = new Square2(values[0], sourceFigure);
                    break;
                case "Triangle":
                    if (sourceFigure.GetMaterial() == "Paper") createdFigure = new Triangle1(values[0], values[1], values[2], sourceFigure);
                    else createdFigure = new Triangle2(values[0], values[1], values[2], sourceFigure);
                    break;
                default:
                    throw new InvalidParamException();
            }
            return createdFigure;
        }
    }
}
