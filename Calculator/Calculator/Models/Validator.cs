using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Models
{
    public class Validator
    {
        public Validator(List<Token> tokenList)
        {
            rule = new Rule(tokenList);
        }

        private readonly Rule rule;

        public bool CanSolve => rule.IsLineValidToSolve();

        public bool CanAppend(string param, string line)
        {
            if (line.Length == 0)
                return rule.AllowFirst(param);
            else
            {
                char lastChar = line[line.Length - 1];
                return rule.AllowFollow(lastChar, param);
            }
        }
    }
}
