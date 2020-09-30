using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesExamples
{
    class MatrixBad
    {
        double[,] values;

        public static double[,] operator +(double[,] a, double[,] b)
        {
            throw new NotImplementedException();
        }

        public static double[,] operator +(MatrixBad a, MatrixBad b)
        {
            throw new NotImplementedException();
        }
    }

    class MatrixGood
    {
        double[,] values;

        public static MatrixGood operator +(MatrixGood a, MatrixGood b)
        {
            throw new NotImplementedException();
        }
    }


}
