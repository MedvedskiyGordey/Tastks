using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;
using Interfaces;
using BoxWithFigures;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        Factory factory = new Factory();
        string filePathTxt = "..\\..\\..\\files\\text.txt";
        string filePathXml = "..\\..\\..\\files\\text.xml";
        string filePathTxt2 = "..\\..\\..\\files\\text2.txt";
        string filePathXml2 = "..\\..\\..\\files\\text2.xml";

        /// <summary>
        /// Read from txt file test
        /// </summary>
        [TestMethod]
        public void ReadTxtTest()
        {
            Box box = new Box();
            box.ReadFromFile(filePathTxt);
            Ifigures figure1 = factory.CutPaperFigure("Circle", 4);
            Ifigures figure2 = factory.CutFilmFigure("Square", 10);
            box.Add(figure1);
            box.Add(figure2);
            Assert.IsTrue(figure1.Equals(box.GetFigure(box.GetCount() - 1)));
            Assert.IsTrue(figure2.Equals(box.GetFigure(box.GetCount())));
        }


        /// <summary>
        /// Read from xml file test
        /// </summary>
        [TestMethod]
        public void ReadXmlTest()
        {
            Box box = new Box();
            box.ReadFromFile(filePathXml);
            Ifigures figure1 = factory.CutPaperFigure("Rectangle", 14, 15);
            Ifigures figure2 = factory.CutFilmFigure("Circle", 3);
            box.Add(figure1);
            box.Add(figure2);
            Assert.IsTrue(figure1.Equals(box.GetFigure(box.GetCount() - 1)));
            Assert.IsTrue(figure2.Equals(box.GetFigure(box.GetCount())));
        }

        /// <summary>
        /// Write and read from txt file test
        /// </summary>
        [TestMethod]
        public void WriteAndReadTxtTest()
        {
            Box box = new Box();
            box.ReadFromFile(filePathTxt);
            box.WriteToFile("Film", filePathTxt2);

            Box box2 = new Box();
            box2.ReadFromFile(filePathTxt2);
            for (int i = 0; i < box2.GetCount(); i++)
            {
                Assert.IsTrue(box2.GetFigure(i + 1).GetMaterial() == "Film");
            }
        }

        /// <summary>
        /// Write and read from xml file test
        /// </summary>
        [TestMethod]
        public void WriteAndReadXmlTest()
        {
            Box box = new Box();
            box.ReadFromFile(filePathXml);
            box.WriteToFile("Paper", filePathXml2);

            Box box2 = new Box();
            box2.ReadFromFile(filePathXml2);
            for (int i = 0; i < box2.GetCount(); i++)
            {
                Assert.IsTrue(box2.GetFigure(i + 1).GetMaterial() == "Paper");
            }
        }

        /// <summary>
        /// Tes for Delete and Add into box
        /// </summary>
        [TestMethod]
        public void DeleteAndAddTest()
        {
            Box box = new Box();
            Ifigures figure = factory.CutFilmFigure("Circle", 8);
            box.Add(figure);
            box.Add(factory.CutFilmFigure("Rectangle", 9, 5));
            Assert.IsTrue(box.GetCount() == 2);
            box.DeleteFigure(box.GetCount() - 1);
            Assert.IsTrue(box.GetCount() == 1);
        }

        /// <summary>
        /// Tes for Replace and Find into box
        /// </summary>
        [TestMethod]
        public void ReplaceAndFindTest()
        {
            Box box = new Box();
            bool find;
            Ifigures figure = factory.CutPaperFigure("Triangle", 8, 10, 12);
            box.Add(factory.CutFilmFigure("Triangle", 12, 13, 15));
            box.Add(factory.CutFilmFigure("Circle", 8));
            box.Add(factory.CutFilmFigure("Rectangle", 9, 5));
            box.ReplaceFigure(box.GetCount() - 2, figure);
            find = box.FindFigure(figure) != -555;
            Assert.IsTrue(find);
        }

        /// <summary>
        /// Test for methods GetFilmFigures(), GetPaperFigures(), GetCircles();
        /// </summary>
        [TestMethod]
        public void GetDifferentFiguresTest()
        {
            Box box = new Box();
            box.Add(factory.CutFilmFigure("Circle", 8));
            box.Add(factory.CutPaperFigure("Rectangle", 9, 5));
            box.Add(factory.CutFilmFigure("Rectangle", 9, 5));
            Box boxWithCircles = new Box(box.GetCircles());
            Box boxWithPaper = new Box(box.GetPaperFigures());
            Box boxWithFilm = new Box(box.GetFilmFigures());
            for (int i = 0; i < boxWithCircles.GetCount(); i++)
            {
                Assert.IsTrue(boxWithCircles.GetFigure(i + 1).GetTypeFigure() == "Circle");
            }
            for (int i = 0; i < boxWithPaper.GetCount(); i++)
            {
                Assert.IsTrue(boxWithPaper.GetFigure(i + 1).GetMaterial() == "Paper");
            }
            for (int i = 0; i < boxWithFilm.GetCount(); i++)
            {
                Assert.IsTrue(boxWithFilm.GetFigure(i + 1).GetMaterial() == "Film");
            }
        }

        /// <summary>
        /// The test of the sum of the square and perimeters
        /// </summary>
        [TestMethod]
        public void TestSum()
        {
            double perimetrSum = 0;
            double squareSum = 0;
            Box box = new Box();
            box.Add(factory.CutPaperFigure("Circle", 2));
            box.Add(factory.CutPaperFigure("Square", 10));
            box.Add(factory.CutPaperFigure("Rectangle", 3, 6));
            box.Add(factory.CutPaperFigure("Triangle", 11, 12, 14));
            box.Add(factory.CutFilmFigure("Circle", 3));
            box.Add(factory.CutFilmFigure("Square", 11));
            box.Add(factory.CutFilmFigure("Rectangle", 1, 4));
            box.Add(factory.CutFilmFigure("Triangle", 12, 13, 15));
            for (int i = 0; i < box.GetCount(); i++)
            {
                perimetrSum += box.GetFigure(i + 1).Perimeter;
                squareSum += box.GetFigure(i + 1).SquareFigure;
            }
            Assert.AreEqual(perimetrSum, box.PerimeterSum());
            Assert.AreEqual(squareSum, box.SquareSum());
        }

        /// <summary>
        /// Test for paint
        /// </summary>
        [TestMethod]
        public void PaintTest()
        {
            Box box = new Box();
            Ifigures figure1 = factory.CutPaperFigure("Square", 6);
            ((PaperFigure)figure1).Paint(Color.Red);
            box.Add(figure1);
            Assert.IsTrue(((PaperFigure)box.GetFigure(1)).GetColor() == Color.Red);
        }
    }
}
