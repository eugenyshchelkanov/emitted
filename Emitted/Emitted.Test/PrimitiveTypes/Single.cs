using NUnit.Framework;

namespace Emitted.Test.PrimitiveTypes
{
    public class Single
    {
        [TestCase(0f, 0f, true)]
        [TestCase(0.1f, 0.1f, true)]
        [TestCase(1f, 1f, true)]
        [TestCase(float.MaxValue, float.MaxValue, true)]
        [TestCase(-0.1f, -0.1f, true)]
        [TestCase(-1f, -1f, true)]
        [TestCase(float.MinValue, float.MinValue, true)]
        [TestCase(0f, 0.1f, false)]
        [TestCase(0f, 1f, false)]
        [TestCase(0f, -1f, false)]
        [TestCase(0f, -0.1f, false)]
        [TestCase(0f, float.MinValue, false)]
        [TestCase(0f, float.MaxValue, false)]
        [TestCase(1f, -1f, false)]
        [TestCase(1f, float.MinValue, false)]
        [TestCase(1f, float.MaxValue, false)]
        [TestCase(-1f, float.MinValue, false)]
        [TestCase(-1f, float.MaxValue, false)]
        [TestCase(float.MinValue, float.MaxValue, false)]
        public void Equals(float left, float right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public float Value { get; set; }
        }
    }
}
