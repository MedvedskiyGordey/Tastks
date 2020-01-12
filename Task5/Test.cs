using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task5
{
    [DataContract(IsReference = true)]
    /// <summary>
    /// Test class
    /// </summary>
    public class Test
    {
        private string testName;

        [DataMember]
        public string TestName
        {
            get
            {
                return testName;
            }
            private set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("The testname is entered incorrectly.");
                }
                else
                {
                    testName = value;
                }
            }
        }
        public Test(string testName)
        {
            TestName = testName;
        }

        public override bool Equals(object obj)
        {
            return obj is Test test &&
                   testName == test.testName;
        }

        public override int GetHashCode()
        {
            int hashCode = testName.GetHashCode() + testName.GetHashCode() * 564054 + 312;

            return hashCode;
        }
    }
}
