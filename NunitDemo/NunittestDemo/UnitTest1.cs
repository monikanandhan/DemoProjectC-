using NunitDemo;

namespace NunittestDemo
{
    public class Tests
    {
        [Test]
        public void SimpleArithmetic()
        {
            int r1 = Arithmetic.add(3, 3);
            Assert.AreEqual(r1, 6);

            int r2 = Arithmetic.sub(3, 3);
            Assert.AreEqual(r2, 0);

            int r3 = Arithmetic.mul(3, 3);
            Assert.AreEqual(r3, 9);

            int r4 = Arithmetic.div(3, 3);
            Assert.AreEqual(r4, 1);
        }
    }
}