using NUnit.Framework;

namespace Emitted.Test.PrimitiveTypes
{
    public class UInt32
    {
        [TestCase(0U, 0U, true)]
        [TestCase(1U, 1U, true)]
        [TestCase(uint.MaxValue, uint.MaxValue, true)]
        [TestCase(0U, 1U, false)]
        [TestCase(0U, uint.MaxValue, false)]
        [TestCase(1U, uint.MaxValue, false)]
        public void Equals(uint left, uint right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public uint Value { get; set; }
        }
    }
}
