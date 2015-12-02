using NUnit.Framework;

namespace Emitted.Test.Nullable
{
    public class Char
    {
        [TestCase((char)0, (char)0, true)]
        [TestCase((char)1, (char)1, true)]
        [TestCase('a', 'a', true)]
        [TestCase(char.MaxValue, char.MaxValue, true)]
        [TestCase((char)0, (char)1, false)]
        [TestCase((char)0, char.MaxValue, false)]
        [TestCase((char)1, char.MaxValue, false)]
        [TestCase('a', 'b', false)]
        [TestCase(null, null, true)]
        [TestCase(null, (char)0, false)]
        [TestCase(null, 'a', false)]
        public void Equals(char? left, char? right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public char? Value { get; set; }
        }
    }
}
