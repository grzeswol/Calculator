using System;
using System.Collections.Generic;

namespace Calculator
{
    class Tokens
    {
        private const string Operators = "+-=!^*/%";
        private const string RightOperators = "=!^";
        private const string LeftOperators = "+-*/%";

        private Dictionary<string,int> _operatorsPrecedence = new Dictionary<string, int>
            {
                {"=",1},
                {"+-",2},
                {"%/*",3},
                {"!",4},
                {"^",5},
            }; 
        
        /// <summary>
        /// Indicates whether current string is an operator or not.
        /// </summary>
        /// <param name="s">String to test</param>
        /// <returns>True if given string is an operator.</returns>
        public bool IsOperator(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return false;
            }
            return Operators.Contains(s);
        }

        /// <summary>
        /// Gets precedence for given operator.
        /// </summary>
        /// <param name="s">Operator </param>
        /// <returns>Value for given operator</returns>
        public int GetPrecedenceFor(string s)
        {
            foreach (KeyValuePair<string,int>precendenceMap in _operatorsPrecedence)
            {
                if (precendenceMap.Key.Contains(s))
                {
                    return precendenceMap.Value;
                }
            }
            throw new InvalidOperationException(s + " is invalid operator!");
        }

        /// <summary>
        /// Indicates whether current string is a number.
        /// </summary>
        /// <param name="s">String to test</param>
        /// <returns>True if string is a number</returns>
        public bool IsNumber(string s)
        {
            int result;
            return int.TryParse(s, out result);
        }

        /// <summary>
        /// Indicates whether current operator is left associative.
        /// </summary>
        /// <param name="s">Operator to test</param>
        /// <returns>True if operator is left associative</returns>
        public bool IsLeftAssociative(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s.Length != 1)
            {
                throw new ArgumentException("Incorrect operator!");
            }
            return LeftOperators.Contains(s);
        }

        /// <summary>
        /// Indicates whether current operator is right associative.
        /// </summary>
        /// <param name="s">Operator to test</param>
        /// <returns>True if operator is right associative</returns>
        public bool IsRightAssociative(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s.Length != 1)
            {
                throw new ArgumentException("Incorrect operator!");
            }
            return RightOperators.Contains(s);
        }

        /// <summary>
        /// Check if given string is a function.
        /// </summary>
        /// <param name="s">String to test</param>
        /// <returns>True if string is a function</returns>
        public bool IsFunction(string s)
        {
            char function;
            char.TryParse(s, out function);
            return (function >= 'A' && function <= 'Z');
        }
    }
}
