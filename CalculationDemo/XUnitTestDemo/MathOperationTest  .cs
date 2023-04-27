using CalculationDemo;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace XUnitTestDemo
{
    public class MathOperationTest
    {
        [Fact]
        public void Task_Add_TwoNumber()
        {
            var a = 10.5;
            var b = 20.5;
            var ExpectedValue = 31;
            var sum=Program.AddOperation(a, b);
            Assert.Equal(ExpectedValue, sum);

        }

        [Fact]
        public void Task_subtract_TwoNumber()
        {
            var a = 20.5;
            var b = 10.5;
            var ExpectedValue = 10;
            var sub = Calculation.SubOperation(a, b);
            Assert.Equal(ExpectedValue, sub);

        }

        [Fact]
        public void Task_Multiply_TwoNumber()
        {
            var a = 1.5;
            var b = 1.5;
            var ExpectedValue = 22.5;
            var mul = Calculation.Multiplyoperation(a, b);
            Assert.Equal(ExpectedValue, mul);

        }

        [Fact]
        public void Task_Divide_TwoNumber()
        {
            var a = 1.5;
            var b = 1.5;
            var ExpectedValue = 1;
            var div = Calculation.Divideoperation(a, b);
            Assert.Equal(ExpectedValue, div);

        }
    }
}