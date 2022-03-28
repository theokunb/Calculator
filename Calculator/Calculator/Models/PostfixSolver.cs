using System.Collections.Generic;

namespace Calculator.Models
{
    public class PostfixSolver : ISolver
    {
        public PostfixSolver(List<Token> tokens)
        {
            stack = new Stack<Token>();
            operators = new List<Token>();
            foreach (var element in tokens)
                if (element.GetType().IsSubclassOf(typeof(Operator)))
                    operators.Add(element);

        }

        private readonly List<Token> operators;
        private Stack<Token> stack;


        public string Solve(List<Token> input)
        {
            foreach (var element in input)
            {
                if (element.GetType().Equals(typeof(Number)))
                    stack.Push(element);
                else if (operators.Exists(oper => oper == element))
                {
                    var firstPop = stack.Pop();
                    var secondPop = stack.Pop();
                    var currentOperator = operators.Find(oper => oper == element) as Operator;
                    stack.Push(currentOperator.Solve(secondPop, firstPop));
                }
            }
            return stack.Pop().Val;
        }
    }
}
