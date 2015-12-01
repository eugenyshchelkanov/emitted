using NUnit.Framework;

namespace Emitted.Test.PrimitiveTypes
{
    public class Int64
    {
        [TestCase(0L, 0L, true)]
        [TestCase(1L, 1L, true)]
        [TestCase(long.MaxValue, long.MaxValue, true)]
        [TestCase(-1L, -1L, true)]
        [TestCase(long.MinValue, long.MinValue, true)]
        [TestCase(0L, 1L, false)]
        [TestCase(0L, -1L, false)]
        [TestCase(0L, long.MinValue, false)]
        [TestCase(0L, long.MaxValue, false)]
        [TestCase(1L, -1L, false)]
        [TestCase(1L, long.MinValue, false)]
        [TestCase(1L, long.MaxValue, false)]
        [TestCase(-1L, long.MinValue, false)]
        [TestCase(-1L, long.MaxValue, false)]
        [TestCase(long.MinValue, long.MaxValue, false)]
        public void Equals(long left, long right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public long Value { get; set; }
        }
    }
}
