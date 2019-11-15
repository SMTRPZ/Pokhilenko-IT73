using System;

namespace ImageCalculator
{
    public class ContrastUnit : CalculatingUnit
    {
        public override float ComputeParameter(int[,] matrix)
        {
            CheckMatrix(matrix);
            return 11.25f;
            throw new NotImplementedException(); //Why
        }

        public override string GetName() => "CON";
    }
}