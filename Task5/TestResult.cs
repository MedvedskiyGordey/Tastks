using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task5
{
    public delegate int Compare(TestResults test1, TestResults test2);


    [DataContract(IsReference = true)]
    /// <summary>
    /// Test result class
    /// </summary>
    public class TestResults : IComparable
    {
        public static Compare CompareFunc;

        private int mark;

        [DataMember]
        public Student Student { get; private set; }

        [DataMember]
        public Test Test { get; private set; }

        [DataMember]
        public DateTime TestDate { get; private set; }

        public TestResults(Student student, Test test, int mark, DateTime testDate)
        {
            Student = student;
            Test = test;
            Mark = mark;
            TestDate = testDate;
            student.Tests.Add(this);
        }

        [DataMember]
        public int Mark
        {
            get
            {
                return mark;
            }
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Student grade must be between 1 and 10.");
                }
                else
                {
                    mark = value;
                }
            }
        }

        public virtual int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var other = obj as TestResults;

            if (other == null) throw new ArgumentException("It is not TestResult.");

            if (CompareFunc == null)
            {
                throw new NullReferenceException("It is necessary to determine the method of comparison. " +
                    "The delegate does not contain a reference to the method.");
            }

            return CompareFunc(this, other);
        }


        public override bool Equals(object obj)
        {
            return obj is TestResults testResults &&
                   Student == testResults.Student &&
                   Test == testResults.Test &&
                   mark == testResults.Mark &&
                   TestDate == testResults.TestDate;
        }

        public override int GetHashCode()
        {
            int hashCode = Student.GetHashCode() * Test.GetHashCode() + mark.GetHashCode() * TestDate.GetHashCode() * 564054;

            return hashCode;
        }
    }
}
