using System.Collections.Generic;

namespace Calculator.Models
{
    public interface ISolver
    {
        string Solve(List<Token> input);
    }
}
