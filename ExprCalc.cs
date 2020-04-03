using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class ExprCalc
    {
        private int N { get; set; }
        public double K1 { get; private set; }
        public double K2 { get; private set; }
        private bool random { get; set; }
        public Matrix A { get; private set; }
        public Matrix A1 { get; private set; }
        public Matrix A2 { get; private set; }
        public Matrix B2 { get; private set; }
        public Matrix Y3 { get; private set; }
        public Matrix C2 { get; private set; }
        public Matrix y1 { get; private set; }
        public Matrix b { get; private set; }
        public Matrix b1 { get; private set; }
        public Matrix c1 { get; private set; }
        public Matrix y2 { get; private set; }
        public Matrix step11 { get; private set; }
        public Matrix step12 { get; private set; }
        public Matrix step13 { get; private set; }
        public Matrix step14 { get; private set; }
        public Matrix step21 { get; private set; }
        public Matrix step22 { get; private set; }
        public Matrix step23 { get; private set; }
        public Matrix step31 { get; private set; }
        public Matrix step32 { get; private set; }
        public Matrix step41 { get; private set; }
        public Matrix step42 { get; private set; }
        public Matrix step51 { get; private set; }
        public Matrix X { get; private set; }

        public ExprCalc(int n, bool rand)
        {
            N = n;
            random = rand;
            K1 = 0.01 / (N * N);
            K2 = K1;
        }

        public void Create_A() => A = new Matrix(N, nameof(A), "matrix", random);
        public void Create_A1() => A1 = new Matrix(N, nameof(A1), "matrix", random);
        public void Create_b1() => b1 = new Matrix(N, nameof(b1), "vector", random);
        public void Create_c1() => c1 = new Matrix(N, nameof(c1), "vector", random);
        public void Create_A2() => A2 = new Matrix(N, nameof(A2), "matrix", random);
        public void Create_B2() => B2 = new Matrix(N, nameof(B2), "matrix", random);

        public void Calc_b()
        {
            b = new Matrix(N, nameof(b), "vector");
            for (int i = 0; i < N; i++)
                b[i, 0] = 8 / (i + 1);
        }
        public void Calc_y1() => y1 = A * b;
        public void Calc_y2() => y2 = A1 * (2 * b1 + 3 * c1);
        public void Calc_C2()
        {
            C2 = new Matrix(N, nameof(C2), "matrix");
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    C2[i, j] = 1.0 / (i + j + 2.0);

        }
        public void Calc_Y3() => Y3 = A2 * (B2 - C2);

        public void Step11() => step11 = K1 * ~y1 * Y3;
        public void Step12() => step12 = K2 * Y3 * Y3;
        public void Step13() => step13 = K1 * y1 * ~y2;
        public void Step14() => step14 = K2 * ~y2 * Y3;
        public void Step21() => step21 = K1 * step11 * y1;
        public void Step22() => step22 = step12 + step13;
        public void Step23() => step23 = K1 * step14 * y2;
        public void Step31() => step31 = K2 * step21 * y2;
        public void Step32() => step32 = K1 * step23 * y1;
        public void Step41() => step41 = K2 * step31 * ~y2;
        public void Step42() => step42 = step32 + y1;
        public void Step51() => step51 = step41 + step22;
        public void Last_Step() => X = K1 * step51 * step42;


    }
}
