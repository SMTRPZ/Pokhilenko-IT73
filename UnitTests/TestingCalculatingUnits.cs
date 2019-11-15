using System;
using System.Reflection;
using ImageCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestingCalculatingUnits
    {
        private Action GetArgumentNullAction(CalculatingUnit unit)
        {
            return () => { unit.ComputeParameter(null); };
        }

        [TestMethod]
        public void Contrast_Matrix_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(GetArgumentNullAction(new ContrastUnit()));
        }

        [TestMethod]
        public void AngularMomentum_Matrix_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(GetArgumentNullAction(new AngularMomentumUnit()));
        }

        [TestMethod]
        public void Entropy_Matrix_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(GetArgumentNullAction(new EntropyUnit()));
        }

        [TestMethod]
        public void Correlation_Matrix_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(GetArgumentNullAction(new CorrelationUnit()));
        }

        private Action GetArgumentAction(CalculatingUnit unit)
        {
            return () => { unit.ComputeParameter(new int[1, 2]); };
        }

        [TestMethod]
        public void Contrast_Matrix_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(GetArgumentAction(new ContrastUnit()));
        }

        [TestMethod]
        public void AngularMomentum_Matrix_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(GetArgumentAction(new AngularMomentumUnit()));
        }

        [TestMethod]
        public void Entropy_Matrix_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(GetArgumentAction(new EntropyUnit()));
        }

        [TestMethod]
        public void Correlation_Matrix_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(GetArgumentAction(new CorrelationUnit()));
        }

        [TestMethod]
        public void Contrast_Matrix_Compute()
        {
            Assert.AreEqual(new ContrastUnit().ComputeParameter(GetOneXOneArray()), 11.25f);
        }

        [TestMethod]
        public void AngularMomentum_Matrix_Compute()
        {
            Assert.AreEqual(new AngularMomentumUnit().ComputeParameter(GetOneXOneArray()), 1.477f);
        }

        [TestMethod]
        public void Entropy_Matrix_Compute()
        {
            Assert.AreEqual(new EntropyUnit().ComputeParameter(GetOneXOneArray()), -1.98f);
        }

        [TestMethod]
        public void Correlation_Matrix_Compute()
        {
            Assert.AreEqual(new CorrelationUnit().ComputeParameter(GetOneXOneArray()), 6.0017f);
        }

        int[,] GetOneXOneArray()
        {
            return new int[1, 1] { { 1 } };
        }
    }
}
