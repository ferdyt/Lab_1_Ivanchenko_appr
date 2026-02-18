using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1_Ivanchenko_appr
{
    internal class RankCalculator
    {
        public int CalculateRank(Matrix matrix)
        {
            int rank = 0;
            int rows = matrix.Rows;
            int cols = matrix.Columns;
            for (int i = 0; i < rows; i++)
            {
                bool nonZeroRow = false;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        nonZeroRow = true;
                        break;
                    }
                }
                if (nonZeroRow)
                {
                    rank++;
                }
            }
            return rank;
        }
    }
}
