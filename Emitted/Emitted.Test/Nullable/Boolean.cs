using NUnit.Framework;

namespace Emitted.Test.Nullable
{
    public class Boolean
    {
        [TestCase(true, true, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, true)]
        [TestCase(null, null, true)]
        [TestCase(null, false, false)]
        [TestCase(null, true, false)]
        public void Equals(bool? left, bool? right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public bool? Value { get; set; }
        }
    }
}
