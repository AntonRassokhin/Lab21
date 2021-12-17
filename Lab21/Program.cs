using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21
{
    class Program
    {
        private static int[,] garden = new int[10, 10];
        static object locker = new object();

        private static void Main(string[] args)
        {            


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    garden[i,j]= 0;
                }
            }

            ThreadStart threadStart = new ThreadStart(Gardener2);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Gardener1();

            Console.ReadKey(); //ждем пока садовники отработают

            for (int i = 0; i < 10; i++) //для проверки результата
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("{0,5}", garden[i, j]);                    
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static void Gardener1()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (garden[i,j] == 0)
                    garden[i, j] = 1;
                    Console.Write("{0,5}", garden[i, j]);
                }
                Console.WriteLine();
            }
        }
        private static void Gardener2()
        {
            lock (locker)
            {
                for (int j = 9; j > -1; j--)
                {
                    for (int i = 9; i > -1; i--)
                    {
                        if (garden[i, j] == 0)
                            garden[i, j] = 2;
                        Console.Write("{0,5}", garden[i, j]);                        
                    }
                    Console.WriteLine();
                }
            }            
        }
    }
}
