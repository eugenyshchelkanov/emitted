﻿using NUnit.Framework;

namespace Emitted.Test.Nullable
{
    public class Enum
    {
        [TestCase(TesteeEnum.One, TesteeEnum.One, true)]
        [TestCase(TesteeEnum.Two, TesteeEnum.Two, true)]
        [TestCase(TesteeEnum.One, TesteeEnum.Two, false)]
        [TestCase(TesteeEnum.Two, TesteeEnum.One, false)]
        [TestCase(null, null, true)]
        [TestCase(null, TesteeEnum.One, false)]
        [TestCase(null, TesteeEnum.Two, false)]
        public void Equals(TesteeEnum? left, TesteeEnum? right, bool expected)
        {
            var first = new Testee { Value = left };
            var second = new Testee { Value = right };
            Assert.That(Emitted.Equals(first, second), Is.EqualTo(expected));
        }

        public class Testee
        {
            public TesteeEnum? Value { get; set; }
        }

        public enum TesteeEnum
        {
            One, Two
        }

    }
}
