using System;
using System.Collections.Generic;

namespace Lib1
{
    public class Class1
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
