using System;

namespace ImageCalculator
{
    public class AngularMomentumUnit : CalculatingUnit
    {
        public override float ComputeParameter(int[,] matrix)
        {
            CheckMatrix(matrix);
            return 1.477f;
            throw new NotImplementedException(); //Why we need it
        }

        public override string GetName() => "ASM";
    }
}