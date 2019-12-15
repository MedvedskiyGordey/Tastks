using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Interfaces;
using Figures;

namespace FilesWorker
{
    /// <summary>
    /// work with xml file
    /// </summary>
    public class Xml
    {
        private static Factory factory = new Factory();

        /// <summary>
        /// Read xml file
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns></returns>
        public static List<Ifigures> ReadFromXml(string filePath)
        {
            List<Ifigures> figures = new List<Ifigures>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                Ifigures figure;
                int color = 0;
                string figureType = "";
                string material = "";
                int index = 0;
                int[] values = new int[3];

                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("type");
                    if (attr != null)
                        figureType = attr.Value;
                }

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "material")
                    {
                        material = childnode.InnerText;
                    }
                    if (childnode.Name == "color")
                    {
                        color = int.Parse(childnode.InnerText);
                    }
                    if (childnode.Name == "param")
                    {
                        values[index] = int.Parse(childnode.InnerText);
                        index++;
                    }
                }

                if (material == "Paper")
                {
                    figure = factory.CutPaperFigure(figureType, values);
                    ((PaperFigure)figure).Paint((Color)color);
                }
                else
                {
                    figure = factory.CutFilmFigure(figureType, values);
                }
                figures.Add(figure);
            }
            return figures;
        }

        /// <summary>
        /// write to xml file
        /// </summary>
        /// <param name="figures"></param>
        /// <param name="filePath"></param>
        public static void WriteToXml(List<Ifigures> figures, string filePath)
        {
            XDocument document = new XDocument();
            XElement elements = new XElement("figures");
            foreach (Ifigures i in figures)
            {
                int index;
                XElement figure = new XElement("figure");
                XAttribute type = new XAttribute("type", i.GetTypeFigure());
                figure.Add(type);
                XElement material = new XElement("material", i.GetMaterial());
                figure.Add(material);
                if (i.GetMaterial() == "Paper")
                {
                    XElement color = new XElement("color", (int)((PaperFigure)i).GetColor());
                    figure.Add(color);
                    index = 3;
                }
                else
                {
                    index = 2;
                }
                string[] text = i.ToString().Split(' ');
                int[] values = new int[3];
                for (int j = index; j < text.Length; j++)
                {
                    figure.Add(new XElement("param", int.Parse(text[j])));
                }
                elements.Add(figure);
            }
            document.Add(elements);
            document.Save(filePath);
        }
    }
}