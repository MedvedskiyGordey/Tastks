using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task3.Exceptions;
using Circle1 = Task3.PaperFigures.Circle;
using Circle2 = Task3.FilmFigures.Circle;
using Rectangle1 = Task3.PaperFigures.Rectangle;
using Rectangle2 = Task3.FilmFigures.Rectangle;
using Triangle1 = Task3.PaperFigures.Triangle;
using Triangle2 = Task3.FilmFigures.Triangle;
using Square1 = Task3.PaperFigures.Square;
using Square2 = Task3.FilmFigures.Square;

namespace Task3
{
    class Factory
    {
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
