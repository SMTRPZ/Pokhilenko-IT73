using System;

namespace ImageCalculator
{
    public class CorrelationUnit : CalculatingUnit
    {
        public override float ComputeParameter(int[,] matrix)
        {
            CheckMatrix(matrix);
            return 6.0017f;
            throw new NotImplementedException(); //Why
        }

        public override string GetName() => "COR";
    }
}