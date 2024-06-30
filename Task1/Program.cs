namespace Task1
{
    internal class Program
    {
        static void Calculator_GotResult(object sender, EventArgs e)
        {
            Console.WriteLine($"Результат: {((Calculator)sender).Args.Result}");
        }

        static void Execute<T>(Action<T> action, T value)
        {       

            try
            {
                action?.Invoke(value);
            }
            catch (CalculatorDivideByZeroException ex)
            {
                Console.WriteLine(ex);
            }
            catch (CalculateOperationCauseOverflowException ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void Main(string[] args)
        {
            ICalculator calc = new Calculator();
            calc.GotResult += Calculator_GotResult;

            Execute(calc.Add, 5000);
            Execute(calc.Multiply, double.MaxValue);
            Execute(calc.Subtract, 4.0);
            Execute(calc.Multiply, 12);
            Execute(calc.Divide, 0.0);


        }
    }
}
