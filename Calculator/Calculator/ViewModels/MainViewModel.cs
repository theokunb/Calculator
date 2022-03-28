using Calculator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculator.ViewModels
{
    public class  MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            List<Token> myTokens = new List<Token>()
            {
                new AddOperator(),
                new SubOperator(),
                new MulOperator(),
                new DivOperator(),
                new LeftBkt(),
                new RightBkt(),
                new Models.Point()
            };
            for(int i = 0; i < 10; i++)
            {
                myTokens.Add(new Number(i.ToString()));
            }
            myCalculator = new MyCalculator(new PostfixConvertor(myTokens), new PostfixSolver(myTokens), new Validator(myTokens));

            inputController = new InputController(commandParameters);

            CommandPerformButton = new Command((param) => PerformButton(param.ToString()));
            CommandSolveButton = new Command((param) => SolveButton());
            CommandBkt = new Command((param) => PerformButtonBkt(param.ToString()));
        }

        private readonly MyCalculator myCalculator;
        private readonly InputController inputController;
        private static readonly string[] commandParameters = { "clear", "back"};
        private string result = string.Empty;

        public ICommand CommandPerformButton { get; }
        public ICommand CommandSolveButton { get; }
        public ICommand CommandBkt { get; }
        public string Result
        {
            get => result;
            set
            {
                if (result == value)
                    return;
                result = value;
                OnPropertyChanged();
            }
        }
        public string ClearParameter => commandParameters[0];
        public string BackParameter => commandParameters[1];
        public string Input => inputController.Line;

        private void InputChangedResetResult()
        {
            Result = string.Empty;
            OnPropertyChanged(nameof(Input));
        }

        private void PerformButton(string param)
        {
            if (commandParameters.Contains(param))
            {
                inputController.ApplyCommand(param);
                InputChangedResetResult();

            }
            else if (myCalculator.Validator.CanAppend(param, Input))
            {
                inputController.Append(param); 
                InputChangedResetResult();
            }
        }

        private void SolveButton()
        {
            if (myCalculator.Validator.CanSolve)
            {
                Result = myCalculator.ProcessExpression(Input);
            }
        }
        private void PerformButtonBkt(string param)
        {
            foreach(char bkt in param)
            {
                if (myCalculator.Validator.CanAppend(bkt.ToString(), Input))
                {
                    inputController.Append(bkt.ToString());
                    InputChangedResetResult();
                    return;
                }
            }
        }
    }
}
