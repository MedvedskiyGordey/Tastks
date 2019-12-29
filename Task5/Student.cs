using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task5
{
   
    /// <summary>
    /// Student class
    /// </summary>
    [DataContract(IsReference = true)]
    public class Student : IComparable
    {
        private string name;

        private string testName;

        private double mark;

        /// <summary>
        /// Student name
        /// </summary>
        [DataMember]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("The name is entered incorrectly.");
                }
                else
                {
                    name = value;
                }
            }
        }

        /// <summary>
        /// Test name
        /// </summary>
        [DataMember]
        public string TestName
        {
            get
            {
                return testName;
            }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("The test name is entered incorrectly.");
                }
                else
                {
                    testName = value;
                }
            }
        }

        /// <summary>
        /// Test date
        /// </summary>
        [DataMember]
        public DateTime DateTest { get; set; }

        /// <summary>
        /// Test score
        /// </summary>
        [DataMember]
        public double Mark
        {
            get
            {
                return mark;
            }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("The value must be between 1 and 10.");
                }
                else
                {
                    mark = value;
                }
            }
        }

        public Student(string name, string testName, int mark, DateTime testDate)
        {
            Name = name;
            TestName = testName;
            Mark = mark;
            DateTest = testDate;
        }

        /// <summary>
        /// Student comparison
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual int CompareTo(object obj)
        {
            Student student = obj as Student;

            if (student != null) return Mark.CompareTo(student.Mark);

            else throw new Exception("Students cannot be compared.");
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   name == student.name &&
                   testName == student.testName &&
                   Name == student.Name &&
                   mark == student.mark &&
                   TestName == student.TestName &&
                   DateTest == student.DateTest &&
                   Mark == student.Mark;
        }
        public override int GetHashCode()
        {
            int hashCode = Name.GetHashCode() * TestName.GetHashCode() * Mark.GetHashCode() * 564054;

            return hashCode;
        }
    }
}
