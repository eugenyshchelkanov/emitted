using NUnit.Framework;

namespace Emitted.Test.PrimitiveTypes
{
    public class Byte
    {
        [TestCase(0, 0, true)]
        [TestCase(1, 1, true)]
        [TestCase(byte.MaxValue, byte.MaxValue, true)]
        [TestCase(0, 1, false)]
        [TestCase(0, byte.MaxValue, false)]
        [TestCase(1, byte.MaxValue, false)]
        public void Equals(byte left, byte right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public byte Value { get; set; }
        }
    }
}
