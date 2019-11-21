using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Polinom
    {
        private double[] coeff;

        public Polinom(double[] coeff)
        {
            this.coeff = coeff;
        }

        /// <summary>
        /// Сложение многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Polinom operator +(Polinom p1, Polinom p2)
        {
            int count = Math.Max(p1.coeff.Length, p2.coeff.Length);
            var res = new double[count];
            for (int i = 0; i < count; i++)
            {
                double a = 0;
                double b = 0;
                if (i < p1.coeff.Length)
                {
                    a = p1.coeff[i];
                }
                if (i < p2.coeff.Length)
                {
                    b = p2.coeff[i];
                }
                res[i] = a + b;
            }
            return new Polinom(res);
        }

        /// <summary>
        /// Разность многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Polinom operator -(Polinom p1, Polinom p2)
        {
            int count = Math.Max(p1.coeff.Length, p2.coeff.Length);
            var res = new double[count];
            for (int i = 0; i < count; i++)
            {
                double a = 0;
                double b = 0;
                if (i < p1.coeff.Length)
                {
                    a = p1.coeff[i];
                }
                if (i < p2.coeff.Length)
                {
                    b = p2.coeff[i];
                }
                res[i] = a - b;
            }
            return new Polinom(res);
        }

        /// <summary>
        /// Умножение многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Polinom operator *(Polinom p1, Polinom p2)
        {
            int count = p1.coeff.Length + p2.coeff.Length - 1;
            var res = new double[count];
            for (int i = 0; i < p1.coeff.Length; i++)
            {
                for (int j = 0; j < p2.coeff.Length; j++)
                {
                    res[i + j] += p1.coeff[i] * p2.coeff[j];
                }
            }
            return new Polinom(res);
        }

        /// <summary>
        /// Сравнение многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True если многочлены равны</returns>
        public static bool operator ==(Polinom p1, Polinom p2)
        {
            if (p1.coeff.Length != p2.coeff.Length)
                return false;

            for (int i = 0; i < p1.coeff.Length; i++)
            {
                if (Math.Abs(p1.coeff[i] - p1.coeff[i]) > 0.001)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Сравнение многочленов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True если многочлены не равны</returns>
        public static bool operator !=(Polinom p1, Polinom p2)
        {
            return !(p1 == p2);
        }
    }
}
