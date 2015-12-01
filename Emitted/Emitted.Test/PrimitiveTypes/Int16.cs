using NUnit.Framework;

namespace Emitted.Test.PrimitiveTypes
{
    public class Int16
    {
        [TestCase(0, 0, true)]
        [TestCase(1, 1, true)]
        [TestCase(short.MaxValue, short.MaxValue, true)]
        [TestCase(-1, -1, true)]
        [TestCase(short.MinValue, short.MinValue, true)]
        [TestCase(0, 1, false)]
        [TestCase(0, -1, false)]
        [TestCase(0, short.MinValue, false)]
        [TestCase(0, short.MaxValue, false)]
        [TestCase(1, -1, false)]
        [TestCase(1, short.MinValue, false)]
        [TestCase(1, short.MaxValue, false)]
        [TestCase(-1, short.MinValue, false)]
        [TestCase(-1, short.MaxValue, false)]
        [TestCase(short.MinValue, short.MaxValue, false)]
        public void Equals(short left, short right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public short Value { get; set; }
        }
    }
}
