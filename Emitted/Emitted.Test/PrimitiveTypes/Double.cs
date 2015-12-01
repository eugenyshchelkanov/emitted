using NUnit.Framework;

namespace Emitted.Test.PrimitiveTypes
{
    public class Double
    {
        [TestCase(0d, 0d, true)]
        [TestCase(0.1d, 0.1d, true)]
        [TestCase(1d, 1d, true)]
        [TestCase(double.MaxValue, double.MaxValue, true)]
        [TestCase(-0.1d, -0.1d, true)]
        [TestCase(-1d, -1d, true)]
        [TestCase(double.MinValue, double.MinValue, true)]
        [TestCase(0d, 0.1d, false)]
        [TestCase(0d, 1d, false)]
        [TestCase(0d, -1d, false)]
        [TestCase(0d, -0.1d, false)]
        [TestCase(0d, double.MinValue, false)]
        [TestCase(0d, double.MaxValue, false)]
        [TestCase(1d, -1d, false)]
        [TestCase(1d, double.MinValue, false)]
        [TestCase(1d, double.MaxValue, false)]
        [TestCase(-1d, double.MinValue, false)]
        [TestCase(-1d, double.MaxValue, false)]
        [TestCase(double.MinValue, double.MaxValue, false)]
        public void Equals(double left, double right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public double Value { get; set; }
        }
    }
}
