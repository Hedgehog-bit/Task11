using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание11
{
    class Program
    {
        static void Main()
        {
            Mass mass = new Mass(2,2);
            Console.WriteLine("Введите значение массива");
            mass.Unput();
            Console.WriteLine("Вывод массива");
            mass.Output();
            mass.Sort();
            Console.WriteLine("Общие кол-во элементов в массиве " + mass.Quantity);
            Console.Write("Введите скаляр:");
            mass.Scalar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение массива");
            mass.Unput();
            Console.WriteLine("Вывод массива");
            mass.Output();



            Console.ReadKey();
        }
    }
    class Mass
    {
        double[,] DoubelArray;
        int n, m;
        int quantity;
        public int Quantity
        {
            get { return quantity; }
        }
        int scalar = 0;
        public int Scalar
        {
            set { scalar = value; }
        }

        public Mass(int n, int m)
        {
            DoubelArray = new double[n, m];
            this.n = n;
            this.m = m;
            this.quantity = n * m;
        }
        public void Unput()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    DoubelArray[i, j] = Convert.ToDouble(Console.ReadLine()) + scalar;
                }
            }
        }
        public void Output()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(DoubelArray[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void Sort()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < m; j++) 
                {
                    for (int r = 0; r < m - j; r++) 
                    {
                        if (DoubelArray[i, r] < DoubelArray[i, r + 1])
                        {
                            double tmp = DoubelArray[i, r];
                            DoubelArray[i, r] = DoubelArray[i, r + 1];
                            DoubelArray[i, r + 1] = tmp;
                        }
                    }
                }
            }
        }
    }
}
