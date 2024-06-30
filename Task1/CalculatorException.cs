
using System.Text;

namespace Task1
{
    internal class CalculatorException : Exception
    {
        public Stack<CalculatorActionLog> ActionLogs { get; private set; }

        public CalculatorException(string message, Stack<CalculatorActionLog> actionLogs) : base(message)
        {
            ActionLogs = actionLogs;
        }

        public CalculatorException(string message, Exception e, Stack<CalculatorActionLog> actionLogs) : base(message, e)
        {
            ActionLogs = actionLogs;
        }

        public override string ToString()   
        {            
            return $"\n" + base.ToString() + "\n\n" + string.Join("\n", ActionLogs.Select(x => $"{x.CalculatorAction} {x.CalcArgument}"));
        }
    }
}
