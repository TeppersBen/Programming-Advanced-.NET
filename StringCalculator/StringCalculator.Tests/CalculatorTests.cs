using System;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void AddEmpty()
        {
            int value = _calculator.Add("");
            Assert.That(value, Is.Zero);
        }
        [Test]

        public void AddOneNumber()
        {
            int value = _calculator.Add("1");
            Assert.That(value, Is.EqualTo(1));
        }

        [Test]
        public void AddTwoNumbers()
        {
            int value = _calculator.Add("1,2");
            Assert.That(value, Is.EqualTo(3));
        }

        [Test]
        public void AddMultipleNumbers()
        {
            int value = _calculator.Add("5,7,9,10,5");
            Assert.That(value, Is.EqualTo(36));
        }

        [Test]
        public void ThrowInvalidNumberException()
        {
            Assert.That(
                () => _calculator.Add("a,b,c,d"), 
                Throws.Exception.With.Message.EqualTo("Invalid Number"));
        }

        [Test]
        public void AddNumbersWithNewLine()
        {
            int value = _calculator.Add("5\n5");
            Assert.That(value, Is.EqualTo(10));
        }
    }
}
