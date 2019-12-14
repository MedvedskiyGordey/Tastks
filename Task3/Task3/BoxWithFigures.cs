using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task3.Exceptions;

namespace Task3
{
    class BoxWithFigures
    {
        private List<Ifigures> figures;

        public BoxWithFigures()
        {
            figures = new List<Ifigures>();
        }

        public BoxWithFigures(List<Ifigures> figures)
        {
            this.figures = new List<Ifigures>();

            if (figures.Count > 20)
            {
                throw new NoPlaceException();
            }

            for (int i = 0; i < figures.Count; i++)
            {
                figures.Add(figures[i]);
            }
        }

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

        public string FindFigure(Ifigures figure)
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
                    find += i;
                }
            }

            if (find == "")
            {
                find = "Figure not found";
            }

            return find;
        }

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

        public List<Ifigures> GetPaperFigures()
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();//пустая коробка
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
    }
}
