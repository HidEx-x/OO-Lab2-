using System;
using System.Threading;

namespace ConsoleApp2
{
    static class Rand
    {
        public static Random rnd = new Random();
    }

    class Program
    {
        static void Main(string[] args)
        {
            int size;
            bool rand;
            bool threads;

            Console.Write("Enter n: ");
            while (true)
            {
                try
                {
                    size = int.Parse(Console.ReadLine());
                    if (size <= 1) throw new FormatException();
                    break;
                }
                catch (FormatException) { Console.WriteLine("Wrong input. Try again.\nEnter n:"); }
            }

            Console.WriteLine("Random?");
            Console.WriteLine("1 - Yes, 2 - No");
            while (true)
            {
                try
                {
                    int r = int.Parse(Console.ReadLine());
                    switch (r)
                    {
                        case 1:
                            rand = true;
                            break;
                        case 2:
                            rand = false;
                            break;
                        default:
                            throw new FormatException();
                    }
                    break;
                }
                catch (FormatException) { Console.WriteLine("Wrong input. Try again."); }
            }

            Console.WriteLine("Threads?");
            Console.WriteLine("1 - Yes, 2 - No");
            while (true)
            {
                try
                {
                    int r = int.Parse(Console.ReadLine());
                    switch (r)
                    {
                        case 1:
                            threads = true;
                            break;
                        case 2:
                            threads = false;
                            break;
                        default:
                            throw new FormatException();
                    }
                    break;
                }
                catch (FormatException) { Console.WriteLine("Wrong input. Try again."); }
            }

            DateTime start = DateTime.Now;
            ExprCalc E = new ExprCalc(size, rand);
            if (threads)
            {
                Thread thread_A = new Thread(() => E.Create_A());
                Thread thread_b = new Thread(() => E.Calc_b());
                Thread thread_A1 = new Thread(() => E.Create_A1());
                Thread thread_b1 = new Thread(() => E.Create_b1());
                Thread thread_c1 = new Thread(() => E.Create_c1());
                Thread thread_A2 = new Thread(() => E.Create_A2());
                Thread thread_B2 = new Thread(() => E.Create_B2());
                Thread thread_C2 = new Thread(() => E.Calc_C2());
                Thread thread_y1 = new Thread(() => E.Calc_y1());
                Thread thread_y2 = new Thread(() => E.Calc_y2());
                Thread thread_Y3 = new Thread(() => E.Calc_Y3());

                Thread thread_step11 = new Thread(() => E.Step11());
                Thread thread_step12 = new Thread(() => E.Step12());
                Thread thread_step13 = new Thread(() => E.Step13());
                Thread thread_step14 = new Thread(() => E.Step14());
                Thread thread_step21 = new Thread(() => E.Step21());
                Thread thread_step22 = new Thread(() => E.Step22());
                Thread thread_step23 = new Thread(() => E.Step23());
                Thread thread_step31 = new Thread(() => E.Step31());
                Thread thread_step32 = new Thread(() => E.Step32());
                Thread thread_step41 = new Thread(() => E.Step41());
                Thread thread_step42 = new Thread(() => E.Step42());
                Thread thread_step51 = new Thread(() => E.Step51());
                Thread thread_X = new Thread(() => E.Last_Step());


                if (!rand)
                {
                    E.Create_A();
                    E.Calc_b();
                    E.Calc_y1();

                    E.Create_A1();
                    E.Create_b1();
                    E.Create_c1();
                    E.Calc_y2();

                    E.Create_A2();
                    E.Create_B2();
                    E.Calc_C2();
                    E.Calc_Y3();
                }
                else
                {
                    thread_A.Start();
                    thread_b.Start();
                    thread_A.Join();
                    thread_b.Join();

                    thread_y1.Start();
                    thread_A1.Start();
                    thread_b1.Start();
                    thread_c1.Start();
                    thread_A1.Join();
                    thread_b1.Join();
                    thread_c1.Join();

                    thread_y2.Start();
                    thread_A2.Start();
                    thread_B2.Start();
                    thread_C2.Start();
                    thread_A2.Join();
                    thread_B2.Join();
                    thread_C2.Join();

                    thread_Y3.Start();
                    thread_y1.Join();
                    thread_y2.Join();
                    thread_Y3.Join();
                }

                thread_step11.Start();
                thread_step12.Start();
                thread_step13.Start();
                thread_step14.Start();
                thread_step11.Join();
                thread_step12.Join();
                thread_step13.Join();
                thread_step14.Join();

                thread_step21.Start();
                thread_step22.Start();
                thread_step23.Start();
                thread_step21.Join();
                thread_step22.Join();
                thread_step23.Join();

                thread_step31.Start();
                thread_step32.Start();
                thread_step31.Join();
                thread_step32.Join();

                thread_step41.Start();
                thread_step42.Start();
                thread_step41.Join();
                thread_step42.Join();

                thread_step51.Start();
                thread_step51.Join();

                thread_X.Start();
                thread_X.Join();
            }
            else
            {
                E.Create_A();
                E.Calc_b();
                E.Calc_y1();

                E.Create_A1();
                E.Create_b1();
                E.Create_c1();
                E.Calc_y2();

                E.Create_A2();
                E.Create_B2();
                E.Calc_C2();
                E.Calc_Y3();

                E.Step11();
                E.Step12();
                E.Step13();
                E.Step14();
                E.Step21();
                E.Step22();
                E.Step23();
                E.Step31();
                E.Step32();
                E.Step41();
                E.Step42();
                E.Step51();
                E.Last_Step();
            }
            DateTime end = DateTime.Now;

            Console.WriteLine("Matrix A:\n" + E.A);
            Console.WriteLine("Vector b:\n" + E.b);
            Console.WriteLine("Vector y1 = A * b:\n" + E.y1);
            Console.WriteLine();
            Console.WriteLine("Matrix A1:\n" + E.A1);
            Console.WriteLine("Vector b1:\n" + E.b1);
            Console.WriteLine("Vector c1:\n" + E.c1);
            Console.WriteLine("Vector y2 = A1 * (12 * b1 - c1):\n" + E.y2);
            Console.WriteLine();
            Console.WriteLine("Matrix A2:\n" + E.A2);
            Console.WriteLine("Matrix B2:\n" + E.B2);
            Console.WriteLine("Matrix C2:\n" + E.C2);
            Console.WriteLine("Matrix Y3 = A2 * (B2 - C2):\n" + E.Y3);

            Console.WriteLine("Step11:\n" + E.step11);
            Console.WriteLine("Step12:\n" + E.step12);
            Console.WriteLine("Step13:\n" + E.step13);
            Console.WriteLine("Step14:\n" + E.step14);
            Console.WriteLine("Step21:\n" + E.step21);
            Console.WriteLine("Step22:\n" + E.step22);
            Console.WriteLine("Step23:\n" + E.step23);
            Console.WriteLine("Step31:\n" + E.step31);
            Console.WriteLine("Step32:\n" + E.step32);
            Console.WriteLine("Step41:\n" + E.step41);
            Console.WriteLine("Step42:\n" + E.step42);
            Console.WriteLine("Step51:\n" + E.step51);

            Console.WriteLine("Final step:\n" + E.X);
            Console.WriteLine(end - start);

        }

    }



}
