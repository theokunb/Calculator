namespace Calculator.Models
{
    public class MyCalculator
    {
        public MyCalculator(IConvertor convertor, ISolver solver, Validator validator)
        {
            this.convertor = convertor;
            this.solver = solver;
            this.validator = validator;
        }

        private readonly IConvertor convertor;
        private readonly ISolver solver;
        private readonly Validator validator;

        public Validator Validator => validator;
        public string ProcessExpression(string input)
        {
            var postfixForm = convertor.Convert(input);
            var result = solver.Solve(postfixForm);
            return result;
        }
    }
}
