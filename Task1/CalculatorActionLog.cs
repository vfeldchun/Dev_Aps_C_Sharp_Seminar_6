

namespace Task1
{
    internal class CalculatorActionLog
    {
        public CalculatorActionLog(CalculatorAction calculatorActions, int calcArgument)
        {
            CalculatorAction = calculatorActions;
            CalcArgument = (double)calcArgument;
        }

        public CalculatorActionLog(CalculatorAction calculatorActions, double calcArgument)
        {
            CalculatorAction = calculatorActions;
            CalcArgument = calcArgument;
        }

        public CalculatorAction CalculatorAction { get; private set; }
        public double CalcArgument { get; private set; }        
    }
}
