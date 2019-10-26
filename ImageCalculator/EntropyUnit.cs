using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageCalculator
{
    public class EntropyUnit : CalculatingUnit
    {
        public override float ComputeParameter(int[,] matrix)
        {
            CheckMatrix(matrix);
            return -1.98f;
            throw new NotImplementedException();
        }

        public override string GetName() => "ENT";
    }
}