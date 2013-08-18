using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    class InfixNotationTransformer
    {
        private readonly Tokens _tokens = new Tokens();
        private readonly Queue<string> _output = new Queue<string>();
        private readonly Stack<string> _operators = new Stack<string>();

        public string Transform(string currentExpression)
        {
            List<string> tokens = currentExpression.Split(new[] { ' ' }).ToList();
            foreach (string token in tokens)
            {
                if (_tokens.IsNumber(token))
                {
                    _output.Enqueue(token);
                }
                else if (_tokens.IsFunction(token))
                {
                    _operators.Push(token);
                }
                else if (token.Equals(","))
                {
                    while (_operators.Count > 0 && _operators.Peek() != "(")
                    {
                        string topOperator = _operators.Pop();
                        _output.Enqueue(topOperator);
                    }
                }
                else if (_tokens.IsOperator(token))
                {
                    while (_operators.Count > 0 && _tokens.IsOperator(_operators.Peek()))
                    {
                        if ((_tokens.IsLeftAssociative(token) && _operators.Count > 0
                            && (_tokens.GetPrecedenceFor(token) <= _tokens.GetPrecedenceFor(_operators.Peek())))
                            || (_tokens.IsRightAssociative(token) 
                            && (_tokens.GetPrecedenceFor(token) < _tokens.GetPrecedenceFor(_operators.Peek()))))
                        {
                            string operatorToReturn = _operators.Pop();
                            _output.Enqueue(operatorToReturn);
                        }
                        else break;
                    }
                    _operators.Push(token);
                }
                if (token.Equals("("))
                {
                    _operators.Push(token);
                }
                if (token.Equals(")"))
                {
                    while (_operators.Count > 0 && _operators.Peek() != "(")
                    {
                        _output.Enqueue(_operators.Pop());
                    }
                    _operators.Pop();
                }
                if (_operators.Count > 0 && _operators.Count > 0 && _tokens.IsFunction(_operators.Peek()))
                {
                    _output.Enqueue(_operators.Pop());
                }
            }
            while (_operators.Count > 0 && _tokens.IsOperator(_operators.Peek()))
            {
                _output.Enqueue(_operators.Pop());
            }
            string transformedString = string.Empty;
            while (_output.Count > 0)
            {
                transformedString += _output.Dequeue() + " ";
            }
            return transformedString.TrimEnd();
        }
    }
}
