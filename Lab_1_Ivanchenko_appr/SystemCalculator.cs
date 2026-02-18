using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Lab_1_Ivanchenko_appr
{
    internal class SystemCalculator
    {
        public double[] Calculate(Matrix matrix, double[] constants)
        {
            double[] solution = new double[matrix.Rows];

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    solution[i] += Math.Round(matrix.Clone()[i, j] * constants[j], 2);
                }
            }

            return solution;
        }
    }
}
