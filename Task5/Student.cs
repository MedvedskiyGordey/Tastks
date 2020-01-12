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
    public class Student
    {
        private string surName;

        private string firstName;

        [DataMember]
        public List<TestResults> Tests { get; private set; }


        public Student(string surName, string firstName)
        {
            SurName = surName;
            FirstName = firstName;
            Tests = new List<TestResults>();
        }

        /// <summary>
        /// Student surname
        /// </summary>
        [DataMember]
        public string SurName
        {
            get
            {
                return surName;
            }
            private set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("The surname is entered incorrectly.");
                }
                else
                {
                    surName = value;
                }
            }
        }

        /// <summary>
        /// Student firstname
        /// </summary>
        [DataMember]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("The firstname is entered incorrectly.");
                }
                else
                {
                    firstName = value;
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   surName == student.surName &&
                   firstName == student.firstName &&
                   Tests == student.Tests;
        }

        public override int GetHashCode()
        {
            int hashCode = surName.GetHashCode() * firstName.GetHashCode() * 564054;

            return hashCode;
        }
    }
}
