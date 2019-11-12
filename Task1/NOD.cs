using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class NOD
    {
        public int number1, number2;

        public NOD(int number1, int number2)
        {
            this.number1 = number1;
            this.number2 = number2;
        }

        public int EuclidAlg(int number1, int number2)
        {
            while ((number1 != 0) && (number2 != 0))
            {
                if (number1 > number2)
                    number1 -= number2;
                else
                    number2 -= number1;
            }

            return Math.Max(number1, number2);
        }
    }
}
