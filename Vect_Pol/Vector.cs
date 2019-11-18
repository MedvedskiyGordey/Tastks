using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Vector
    {
        private int x;
        private int y;
        private int z;

        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.x + vector2.x, vector1.y + vector2.y, vector1.z + vector2.z);
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.x - vector2.x, vector1.y - vector2.y, vector1.z - vector2.z);
        }

        public static int operator *(Vector vector1, Vector vector2)
        {
            return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
        }

        public static Vector operator /(Vector vector1, Vector vector2)
        {
            int[] Vec = new int[3];
            Vec[0] = vector1.y * vector2.z - vector1.z * vector2.y;
            Vec[1] = vector1.z * vector2.x - vector1.x * vector2.z;
            Vec[2] = vector1.x * vector2.y - vector1.y * vector2.x;
            return new Vector(Vec[0], Vec[1], Vec[2]);
        }
    }
}
