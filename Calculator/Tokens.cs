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

        public bool IsOperator(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return false;
            }
            return Operators.Contains(s);
        }

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

        public bool IsNumber(string s)
        {
            int result;
            return int.TryParse(s, out result);
        }

        public bool IsLeftAssociative(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s.Length != 1)
            {
                throw new ArgumentException("Incorrect operator!");
            }
            return LeftOperators.Contains(s);
        }

        public bool IsRightAssociative(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s.Length != 1)
            {
                throw new ArgumentException("Incorrect operator!");
            }
            return RightOperators.Contains(s);
        }

        public bool IsFunction(string s)
        {
            char function;
            char.TryParse(s, out function);
            return (function >= 'A' && function <= 'Z');
        }
    }
}
