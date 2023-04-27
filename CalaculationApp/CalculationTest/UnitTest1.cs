using CalaculationApp;

using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CalculationTest
{
    public class UnitTest1
    {
       
        [Fact]
        public void Task_Add_TwoNumber()
        {
            //var a = 10.5;
            //var b = 20.5;
            //var ExpectedValue = 31;
            var sum = CalculationDemo.Add(10.5, 20.5);
            //Assert.Equal(ExpextedValue, ActualValue)
            Assert.Equal(31, sum);

        }
        [Fact]
        public void Task_subtract_TwoNumber()
        {
            //var a = 20.5;
            //var b = 10.5;
            //var ExpectedValue = 10;
            var sub = CalculationDemo.Subtract(20.5, 10.5);
            Assert.Equal(10, sub);

        }

        [Fact]
        public void Task_Multiply_TwoNumber()
        {
            //var a = 1.5;
            //var b = 1.5;
            //var ExpectedValue = 2.25;
            var mul = CalculationDemo.Multiply(1.5, 1.5);
            Assert.Equal(2.25, mul);

        }

        [Fact]
        public void Task_Divide_TwoNumber()
        {
            //var a = 1.5;
            //var b = 1.5;
            //var ExpectedValue = 1;
            var div = CalculationDemo.Divide(1.5, 1.5);
            Assert.Equal(1, div);

        }
    }
}