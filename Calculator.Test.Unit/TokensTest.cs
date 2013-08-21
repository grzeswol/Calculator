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
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = "test is invalid operator!")]
        public void GetPrecedenceFor_SetInvalidOperator_ThrowsInvalidOperationException()
        {
            var tokens = new Tokens();
            tokens.GetPrecedenceFor("test");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Incorrect operator!")]
        public void IsLeftAssociative_SetOperatorLongerThan1_ThrowsArgumentException()
        {
            var tokens = new Tokens();
            tokens.IsLeftAssociative("++");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Incorrect operator!")]
        public void IsLeftAssociative_SetNullOperator_ThrowsArgumentException()
        {
            var tokens = new Tokens();
            tokens.IsLeftAssociative(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Incorrect operator!")]
        public void IsRightAssociative_SetOperatorLongerThan1_ThrowsArgumentException()
        {
            var tokens = new Tokens();
            tokens.IsRightAssociative("++");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Incorrect operator!")]
        public void IsRightAssociative_SetNullOperator_ThrowsArgumentException()
        {
            var tokens = new Tokens();
            tokens.IsRightAssociative(null);
        }
    }
}
