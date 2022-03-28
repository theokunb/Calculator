using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Models
{
    public class InputController
    {
        public InputController(string[] param)
        {
            commands = new Dictionary<string, ExecuteCommand>
            {
                { param[0], ClearLine },
                { param[1], RemoveLast }
            };
        }

        private delegate void ExecuteCommand();
        private readonly Dictionary<string, ExecuteCommand> commands;
        private string line = string.Empty;


        public string Line => line;

        private void ClearLine()
        {
            line = string.Empty;
        }

        private void RemoveLast()
        {
            if (line.Length > 0)
                line = line.Remove(line.Length - 1);
        }

        public void ApplyCommand(string parameter)
        {
            commands[parameter].Invoke();
        }
        public void Append(string param)
        {
            line += param;
        }
    }
}
