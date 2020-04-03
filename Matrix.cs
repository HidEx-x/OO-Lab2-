using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Matrix
    {
        private int n { get; set; }
        private double[,] arr { get; set; }
        public static string name { get; private set; }
        public string type { get; private set; }

        public string GetName() => name;
        public string GetType() => type;

        //Constructors
        public Matrix() { }
        public Matrix(int n)
        {
            this.n = n;
            arr = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    arr[i, j] = 0;
        }
        public Matrix(int n, string namev, string typev) : this(n)
        {
            name = namev;
            type = typev;
        }

        public Matrix(int n, string namev, string typev, bool rand) : this(n, namev, typev)
        {
            if (rand)
            {
                if (type is "matrix")
                {
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            arr[i, j] = Rand.rnd.Next(0, 10);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            arr[i, j] = j == 0 ? Rand.rnd.Next(0, 10) : 0;
                }
            }
            else
            {
                if (type is "matrix")
                {
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write($"{name}[{i}][{j}] = ");
                            try { arr[i, j] = int.Parse(Console.ReadLine()); }
                            catch { Console.WriteLine("Wrong input. Try again"); j--; }
                        }
                }
                else
                {
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                        {
                            if (j == 0)
                            {
                                Console.Write($"{name}[{i}][{j}] = ");
                                try { arr[i, j] = int.Parse(Console.ReadLine()); }
                                catch { Console.WriteLine("Wrong input. Try again"); j--; }
                            }
                            else
                                arr[i, j] = 0;
                        }
                }

            }
        }
        //indexing overload
        public double this[int i, int j] { get => arr[i, j]; set => arr[i, j] = value; }
        //+ overload
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            string t = m1.type == "matrix" || m2.type == "matrix" ? "matrix" : "vector";
            Matrix result = new Matrix(m1.n, "tmp", t);
            for (int i = 0; i < m1.n; i++)
            {
                for (int j = 0; j < m1.n; j++)
                    result[i, j] = m1[i, j] + m2[i, j];
            }
            return result;
        }
        //-overload
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            string t = m1.type == "matrix" || m2.type == "matrix" ? "matrix" : "vector";
            Matrix result = new Matrix(m1.n, "tmp", t);
            for (int i = 0; i < m1.n; i++)
            {
                for (int j = 0; j < m1.n; j++)
                    result[i, j] = m1[i, j] - m2[i, j];
            }
            return result;
        }
        //*overload
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            bool number = false;
            foreach (double elem in m1.arr)
            {
                if (elem == m1[0, 0]) continue;
                if (elem == 0) number = true;
                else
                {
                    number = false;
                    break;
                }
            }
            if (number) return m1[0, 0] * m2;

            foreach (double elem in m2.arr)
            {
                if (elem == m2[0, 0]) continue;
                if (elem == 0) number = true;
                else
                {
                    number = false;
                    break;
                }
            }
            if (number) return m2[0, 0] * m1;

            string t = m1.type == "matrix" && m2.type == "matrix" || m1.type == "vector" && m2.type == "matrix" ? "matrix" : "vector";
            Matrix result = new Matrix(m1.n, "tmp", t);
            for (int i = 0; i < m1.n; i++)
            {
                for (int j = 0; j < m1.n; j++)
                {
                    for (int k = 0; k < m1.n; k++)
                        result[i, j] += m1[i, k] * m2[k, j];
                }
            }
            return result;
        }
        //*number overload
        public static Matrix operator *(double num, Matrix m)
        {
            string t = m.type == "matrix" ? "matrix" : "vector";
            Matrix result = new Matrix(m.n, "tmp", t);
            for (int i = 0; i < m.n; i++)
            {
                for (int j = 0; j < m.n; j++)
                {
                    result[i, j] = num * m[i, j];
                }
            }
            return result;
        }
        public static Matrix operator *(Matrix m, double num)
        {
            string t = m.type == "matrix" ? "matrix" : "vector";
            Matrix result = new Matrix(m.n, "tmp", t);
            for (int i = 0; i < m.n; i++)
            {
                for (int j = 0; j < m.n; j++)
                {
                    result[i, j] = num * m[i, j];
                }
            }
            return result;
        }
        //transpose
        public static Matrix operator ~(Matrix m)
        {
            Matrix result = new Matrix(m.n, "tmp", "matrix");

            for (int i = 0; i < m.n; i++)
            {
                for (int j = 0; j < m.n; j++)
                {
                    result[i, j] = m[j, i];
                }
            }
            return result;
        }
        //tostring
        public override string ToString()
        {
            string s = "";

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    s += String.Format("{0:0.##}\t", arr[i, j]);
                s += "\n";
            }
            return s;
        }
    }
}
