using NUnit.Framework;

namespace Emitted.Test.Nullable
{
    public class SByte
    {
        [TestCase(0, 0, true)]
        [TestCase(1, 1, true)]
        [TestCase(sbyte.MaxValue, sbyte.MaxValue, true)]
        [TestCase(-1, -1, true)]
        [TestCase(sbyte.MinValue, sbyte.MinValue, true)]
        [TestCase(0, 1, false)]
        [TestCase(0, -1, false)]
        [TestCase(0, sbyte.MinValue, false)]
        [TestCase(0, sbyte.MaxValue, false)]
        [TestCase(1, -1, false)]
        [TestCase(1, sbyte.MinValue, false)]
        [TestCase(1, sbyte.MaxValue, false)]
        [TestCase(-1, sbyte.MinValue, false)]
        [TestCase(-1, sbyte.MaxValue, false)]
        [TestCase(sbyte.MinValue, sbyte.MaxValue, false)]
        [TestCase(null, null, true)]
        [TestCase(null, 0, false)]
        [TestCase(null, 1, false)]
        public void Equals(sbyte? left, sbyte? right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public sbyte? Value { get; set; }
        }
    }
}
