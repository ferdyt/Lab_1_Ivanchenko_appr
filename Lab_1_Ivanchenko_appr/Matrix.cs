using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1_Ivanchenko_appr
{
    internal class Matrix
    {
        private readonly double[,] _data;

        public int Rows { get; }
        public int Columns { get; }
        public int Rank { get; set; }

        public Matrix(double[,] matrix)
        {
            _data = matrix;
            Rows = matrix.GetLength(0);
            Columns = matrix.GetLength(1);
        }

        public double this[int row, int col]
        {
            get => _data[row, col];
            set => _data[row, col] = value;
        }

        public Matrix Clone()
        {
            int rows = Rows;
            int cols = Columns;
            double[,] newData = new double[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    newData[i, j] = this[i, j];

            return new Matrix(newData);
        }
    }
}