using NUnit.Framework;

namespace Emitted.Test.PrimitiveTypes
{
    public class UInt16
    {
        [TestCase((ushort)0, (ushort)0, true)]
        [TestCase((ushort)1, (ushort)1, true)]
        [TestCase(ushort.MaxValue, ushort.MaxValue, true)]
        [TestCase((ushort)0, (ushort)1, false)]
        [TestCase((ushort)0, ushort.MaxValue, false)]
        [TestCase((ushort)1, ushort.MaxValue, false)]
        public void Equals(ushort left, ushort right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public ushort Value { get; set; }
        }
    }
}
