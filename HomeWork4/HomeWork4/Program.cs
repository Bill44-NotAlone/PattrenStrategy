using Lib1;
using System;
using System.Collections.Generic;

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        { 
            List<double> number1 = new List<double>() {};
            Console.WriteLine("Тест 1");
            for(int i = 0; i < number1.Count; i++)
                Console.WriteLine(Class1.Pus(number1)[i]);

            List<double> number2 = new List<double>() {1, 2};
            Console.WriteLine("Тест 2");
            for (int i = 0; i < number2.Count; i++)
                Console.WriteLine(Class1.Pus(number2)[i]);

            List<double> number3 = new List<double>() {1,2,3,-4};
            Console.WriteLine("Тест 3");
            for (int i = 0; i < number3.Count; i++)
                Console.WriteLine(Class1.Pus(number3)[i]);

            List<double> number4 = new List<double>() {2,1,4,3};
            Console.WriteLine("Тест 4");
            for (int i = 0; i < number4.Count; i++)
                Console.WriteLine(Class1.Pus(number4)[i]);

            List<double> number5 = new List<double>() {7,2,1,7,3,6,7};
            Console.WriteLine("Тест 5");
            for (int i = 0; i < number5.Count; i++)
                Console.WriteLine(Class1.Pus(number5)[i]);

            List<double> number6 = new List<double>() { -1,1};
            Console.WriteLine("Тест 6");
            for (int i = 0; i < number6.Count; i++)
                Console.WriteLine(Class1.Pus(number6)[i]);
        }
    }
}
