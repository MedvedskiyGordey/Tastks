using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task1
{
    public class NOD
    {
        /// <summary>
        /// Алгоритм Евклида(2 числа)
        /// </summary>
        /// <param name="number1">первое число</param>
        /// <param name="number2">второе число</param>
        /// <returns></returns>
        public static int EuclidAlg(int number1, int number2)
        {
            Stopwatch swatch = new Stopwatch();

            swatch.Start();

            int nod;

            while ((number1 != 0) && (number2 != 0))
            {
                if (number1 > number2)
                    number1 -= number2;
                else
                    number2 -= number1;
            }

            nod = Math.Max(number1, number2);

            swatch.Stop();
            TimeSpan time = swatch.Elapsed;

            return nod;
        }

        //public static int EuclidAlg(int number1, int number2, int number3)
        //{
        //    int nod = Math.Min(number1, Math.Min(number2, number3));
        //    bool end = true;
        //    while (nod > 1 || end == false)
        //    {
        //        if (number1 % nod == 0 && number2 % nod == 0 && number3 % nod == 0) end = false;
        //        nod--;
        //    }
        //    return nod;
        //}

        public static int EuclidAlg(int[] array)
        {
            int nod = EuclidAlg(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
                nod = EuclidAlg(nod, array[i]);

            return nod;
        }

        /// <summary>
        /// Бинарный алгоритм Евклида
        /// </summary>
        /// <param name="number1">первое число</param>
        /// <param name="number2">второе число</param>
        /// <returns></returns>
        public static int BinaryEuclid(int number1, int number2)
        {
            if (number1 == number2 || number1 == 0)
                return number2;

            if (number2 == 0)
                return number1;

            if ((number1 & 1) == 0)
            {
                return (number2 & 1) == 1
                    ? BinaryEuclid(number1 >> 1, number2)
                    : BinaryEuclid(number1 >> 1, number2 >> 1) << 1;
            }
            else if ((number2 & 1) == 0)
            {
                return BinaryEuclid(number1, number2 >> 1);
            }
            else
            {
                return number1 > number2
                    ? BinaryEuclid((number1 - number2) >> 1, number2)
                    : BinaryEuclid((number2 - number1) >> 1, number1);
            }
        }
    }
}
