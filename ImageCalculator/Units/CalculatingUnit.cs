using System;

namespace ImageCalculator
{
    public abstract class CalculatingUnit
    {
        public abstract float ComputeParameter(int[,] matrix);
        public abstract string GetName();
        protected virtual void CheckMatrix (int[,] matrix)
        {
            if (matrix == null) throw new ArgumentNullException("matrix", "Матрица была null.");

            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new ArgumentException("Матрица не была квадратной.", "matrix");

            if (matrix.Length == 0) throw new ArgumentException("Матрица имела нулевой размер.", "matrix");
        }
    }
}