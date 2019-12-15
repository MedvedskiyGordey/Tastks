using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using static ExceptionsLibrary.Exceptions;
using FilesWorker;

namespace BoxWithFigures
{
    public class Box
    {
        private List<Ifigures> figures;

        /// <summary>
        /// constructor
        /// </summary>
        public Box()
        {
            figures = new List<Ifigures>();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="figures"></param>
        public Box(List<Ifigures> figures)
        {
            this.figures = new List<Ifigures>();

            if (figures.Count > 20)
            {
                throw new NoPlaceException();
            }

            for (int i = 0; i < figures.Count; i++)
            {
                this.figures.Add(figures[i]);
            }
        }

        /// <summary>
        /// Add figure into box
        /// </summary>
        /// <param name="figure"></param>
        public void Add(Ifigures figure)
        {
            if (figures.Count == 20)
            {
                throw new NoPlaceException();
            }
            if (figures.Count == 0)
            {
                figures.Add(figure);
                return;
            }
            for (int i = 0; i < figures.Count; i++)
            {
                if (figure.GetHashCode() == figures[i].GetHashCode())
                {
                    if (figure.Equals(figures[i])) throw new ExistFigureException();
                }
            }
            figures.Add(figure);
        }

        /// <summary>
        /// get figure from box
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public Ifigures GetFigure(int num)
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();
            }
            if (num > figures.Count || num <= 0)
            {
                throw new InvalidParamException();
            }
            return figures[num - 1];
        }

        /// <summary>
        /// delete figure from box
        /// </summary>
        /// <param name="num"></param>
        public void DeleteFigure(int num)
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();
            }
            if (num > figures.Count || num <= 0)
            {
                throw new InvalidParamException();
            }
            figures.RemoveAt(num - 1);
        }

        /// <summary>
        /// replace figure
        /// </summary>
        /// <param name="num"></param>
        /// <param name="figure"></param>
        public void ReplaceFigure(int num, Ifigures figure)
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();
            }
            if (num > figures.Count || num <= 0)
            {
                throw new InvalidParamException();
            }
            for (int i = 0; i < figures.Count; i++)
            {
                if (figure.GetHashCode() == figures[i].GetHashCode())
                {
                    if (figure.Equals(figures[i])) throw new ExistFigureException();
                }
            }
            figures[num - 1] = figure;
        }

        /// <summary>
        /// find figure in box
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public int FindFigure(Ifigures figure)
        {
            string find = "";

            if (figures.Count == 0)
            {
                throw new EmptyBoxException();
            }

            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].Equals(figure))
                {
                    return i;
                }
            }

            return -555;
        }

        /// <summary>
        /// sum of squares of figures
        /// </summary>
        /// <returns></returns>
        public double SquareSum()
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();
            }
            double squareSum = 0;
            for (int i = 0; i < figures.Count; i++)
            {
                squareSum += figures[i].SquareFigure;
            }
            return squareSum;
        }

        /// <summary>
        /// sum of perimeters of figures
        /// </summary>
        /// <returns></returns>
        public double PerimeterSum()
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();
            }
            double perimetrSum = 0;
            for (int i = 0; i < figures.Count; i++)
            {
                perimetrSum += figures[i].Perimeter;
            }
            return perimetrSum;
        }

        /// <summary>
        /// get all circles from box
        /// </summary>
        /// <returns></returns>
        public List<Ifigures> GetCircles()
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();
            }
            List<Ifigures> circles = new List<Ifigures>();
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].GetTypeFigure() == "Circle")
                {
                    circles.Add(figures[i]);
                }
            }
            return circles;
        }

        /// <summary>
        /// get all film figures from box
        /// </summary>
        /// <returns></returns>
        public List<Ifigures> GetFilmFigures()
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();
            }
            List<Ifigures> filmfigures = new List<Ifigures>();
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].GetMaterial() == "Film")
                {
                    filmfigures.Add(figures[i]);
                }
            }
            return filmfigures;
        }

        /// <summary>
        /// get all paper figures from box
        /// </summary>
        /// <returns></returns>
        public List<Ifigures> GetPaperFigures()
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();
            }
            List<Ifigures> paperfigures = new List<Ifigures>();
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].GetMaterial() == "Paper")
                {
                    paperfigures.Add(figures[i]);
                }
            }
            return paperfigures;
        }

        /// <summary>
        /// write to file
        /// </summary>
        /// <param name="material"></param>
        /// <param name="filePath"></param>
        public void WriteToFile(string material, string filePath)
        {
            string fileFormat = filePath[filePath.Length - 3].ToString() + filePath[filePath.Length - 2].ToString() + filePath[filePath.Length - 1].ToString();
            if (fileFormat != "txt" && fileFormat != "xml")
            {
                throw new InvalidParamException();
            }

            switch (material)
            {
                case "All":
                    if (fileFormat == "txt") Txt.WriteToFile(figures, filePath);
                    else Xml.WriteToXml(figures, filePath);
                    break;
                case "Paper":
                    if (fileFormat == "txt") Txt.WriteToFile(GetPaperFigures(), filePath);
                    else Xml.WriteToXml(GetPaperFigures(), filePath);
                    break;
                case "Film":
                    if (fileFormat == "txt") Txt.WriteToFile(GetFilmFigures(), filePath);
                    else Xml.WriteToXml(GetFilmFigures(), filePath);
                    break;
                default:
                    throw new InvalidParamException();
            }
        }

        /// <summary>
        /// read from file
        /// </summary>
        /// <param name="filePath"></param>
        public void ReadFromFile(string filePath)
        {
            string fileFormat = filePath[filePath.Length - 3].ToString() + filePath[filePath.Length - 2].ToString() + filePath[filePath.Length - 1].ToString();
            switch (fileFormat)
            {
                case "txt":
                    figures = Txt.ReadFromFile(filePath);
                    break;
                case "xml":
                    figures = Xml.ReadFromXml(filePath);
                    break;
                default:
                    throw new InvalidParamException();
            }
            if (figures.Count > 20)
                throw new NoPlaceException();
        }

        /// <summary>
        /// get cont figures in box
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return figures.Count;
        }

        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < figures.Count; i++)
            {
                text += (i + 1) + figures[i].ToString() + "\n";
            }
            return text;
        }
    }
}