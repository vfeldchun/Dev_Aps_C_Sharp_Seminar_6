

namespace Task1
{
    internal class CalculateOperationCauseOverflowException : CalculatorException
    {
        public CalculateOperationCauseOverflowException(string message, Stack<CalculatorActionLog> actionLogs) : base(message, actionLogs)
        { }

        public CalculateOperationCauseOverflowException(string message, Exception e, Stack<CalculatorActionLog> actionLogs) : base(message, e, actionLogs)
        { }
    }
}
