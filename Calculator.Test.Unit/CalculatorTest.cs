using NUnit.Framework;

namespace Calculator.Test.Unit
{
    [TestFixture]
    public class CalculatorTest
    {

        [TestCase("2 + 5 * 4 + 3 / 5", "2 5 4 * + 3 5 / +")]
        [TestCase("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3", "3 4 2 * 1 5 - 2 3 ^ ^ / +")]
        public void Transform_TransformFromInfixToRPN_ReturnsTransformedExpression(string expression, string expected)
        {
            var transformer = new Calculator();
            var result = transformer.TransformFromInfixToRPN(expression);
            Assert.AreEqual(expected, result);
        }

        [TestCase("2 5 4 * + 3 5 / +", "22.6")]
        [TestCase("3 4 2 * 1 5 - 2 3 ^ ^ / +", "3.0001220703125")]
        public void Evaluate_EvaluateRPNExpression_ReturnsEvaluatedExpression(string rpnExpression, string expected)
        {
            var calc = new Calculator();
            var result = calc.CalculateRPN(rpnExpression);
            Assert.AreEqual(expected, result);
        }
    
    }
}
