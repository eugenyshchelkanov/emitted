using NUnit.Framework;

namespace Emitted.Test.PrimitiveTypes
{
    public class Decimal
    {
        [TestCase(0, 0, true)]
        [TestCase(0.1, 0.1, true)]
        [TestCase(1, 1, true)]
        [TestCase(-0.1, -0.1, true)]
        [TestCase(-1, -1, true)]
        [TestCase(0, 0.1, false)]
        [TestCase(0, 1, false)]
        [TestCase(0, -1, false)]
        [TestCase(0, -0.1, false)]
        [TestCase(1, -1, false)]
        public void Equals(decimal left, decimal right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public decimal Value { get; set; }
        }
    }
}
