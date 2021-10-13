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
            Console.WriteLine(new IncorrectFractions(2, 3, 6).GetFraction()) ;
            Console.WriteLine((new IncorrectFractions(5, 5) / new IncorrectFractions(6, 4)).GetFraction());
            Console.WriteLine((new IncorrectFractions(5, 5) + new IncorrectFractions(6, 4)).GetFraction());
            Console.WriteLine((new IncorrectFractions(5, 5) - new IncorrectFractions(6, 4)).GetFraction());
            Console.WriteLine((new IncorrectFractions(5, 5) * new IncorrectFractions(6, 4)).GetFraction());


            IncorrectFractions incorrectFractions = new IncorrectFractions(-3, 4);


            Console.WriteLine(incorrectFractions.ConvertingFractionsToDecimal());
            Console.WriteLine(incorrectFractions.GetADrSign());
            Console.WriteLine(incorrectFractions.ReplacingAFraction(7, 8).GetFraction());
            Console.WriteLine(incorrectFractions.GetTheIndexOfTheNumeratorAndDenominator(incorrectFractions, 1));
        }
    }

    public class IncorrectFractions
    {
        private delegate void method();
        private event method RepFan;
        private String fraction;

        //Ктрукторы
        public IncorrectFractions(double numerator)
        {
            this.fraction = (numerator + "/" + 1).ToString();
            RepFan += ReplacingAFractionCons;
        }
        public IncorrectFractions(double numerator, double denominator)
        {
            this.fraction = (numerator + "/" + denominator).ToString();
            RepFan += ReplacingAFractionCons;
        }
        public IncorrectFractions(double integer, double numerator, double denominator)
        {
            this.fraction = ((integer * denominator) + numerator + "/" + denominator).ToString();
            RepFan += ReplacingAFractionCons;
        }

        //Задание 1
        public double ConvertingFractionsToDecimal()
        {
            return (this.GetNumerator() / this.GetDenominator());
        }

        //Задание 2
        public static IncorrectFractions operator +(IncorrectFractions incorrectFractions1, IncorrectFractions incorrectFractions2)
        {
            if (incorrectFractions1.GetDenominator() == incorrectFractions2.GetDenominator())
            {
                double commonNumerator = incorrectFractions1.GetNumerator() + incorrectFractions2.GetNumerator();
                double commonDenominator = incorrectFractions1.GetDenominator();
                return (new IncorrectFractions(commonNumerator, commonDenominator));
            }
            else
            {
                IncorrectFractions incorrectFractions3 = new IncorrectFractions
                            (incorrectFractions1.GetNumerator() * incorrectFractions2.GetDenominator(), 
                            incorrectFractions1.GetDenominator() * incorrectFractions2.GetDenominator());
                IncorrectFractions incorrectFractions4 = new IncorrectFractions
                            (incorrectFractions2.GetNumerator() * incorrectFractions1.GetDenominator(),
                            incorrectFractions2.GetDenominator() * incorrectFractions1.GetDenominator());
                return (incorrectFractions3 + incorrectFractions4);
            }
        }
        public static IncorrectFractions operator -(IncorrectFractions incorrectFractions1, IncorrectFractions incorrectFractions2)
        {
            if (incorrectFractions1.GetDenominator() == incorrectFractions2.GetDenominator())
            {
                double commonNumerator = incorrectFractions1.GetNumerator() - incorrectFractions2.GetNumerator();
                double commonDenominator = incorrectFractions1.GetDenominator();
                return (new IncorrectFractions(commonNumerator, commonDenominator));
            }
            else
            {
                IncorrectFractions incorrectFractions3 = new IncorrectFractions
                            (incorrectFractions1.GetNumerator() * incorrectFractions2.GetDenominator(),
                            incorrectFractions1.GetDenominator() * incorrectFractions2.GetDenominator());
                IncorrectFractions incorrectFractions4 = new IncorrectFractions
                            (incorrectFractions2.GetNumerator() * incorrectFractions1.GetDenominator(),
                            incorrectFractions2.GetDenominator() * incorrectFractions1.GetDenominator());
                return (incorrectFractions3 + incorrectFractions4);
            }
        }
        public static IncorrectFractions operator *(IncorrectFractions incorrectFractions1, IncorrectFractions incorrectFractions2)
        {
            double commonNumerator = incorrectFractions1.GetNumerator() * incorrectFractions2.GetNumerator();
            double commonDenominator = incorrectFractions1.GetDenominator() * incorrectFractions2.GetDenominator();
            return (new IncorrectFractions(commonNumerator, commonDenominator));
        }
        public static IncorrectFractions operator /(IncorrectFractions incorrectFractions1, IncorrectFractions incorrectFractions2)
        {
            double commonNumerator = incorrectFractions1.GetNumerator() * incorrectFractions2.GetDenominator();
            double commonDenominator = incorrectFractions1.GetDenominator() * incorrectFractions2.GetNumerator();
            return (new IncorrectFractions(commonNumerator, commonDenominator));
        }

        //Задание 3
        public String GetADrSign()
        {
            if (this.fraction[0] != '-')
            {
                return ("+");
            }
            else return ("-");
        }

        //Задание 4
        public IncorrectFractions ReplacingAFraction(double numerator, double denominator)
        {
            RepFan();
            return (new IncorrectFractions(numerator, denominator));
        }
        public void ReplacingAFractionCons()
        {
            Console.WriteLine("Вы поменяли дробь!");
        }
        //Задание 5 (неверно пока)
        public double GetTheIndexOfTheNumeratorAndDenominator(IncorrectFractions incorrectFractions, int index)
        {
            List<double> fractions = new List<double> 
                                    { Convert.ToDouble(incorrectFractions.fraction.Split("/")[0]), 
                                      Convert.ToDouble(incorrectFractions.fraction.Split("/")[1]) };
            return (fractions[index]);
        }

        //Вспомогадельно
        public String GetFraction()
        {
            return fraction;
        }
        private double GetNumerator()
        {
            return (Convert.ToDouble(this.fraction.Split("/")[0]));
        }
        private double GetDenominator()
        {
            return (Convert.ToDouble(this.fraction.Split("/")[1]));
        }
    }
}
