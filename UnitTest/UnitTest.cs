using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using Task5;
using System.Runtime.Serialization;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Create student
        /// </summary>
        [TestMethod()]
        public void CreateStudent()
        {
            Student student = new Student("Ivanov", "Oleg");
            Assert.IsTrue(student.SurName == "Ivanov" && student.FirstName == "Oleg");
        }

        /// <summary>
        /// Create test
        /// </summary>
        [TestMethod()]
        public void CreateTest()
        {
            Test test = new Test("English");

            Assert.IsTrue(test.TestName == "English");
        }

        /// <summary>
        /// Create test results
        /// </summary>
        [TestMethod()]
        public void CreateTestResults()
        {
            // Arrange
            Student student = new Student("Ivanov", "Oleg");
            Test test = new Test("Math");
            DateTime date = new DateTime(2019, 12, 24);
            TestResults testResult = new TestResults(student, test, 9, date);
            
            int testMark = 9;
            DateTime testDate = new DateTime(2019, 12, 24);

            Assert.IsTrue(testResult.Student.SurName == student.SurName && testResult.Student.FirstName == student.FirstName &&
                testResult.Test.TestName == test.TestName && testResult.Mark == testMark &&
                testResult.TestDate == testDate);
        }

        /// <summary>
        /// Create node
        /// </summary>
        [TestMethod()]
        public void CreateNode()
        {
            Node<TestResults> node = new Node<TestResults>();
            Student student = new Student("Ivanov", "Oleg");
            Test test = new Test("Math");
            DateTime date = new DateTime(2019, 12, 24);
            TestResults studentResult = new TestResults(student, test, 9, date);
            node.Data = studentResult;
            Assert.IsTrue(student.SurName == "Ivanov" && student.FirstName == "Oleg" && node.Data.Test == test &&
                node.Data.TestDate == date && node.Data.Mark == 9);
        }

        [TestMethod()]
        public void Serialization()
        {
            BinaryTree<TestResults> binaryTree = new BinaryTree<TestResults>();
            DateTime date = new DateTime(2019, 12, 24);
            Student student1 = new Student("Ivanov", "Oleg");
            Student student2 = new Student("Loevskiy", "Michael");
            Student student3 = new Student("Petrov", "John");
            Student student4 = new Student("Smith", "Vasiliy");
            Student student5 = new Student("Reznov", "Vladislav");
            Student student6 = new Student("Vopros", "Valeriy");
            Test test1 = new Test("English");
            Test test2 = new Test("Biology");
            Test test3 = new Test("Math");

            TestResults testResults1 = new TestResults(student1, test1, 1, date);
            TestResults testResults2 = new TestResults(student2, test2, 2, date);
            TestResults testResults3 = new TestResults(student3, test3, 3, date);
            TestResults testResults4 = new TestResults(student4, test1, 4, date);
            TestResults testResults5 = new TestResults(student5, test2, 5, date);
            TestResults testResults6 = new TestResults(student6, test3, 6, date);


            TestResults.CompareFunc = (TestResults testOne, TestResults testTwo) =>
            {
                return testOne.Mark.CompareTo(testTwo.Mark);
            };

            binaryTree.Add(testResults1);
            binaryTree.Add(testResults2);
            binaryTree.Add(testResults3);
            binaryTree.Add(testResults4);
            binaryTree.Add(testResults5);
            binaryTree.Add(testResults6);

            var settings = new XmlWriterSettings { Indent = true };
            var writer = XmlWriter.Create("..\\..\\..\\BinaryTree.xml", settings);
            DataContractSerializer ser = new DataContractSerializer(typeof(BinaryTree<TestResults>));
            ser.WriteObject(writer, binaryTree);
            writer.Close();
        }

        [TestMethod()]
        public void Deserialization()
        {
            DateTime date = new DateTime(2019, 12, 24);
            Student student1 = new Student("Ivanov", "Oleg");
            Student student2 = new Student("Loevskiy", "Michael");
            Student student3 = new Student("Petrov", "John");
            Student student4 = new Student("Smith", "Vasiliy");
            Student student5 = new Student("Reznov", "Vladislav");
            Student student6 = new Student("Vopros", "Valeriy");
            Test test1 = new Test("English");
            Test test2 = new Test("Biology");
            Test test3 = new Test("Math");

            TestResults testResults1 = new TestResults(student1, test1, 1, date);
            TestResults testResults2 = new TestResults(student1, test2, 2, date);
            TestResults testResults3 = new TestResults(student1, test3, 3, date);
            TestResults testResults4 = new TestResults(student1, test1, 4, date);
            TestResults testResults5 = new TestResults(student1, test2, 5, date);
            TestResults testResults6 = new TestResults(student1, test3, 6, date);

            TestResults.CompareFunc = (TestResults testOne, TestResults testTwo) =>
            {
                return testOne.Mark.CompareTo(testTwo.Mark);
            };

            FileStream fileStream = new FileStream("..\\..\\..\\BinaryTree.xml", FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
            DataContractSerializer deserializer = new DataContractSerializer(typeof(BinaryTree<TestResults>));
            BinaryTree<TestResults> deserializedTree = (BinaryTree<TestResults>)deserializer.ReadObject(reader, true);
            reader.Close();
            fileStream.Close();

            var testNode1 = deserializedTree.Find(testResults1);
            var testNode2 = deserializedTree.Find(testResults2);
            var testNode3 = deserializedTree.Find(testResults3);
            var testNode4 = deserializedTree.Find(testResults4);
            var testNode5 = deserializedTree.Find(testResults5);
            var testNode6 = deserializedTree.Find(testResults6);

            Assert.IsTrue(testNode1.Data.Student.SurName == "Ivanov" && 
                          testNode2.Data.Student.SurName == "Loevskiy" &&
                          testNode3.Data.Student.SurName == "Petrov" && 
                          testNode4.Data.Student.SurName == "Smith" &&
                          testNode5.Data.Student.SurName == "Reznov" && 
                          testNode6.Data.Student.SurName == "Vopros");
        }

        /// <summary>
        /// Tree balancing
        /// </summary>
        [TestMethod]
        public void BalanceTree()
        {
            BinaryTree<TestResults> binaryTree = new BinaryTree<TestResults>();
            DateTime date = new DateTime(2019, 12, 24);
            Student student1 = new Student("Ivanov", "Oleg");
            Student student2 = new Student("Loevskiy", "Michael");
            Student student3 = new Student("Petrov", "John");
            Student student4 = new Student("Smith", "Vasiliy");
            Student student5 = new Student("Reznov", "Vladislav");
            Student student6 = new Student("Vopros", "Valeriy");
            Test test1 = new Test("English");
            Test test2 = new Test("Biology");
            Test test3 = new Test("Math");

            TestResults testResults1 = new TestResults(student1, test1, 4, date);
            TestResults testResults2 = new TestResults(student2, test2, 1, date);
            TestResults testResults3 = new TestResults(student3, test3, 2, date);
            TestResults testResults4 = new TestResults(student4, test1, 3, date);
            TestResults testResults5 = new TestResults(student5, test2, 5, date);
            TestResults testResults6 = new TestResults(student6, test3, 6, date);


            TestResults.CompareFunc = (TestResults testOne, TestResults testTwo) =>
            {
                return testOne.Mark.CompareTo(testTwo.Mark);
            };

            binaryTree.Add(testResults1);
            binaryTree.Add(testResults2);
            binaryTree.Add(testResults3);
            binaryTree.Add(testResults4);
            binaryTree.Add(testResults5);
            binaryTree.Add(testResults6);

            binaryTree.BalanceTree();

            var testNode1 = binaryTree.Find(testResults1);
            var testNode2 = binaryTree.Find(testResults2);
            var testNode3 = binaryTree.Find(testResults3);
            var testNode4 = binaryTree.Find(testResults4);
            var testNode5 = binaryTree.Find(testResults5);
            var testNode6 = binaryTree.Find(testResults6);

            Assert.IsTrue(testNode1.ParentBranch == null &&
                          testNode1.LeftBranch == testNode3 && testNode1.RightBranch == testNode6 &&
                          testNode3.LeftBranch == testNode2 && testNode3.RightBranch == testNode4 &&
                          testNode6.LeftBranch == testNode5 &&
                          testNode1.Data.Mark == 4 && testNode2.Data.Mark == 1 &&
                          testNode3.Data.Mark == 2 && testNode4.Data.Mark == 3 &&
                          testNode5.Data.Mark == 5 && testNode6.Data.Mark == 6);
        }
    }
}
