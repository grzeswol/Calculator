using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        private InfixNotationTransformer transformer = new InfixNotationTransformer();

        public double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public string Transform(string formula)
        {
            return transformer.Transform(formula);
        }
    }
}
