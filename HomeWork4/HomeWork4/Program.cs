using System;
using System.Collections.Generic;

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<double> number = new List<double>() {1, -1};
            for(int i = 0; i < number.Count; i++)
            Console.WriteLine(Sort.Pus(number)[i]);
        }
    }
    public class Matrix
    {
        public static double GetM(double[][] Matrix)
        {
            {
                double Returning;
                if (Matrix.Length == 2)
                {
                    Returning = (Matrix[0][0] * Matrix[1][1]) - (Matrix[0][1] * Matrix[1][0]);
                }
                else
                {
                    double[][] Minor = new double[Matrix.Length - 1][]; //минор, но возможно, что это матрица n-ого порядка
                    int i, j, k;
                    short Minus = 1;
                    double Temp;
                    Returning = 0;
                    for (i = 0; i < Matrix.Length; i++)
                    {
                        for (j = 1; j < Matrix.Length; j++) //сохраняю значения для "возможно" минора
                        {
                            Minor[j - 1] = new double[Matrix.Length - 1];
                            for (k = 0; k < i; k++) //значения до диагонали
                                Minor[j - 1][k] = Matrix[j][k];

                            for (k++; k < Matrix.Length; k++)   //значения после диагонали
                                Minor[j - 1][k - 1] = Matrix[j][k];
                        }
                        Temp = GetM(Minor);
                        Temp = Matrix[0][i] * Minus * Temp;
                        Returning += Temp;
                        if (Minus > 0)  //меняю знак, согласно правилам
                            Minus = -1;
                        else
                            Minus = 1;
                    }
                }
                return Returning;
            }
        }
    }

    public partial class Sort
    {
        public static List<double> Pus(List<double> M)
        {
            for (int i = 0; i < M.Count - 1; i++)
            {
                for (int j = M.Count - 2; j > i - 1; j--)
                {
                    if (M[j] > M[j + 1])
                    {
                        double C = M[j];
                        M[j] = M[j + 1];
                        M[j + 1] = C;
                    }
                }
            }
            return M;
        }
    }
}
