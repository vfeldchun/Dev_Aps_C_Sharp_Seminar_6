

namespace Task1
{
    internal class CalculatorDivideByZeroException : CalculatorException
    {
        public CalculatorDivideByZeroException(string message, Stack<CalculatorActionLog> actionLogs) : base(message, actionLogs)
        { }

        public CalculatorDivideByZeroException(string message, Exception e, Stack<CalculatorActionLog> actionLogs) : base(message, e, actionLogs)
        { }
    }
}
