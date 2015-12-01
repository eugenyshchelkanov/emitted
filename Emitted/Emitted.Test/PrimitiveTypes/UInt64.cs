using NUnit.Framework;

namespace Emitted.Test.PrimitiveTypes
{
    public class UInt64
    {
        [TestCase(0UL, 0UL, true)]
        [TestCase(1UL, 1UL, true)]
        [TestCase(ulong.MaxValue, ulong.MaxValue, true)]
        [TestCase(0UL, 1UL, false)]
        [TestCase(0UL, ulong.MaxValue, false)]
        [TestCase(1UL, ulong.MaxValue, false)]
        public void Equals(ulong left, ulong right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public ulong Value { get; set; }
        }
    }
}
