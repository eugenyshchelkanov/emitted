using NUnit.Framework;

namespace Emitted.Test.Nullable
{
    public class Int32
    {
        [TestCase(0, 0, true)]
        [TestCase(1, 1, true)]
        [TestCase(int.MaxValue, int.MaxValue, true)]
        [TestCase(-1, -1, true)]
        [TestCase(int.MinValue, int.MinValue, true)]
        [TestCase(0, 1, false)]
        [TestCase(0, -1, false)]
        [TestCase(0, int.MinValue, false)]
        [TestCase(0, int.MaxValue, false)]
        [TestCase(1, -1, false)]
        [TestCase(1, int.MinValue, false)]
        [TestCase(1, int.MaxValue, false)]
        [TestCase(-1, int.MinValue, false)]
        [TestCase(-1, int.MaxValue, false)]
        [TestCase(int.MinValue, int.MaxValue, false)]
        [TestCase(null, null, true)]
        [TestCase(null, 0, false)]
        [TestCase(null, 1, false)]
        public void Equals(int? left, int? right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public int? Value { get; set; }
        }
    }
}
