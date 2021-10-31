using System;
using System.Collections.Generic;
using System.Linq;

namespace Домашняя_работа_от_28._09._2021
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(new IncorrectFractions(2).GetFraction());
            Console.WriteLine(new IncorrectFractions(2, 3).GetFraction());
            Console.WriteLine(new IncorrectFractions(2, 3, 6).GetFraction());
            Console.WriteLine((new IncorrectFractions(5, 5) / new IncorrectFractions(6, 4)).GetFraction());
            Console.WriteLine((new IncorrectFractions(5, 5) + new IncorrectFractions(6, 4)).GetFraction());
            Console.WriteLine((new IncorrectFractions(5, 5) - new IncorrectFractions(6, 4)).GetFraction());
            Console.WriteLine((new IncorrectFractions(5, 5) * new IncorrectFractions(6, 4)).GetFraction());


            IncorrectFractions incorrectFractions = new IncorrectFractions(-3, 4);

            incorrectFractions.RepFanN += RepfanConsoleN;
            incorrectFractions.RepFanD += RepfanConsoleD;

            Console.WriteLine(incorrectFractions.ConvertingFractionsToDecimal());
            Console.WriteLine(incorrectFractions.GetADrSign());
            incorrectFractions.NewNumerator(7);
            incorrectFractions.NewDenominator(8);
            Console.WriteLine(incorrectFractions.GetFraction());
            Console.WriteLine(incorrectFractions.GetTheIndexOfTheNumeratorAndDenominator(incorrectFractions, 0));
        }
        public static void RepfanConsoleN(IncorrectFractions incorrectFractions, double int2)
        {
            Console.WriteLine($"Числитель {incorrectFractions.GetNumerator()} будет числом {int2}");
        }
        public static void RepfanConsoleD(IncorrectFractions incorrectFractions, double int2)
        {
            Console.WriteLine($"Знаменатель {incorrectFractions.GetDenominator()} будет числом {int2}");
        }
    }

    public class IncorrectFractions
    {
        public delegate void matod(IncorrectFractions tish, double int1);
        public event matod RepFanD;
        public event matod RepFanN;
        private double numerator;
        private double denominator;

        //Ктрукторы
        public IncorrectFractions(double numerator)
        {
            this.numerator = numerator;
            this.denominator = 1;
        }
        public IncorrectFractions(double numerator, double denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
        public IncorrectFractions(double integer, double numerator, double denominator)
        {
            this.numerator = integer * denominator + numerator;
            this.denominator = denominator;
        }

        //Задание 1
        public double ConvertingFractionsToDecimal()
        {
            return (this.numerator / this.denominator);
        }

        //Задание 2
        public static IncorrectFractions operator +(IncorrectFractions incorrectFractions1, IncorrectFractions incorrectFractions2)
        {
            if (incorrectFractions1.denominator == incorrectFractions2.denominator)
            {
                double commonNumerator = incorrectFractions1.numerator + incorrectFractions2.numerator;
                double commonDenominator = incorrectFractions1.denominator;
                return (new IncorrectFractions(commonNumerator, commonDenominator));
            }
            else
            {
                IncorrectFractions incorrectFractions3 = new IncorrectFractions
                            (incorrectFractions1.numerator * incorrectFractions2.denominator, 
                            incorrectFractions1.denominator * incorrectFractions2.denominator);
                IncorrectFractions incorrectFractions4 = new IncorrectFractions
                            (incorrectFractions2.numerator * incorrectFractions1.denominator,
                            incorrectFractions2.denominator * incorrectFractions1.denominator);
                return (incorrectFractions3 + incorrectFractions4);
            }
        }
        public static IncorrectFractions operator -(IncorrectFractions incorrectFractions1, IncorrectFractions incorrectFractions2)
        {
            if (incorrectFractions1.denominator == incorrectFractions2.denominator)
            {
                double commonNumerator = incorrectFractions1.numerator - incorrectFractions2.numerator;
                double commonDenominator = incorrectFractions1.denominator;
                return (new IncorrectFractions(commonNumerator, commonDenominator));
            }
            else
            {
                IncorrectFractions incorrectFractions3 = new IncorrectFractions
                            (incorrectFractions1.numerator * incorrectFractions2.denominator,
                            incorrectFractions1.denominator * incorrectFractions2.denominator);
                IncorrectFractions incorrectFractions4 = new IncorrectFractions
                            (incorrectFractions2.numerator * incorrectFractions1.denominator,
                            incorrectFractions2.denominator * incorrectFractions1.denominator);
                return (incorrectFractions3 - incorrectFractions4);
            }
        }
        public static IncorrectFractions operator *(IncorrectFractions incorrectFractions1, IncorrectFractions incorrectFractions2)
        {
            double commonNumerator = incorrectFractions1.numerator * incorrectFractions2.numerator;
            double commonDenominator = incorrectFractions1.denominator * incorrectFractions2.denominator;
            return (new IncorrectFractions(commonNumerator, commonDenominator));
        }
        public static IncorrectFractions operator /(IncorrectFractions incorrectFractions1, IncorrectFractions incorrectFractions2)
        {
            double commonNumerator = incorrectFractions1.numerator * incorrectFractions2.denominator;
            double commonDenominator = incorrectFractions1.denominator * incorrectFractions2.numerator;
            return (new IncorrectFractions(commonNumerator, commonDenominator));
        }

        //Задание 3
        public String GetADrSign()
        {
            if (this.numerator * this.denominator > 0)
            {
                return ("+");
            }
            else return ("-");
        }

        //Задание 4
        public void  NewNumerator(double numerator)
        {
            RepFanN(this, numerator);
            this.numerator = numerator;
        }
        public void  NewDenominator(double denominator)
        {
            RepFanD(this, denominator);
            this.denominator = denominator;
        }
        //Задание 5
        public double GetTheIndexOfTheNumeratorAndDenominator(IncorrectFractions incorrectFractions, int index)
        {
            List<double> fractions = new List<double> { this.numerator, this.denominator };
            return (fractions[index]);
        }

        //Вспомогадельно
        public String GetFraction()
        {
            return numerator +"/"+ denominator;
        }
        public double GetNumerator()
        {
            return (this.numerator);
        }
        public double GetDenominator()
        {
            return (this.denominator);
        }
    }
}
