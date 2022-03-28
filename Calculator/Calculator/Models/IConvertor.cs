using System.Collections.Generic;

namespace Calculator.Models
{
    public interface IConvertor
    {
        List<Token> Convert(string input);
    }
}
