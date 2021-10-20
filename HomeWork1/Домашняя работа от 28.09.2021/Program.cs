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
        private String fraction;

        //Ктрукторы
        public IncorrectFractions(double numerator)
        {
            this.fraction = (numerator + "/" + 1).ToString();
        }
        public IncorrectFractions(double numerator, double denominator)
        {
            this.fraction = (numerator + "/" + denominator).ToString();
        }
        public IncorrectFractions(double integer, double numerator, double denominator)
        {
            this.fraction = ((integer * denominator) + numerator + "/" + denominator).ToString();
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
            if (this.GetNumerator() * this.GetDenominator() > 0)
            {
                return ("+");
            }
            else return ("-");
        }

        //Задание 4
        public void  NewNumerator(double numerator)
        {
            RepFanN(this, numerator);
            this.fraction = (numerator + "/" + this.GetDenominator()).ToString();
        }
        public void  NewDenominator(double denominator)
        {
            RepFanD(this, denominator);
            this.fraction = (this.GetNumerator() + "/" + denominator).ToString();
        }
        //Задание 5
        public double GetTheIndexOfTheNumeratorAndDenominator(IncorrectFractions incorrectFractions, int index)
        {
            List<double> fractions = new List<double> { this.GetNumerator(), this.GetDenominator() };
            return (fractions[index]);
        }

        //Вспомогадельно
        public String GetFraction()
        {
            return fraction;
        }
        public double GetNumerator()
        {
            return (Convert.ToDouble(this.fraction.Split("/")[0]));
        }
        public double GetDenominator()
        {
            return (Convert.ToDouble(this.fraction.Split("/")[1]));
        }
    }
}
