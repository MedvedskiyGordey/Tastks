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
            DateTime date = new DateTime(2019, 12, 24);
            Student student = new Student("Oleg", "Math", 6, date);
            Assert.IsTrue(student.Name == "Oleg" && student.TestName == "Math" && student.Mark == 6 &&
                student.DateTest == date);
        }

        /// <summary>
        /// Create node
        /// </summary>
        [TestMethod()]
        public void CreateNode()
        {
            Node<Student> node = new Node<Student>();
            DateTime date = new DateTime(2019, 12, 24);
            Student student = new Student("Oleg", "Math", 6, date);
            node.Data = student;
            Assert.IsTrue(student.Name == "Oleg" && student.TestName == "Math" && student.Mark == 6 &&
                student.DateTest == date && node.Data.Mark == 6);
        }

        /// <summary>
        /// Match parameters
        /// </summary>
        [TestMethod]
        public void MatchParameters()
        {
            BinaryTree<Student> binaryTree = new BinaryTree<Student>();
            DateTime date = new DateTime(2019, 12, 24);
            Student student = new Student("Oleg", "Math", 6, date);
            binaryTree.Add(student);
            Node<Student> assertNode = binaryTree.Find(student);
            Assert.AreEqual(assertNode.Data, student);
        }

        /// <summary>
        /// Match parameters
        /// </summary>
        [TestMethod]
        public void BalanceTree()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();

            binaryTree.Add(4);
            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(3);
            binaryTree.Add(5);
            binaryTree.Add(6);

            binaryTree.BalanceTree();

            var assertNode1 = binaryTree.Find(4);
            var assertNode2 = binaryTree.Find(1);
            var assertNode3 = binaryTree.Find(2);
            var assertNode4 = binaryTree.Find(3);
            var assertNode5 = binaryTree.Find(5);
            var assertNode6 = binaryTree.Find(6);

            Assert.IsTrue(assertNode1.ParentBranch == null &&
                          assertNode1.LeftBranch == assertNode3 && assertNode1.RightBranch == assertNode6 &&
                          assertNode3.LeftBranch == assertNode2 && assertNode3.RightBranch == assertNode4 &&
                          assertNode6.LeftBranch == assertNode5 &&
                          assertNode1.Data == 4 && assertNode2.Data == 1 &&
                          assertNode3.Data == 2 && assertNode4.Data == 3 &&
                          assertNode5.Data == 5 && assertNode6.Data == 6);
        }

        [TestMethod()]
        public void Serialization()
        {
            BinaryTree<Student> binaryTree = new BinaryTree<Student>();
            DateTime date = new DateTime(2019, 12, 24);
            Student student1 = new Student("Oleg", "Math", 1, date);
            Student student2 = new Student("Michael", "English", 2, date);
            Student student3 = new Student("John", "Biology", 3, date);
            Student student4 = new Student("Vasiliy", "Math", 4, date);
            Student student5 = new Student("Vladislav", "English", 5, date);
            Student student6 = new Student("Valeriy", "Biology", 6, date);

            binaryTree.Add(student1);
            binaryTree.Add(student2);
            binaryTree.Add(student3);
            binaryTree.Add(student4);
            binaryTree.Add(student5);
            binaryTree.Add(student6);

            var settings = new XmlWriterSettings { Indent = true };
            var writer = XmlWriter.Create("..\\..\\..\\BinaryTree.xml", settings);
            DataContractSerializer ser = new DataContractSerializer(typeof(BinaryTree<Student>));
            ser.WriteObject(writer, binaryTree);
            writer.Close();
        }

        [TestMethod()]
        public void Deserialization()
        {
            DateTime date = new DateTime(2019, 12, 24);
            Student student1 = new Student("Oleg", "Math", 1, date);
            Student student2 = new Student("Michael", "English", 2, date);
            Student student3 = new Student("John", "Biology", 3, date);
            Student student4 = new Student("Vasiliy", "Math", 4, date);
            Student student5 = new Student("Vladislav", "English", 5, date);
            Student student6 = new Student("Valeriy", "Biology", 6, date);

            FileStream fileStream = new FileStream("..\\..\\..\\BinaryTree.xml", FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
            DataContractSerializer deserializer = new DataContractSerializer(typeof(BinaryTree<Student>));
            BinaryTree<Student> deserializedTree = (BinaryTree<Student>)deserializer.ReadObject(reader, true);
            reader.Close();
            fileStream.Close();

            var assertNode1 = deserializedTree.Find(student1);
            var assertNode2 = deserializedTree.Find(student2);
            var assertNode3 = deserializedTree.Find(student3);
            var assertNode4 = deserializedTree.Find(student4);
            var assertNode5 = deserializedTree.Find(student5);
            var assertNode6 = deserializedTree.Find(student6);

            Assert.IsTrue(assertNode1.Data.Name == "Oleg" && assertNode2.Data.Name == "Michael" &&
                          assertNode3.Data.Name == "John" && assertNode4.Data.Name == "Vasiliy" &&
                          assertNode5.Data.Name == "Vladislav" && assertNode6.Data.Name == "Valeriy" &&
                          assertNode1.Data.Mark == 1 && assertNode2.Data.Mark == 2 &&
                          assertNode3.Data.Mark == 3 && assertNode4.Data.Mark == 4 &&
                          assertNode5.Data.Mark == 5 && assertNode6.Data.Mark == 6 &&
                          assertNode1.Data.TestName == "Math" && assertNode2.Data.TestName == "English" &&
                          assertNode3.Data.TestName == "Biology" && assertNode4.Data.TestName == "Math" &&
                          assertNode5.Data.TestName == "English" && assertNode6.Data.TestName == "Biology");
        }
    }
}
