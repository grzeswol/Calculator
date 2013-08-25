using System;
using NUnit.Framework;

namespace Calculator.Test.Unit
{
    [TestFixture]
    class TokensTest
    {
        [Test]
        public void IsOperator_StringIsNull_ReturnsFalse()
        {
            var tokens = new Tokens().IsOperator(null);
            Assert.AreEqual(false, tokens);
        }

        [Test]
        public void GetPrecedenceFor_SetInvalidOperator_ThrowsInvalidOperationException()
        {
            var tokens = new Tokens();
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => tokens.GetPrecedenceFor("test"));
            Assert.AreEqual("test is invalid operator!", exception.Message);
        }

        [Test]
        public void IsLeftAssociative_SetOperatorLongerThan1_ThrowsArgumentException()
        {
            var tokens = new Tokens();
            var exception = Assert.Throws<ArgumentException>(() => tokens.IsLeftAssociative("++"));
            Assert.AreEqual("Incorrect operator!", exception.Message);
        }

        [Test]
        public void IsLeftAssociative_SetNullOperator_ThrowsArgumentException()
        {
            var tokens = new Tokens();
            var exception = Assert.Throws<ArgumentException>(() => tokens.IsLeftAssociative(null));
            Assert.AreEqual("Incorrect operator!", exception.Message);
        }

        [Test]
        public void IsRightAssociative_SetOperatorLongerThan1_ThrowsArgumentException()
        {
            var tokens = new Tokens();
            var exception = Assert.Throws<ArgumentException>(() => tokens.IsRightAssociative("++"));
            Assert.AreEqual("Incorrect operator!", exception.Message);
        }

        [Test]
        public void IsRightAssociative_SetNullOperator_ThrowsArgumentException()
        {
            var tokens = new Tokens();
            var exception = Assert.Throws<ArgumentException>(() => tokens.IsRightAssociative(null));
            Assert.AreEqual("Incorrect operator!", exception.Message);
        }
    }
}
