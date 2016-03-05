using System;
using NUnit.Framework;
using Utils;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void one_plus_one_equal_two()
        {
            var calc = new Calculator();
            var result = calc.Sum(1, 1);
            Assert.AreEqual(result, 2);
        }
    }
}
