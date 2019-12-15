using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Figures;
using System.IO;

namespace FilesWorker
{
    /// <summary>
    /// work with txt file
    /// </summary>
    public class Txt
    {
        private static Factory factory = new Factory();

        /// <summary>
        /// read txt file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns></returns>
        public static List<Ifigures> ReadFromFile(string filePath)
        {
            List<Ifigures> figures = new List<Ifigures>();
            string strline = "";
            using (StreamReader SR = new StreamReader(filePath))
            {
                while ((strline = SR.ReadLine()) != null)
                {
                    int index;
                    string[] text = strline.Split(' ');
                    string figureType = text[0];
                    int[] values = new int[4];
                    if (text[1] == "Paper")
                    {
                        index = 3;
                        Color color = (Color)(int.Parse(text[2]));
                        for (int i = index; i < text.Length; i++)
                        {
                            values[i - index] = int.Parse(text[i]);
                        }
                        Ifigures figure = factory.CutPaperFigure(figureType, values);
                        ((PaperFigure)figure).Paint(color);
                        figures.Add(figure);
                    }
                    else
                    {
                        index = 2;
                        for (int i = index; i < text.Length; i++)
                        {
                            values[i - index] = int.Parse(text[i]);
                        }
                        Ifigures figure = factory.CutFilmFigure(figureType, values);
                        figures.Add(figure);
                    }
                }
            }
            return figures;
        }

        /// <summary>
        /// write to txt file
        /// </summary>
        /// <param name="figures"></param>
        /// <param name="filePath"></param>
        public static void WriteToFile(List<Ifigures> figures, string filePath)
        {
            using (StreamWriter SW = new StreamWriter(filePath))
            {
                foreach (Ifigures i in figures)
                {
                    SW.WriteLine(i.ToString());
                }
            }
        }
    }
}
