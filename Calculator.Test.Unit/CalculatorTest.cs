using NUnit.Framework;

namespace Calculator.Test.Unit
{
    [TestFixture]
    public class CalculatorTest
    {

        [Test]
        public void Add_AddTwoNumbers_ReturnsSum()
        {
            var calc = new Calculator();
            double result = calc.Add(5, 6);
            Assert.AreEqual(11, result);
        }

        [Test]
        public void Add_AddNegativeNumbers_ReturnsSum()
        {
            var calc = new Calculator();
            double result = calc.Add(-3, -4);
            Assert.AreEqual(-7, result);
        }

        [TestCase("2 + 5 * 4 + 3 / 5", "2 5 4 * + 3 5 / +")]
        [TestCase("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3", "3 4 2 * 1 5 - 2 3 ^ ^ / +")]
        public void Transform_TransformFromInfixExpresison_ReturnsTransformedExpression(string expression, string expected)
        {
            var transformer = new Calculator();
            var result = transformer.Transform(expression);
            Assert.AreEqual(expected, result);
        }

    
    }
}
