using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Calculator
{
    public class Calculator
    {
        public string CalculateRPN(string rpn)
        {
            List<string> rpnTokens = rpn.Split(' ').ToList();
            Stack<decimal> stack = new Stack<decimal>();
            decimal number;

            foreach (string token in rpnTokens)
            {
                if (decimal.TryParse(token, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    try
                    {
                        switch (token)
                        {
                            case "^":
                            case "pow":
                                {
                                    number = stack.Pop();
                                    stack.Push((decimal)Math.Pow((double)stack.Pop(), (double)number));
                                    break;
                                }
                            case "*":
                                {
                                    stack.Push(stack.Pop() * stack.Pop());
                                    break;
                                }
                            case "/":
                                {
                                    number = stack.Pop();
                                    stack.Push(stack.Pop() / number);
                                    break;
                                }
                            case "+":
                                {
                                    stack.Push(stack.Pop() + stack.Pop());
                                    break;
                                }
                            case "-":
                                {
                                    number = stack.Pop();
                                    stack.Push(stack.Pop() - number);
                                    break;
                                }
                            default:
                                throw new ArgumentException("Error calculating expression!");
                        }
                    }
                    catch (OverflowException ex)
                    {
                        throw ex;
                    }
                    
                }
            }

            return stack.Pop().ToString(CultureInfo.CurrentCulture);
        }

        
    }
}
