using System;
using System.Collections.Generic;

namespace Lib1
{
    public class Class1
    {
        public static List<double> Pus(List<double> M)
        {//0
            for (int i = 0; i < M.Count - 1; i++)//1
            {
                for (int j = M.Count - 2; j > i - 1; j--)//2
                {
                    if (M[j] > M[j + 1])//3
                    {
                        double C = M[j];//4
                        M[j] = M[j + 1];
                        M[j + 1] = C;
                    }
                }
            }
            return M;//5
        }//6
    }
}
