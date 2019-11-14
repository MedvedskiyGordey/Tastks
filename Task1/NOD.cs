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
            int nod;

            while ((number1 != 0) && (number2 != 0))
            {
                if (number1 > number2)
                    number1 -= number2;
                else
                    number2 -= number1;
            }

            nod = Math.Max(number1, number2);

            return nod;
        }

        /// <summary>
        /// Алгоритм Евклида(2 числа)
        /// </summary>
        /// <param name="number1">первое число</param>
        /// <param name="number2">второе число</param>
        /// <param name="time">Время на выполнение метода</param>
        /// <returns></returns>
        public static int EuclidAlg(int number1, int number2, out double time)
        {
            Stopwatch swatch = new Stopwatch();

            swatch.Start();

            int nod = EuclidAlg(number1, number2);

            swatch.Stop();
            time = swatch.Elapsed.TotalMilliseconds;

            return nod;
        }

        /// <summary>
        /// Алгоритм Евклида(3 числа)
        /// </summary>
        /// <param name="number1">первое число</param>
        /// <param name="number2">второе число</param>
        /// <param name="number3">третье число</param>
        /// <returns></returns>
        public static int EuclidAlg(int number1, int number2, int number3)
        {
            int[] array = { number1, number2, number3 };

            int nod = EuclidAlg(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
                nod = EuclidAlg(nod, array[i]);

            return nod;
        }

        /// <summary>
        /// Алгоритм Евклида(4 числа)
        /// </summary>
        /// <param name="number1">первое число</param>
        /// <param name="number2">второе число</param>
        /// <param name="number3">третье число</param>
        /// <param name="number4">четвертое число</param>
        /// <returns></returns>
        public static int EuclidAlg(int number1, int number2, int number3, int number4)
        {
            int[] array = { number1, number2, number3, number4 };

            int nod = EuclidAlg(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
                nod = EuclidAlg(nod, array[i]);

            return nod;
        }

        /// <summary>
        /// Алгоритм Евклида(5 чисел)
        /// </summary>
        /// <param name="number1">первое число</param>
        /// <param name="number2">второе число</param>
        /// <param name="number3">третье число</param>
        /// <param name="number4">четвертое число</param>
        /// <param name="number5">пятое число</param>
        /// <returns></returns>
        public static int EuclidAlg(int number1, int number2, int number3, int number4, int number5)
        {
            int[] array = { number1, number2, number3, number4, number5 };

            int nod = EuclidAlg(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
                nod = EuclidAlg(nod, array[i]);

            return nod;
        }

        /// <summary>
        /// Бинарный алгоритм Евклида
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
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

        /// <summary>
        /// Бинарный алгоритм Евклида
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="time">Время выполнения</param>
        /// <returns></returns>
        public static int BinaryEuclid(int number1, int number2, out double time)
        {
            Stopwatch swatch = new Stopwatch();

            swatch.Start();

            if (number1 == number2 || number1 == 0)
            {
                swatch.Stop();
                time = swatch.Elapsed.TotalMilliseconds;
                return number2;
            }

            if (number2 == 0)
            {
                swatch.Stop();
                time = swatch.Elapsed.TotalMilliseconds;
                return number1;
            }

            if ((number1 & 1) == 0)
            {
                swatch.Stop();
                time = swatch.Elapsed.TotalMilliseconds;
                return (number2 & 1) == 1
                    ? BinaryEuclid(number1 >> 1, number2)
                    : BinaryEuclid(number1 >> 1, number2 >> 1) << 1;
            }
            else if ((number2 & 1) == 0)
            {
                swatch.Stop();
                time = swatch.Elapsed.TotalMilliseconds;
                return BinaryEuclid(number1, number2 >> 1);
            }
            else
            {
                swatch.Stop();
                time = swatch.Elapsed.TotalMilliseconds;
                return number1 > number2
                    ? BinaryEuclid((number1 - number2) >> 1, number2)
                    : BinaryEuclid((number2 - number1) >> 1, number1);
            }
        }

        /// <summary>
        /// Метод подготовки данных для гистограммы
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="number3"></param>
        /// <param name="number4"></param>
        /// <param name="number5"></param>
        /// <returns></returns>
        public static Dictionary<string, double> Histogram(int number1, int number2, int number3, int number4, int number5)
        {
            Dictionary<string, double> methodsTime = new Dictionary<string, double>();

            Stopwatch swatch = new Stopwatch();
            double time;

            EuclidAlg(number1, number2, out time);
            methodsTime.Add("Euclidean algorithm(2 numbers)", time);

            BinaryEuclid(number1, number2, out time);
            methodsTime.Add("Stein's algorithm", time);

            swatch.Start();
            EuclidAlg(number1, number2, number3);
            swatch.Stop();
            time = swatch.Elapsed.TotalMilliseconds;
            methodsTime.Add("Euclidean algorithm(3 numbers)", time);

            swatch.Start();
            EuclidAlg(number1, number2, number3, number4);
            swatch.Stop();
            time = swatch.Elapsed.TotalMilliseconds;
            methodsTime.Add("Euclidean algorithm(4 numbers)", time);

            swatch.Start();
            EuclidAlg(number1, number2, number3, number4, number5);
            swatch.Stop();
            time = swatch.Elapsed.TotalMilliseconds;
            methodsTime.Add("Euclidean algorithm(5 numbers)", time);

            return methodsTime;
        }
    }
}
