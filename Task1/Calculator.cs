
namespace Task1
{
    internal class Calculator : ICalculator
    {
        public event EventHandler<EventArgs>? GotResult;

        public CalculatorEventArgs Args { get;  private set; }

        public Calculator() => Args = new CalculatorEventArgs();

        private Stack<double> _stackValues = new Stack<double>();
        private Stack<CalculatorActionLog> _actionsStack = new Stack<CalculatorActionLog>();

        public void Add(int value)
        {
            _actionsStack.Push(new CalculatorActionLog(CalculatorAction.Add, value));

            if (Args.Result + value == double.PositiveInfinity)
                throw new CalculateOperationCauseOverflowException("Операция переполнения", _actionsStack);

            _stackValues.Push(Args.Result);            
            Args.Result += value;
            RaiseEvent(Args);            
        }

        public void Add(double value)
        {            
            _actionsStack.Push(new CalculatorActionLog(CalculatorAction.Add, value));

            if (Args.Result + value == double.PositiveInfinity)
                throw new CalculateOperationCauseOverflowException("Операция переполнения", _actionsStack);

            _stackValues.Push(Args.Result);
            Args.Result += value;
            RaiseEvent(Args);
        }

        public void Divide(int value)
        {            
            _actionsStack.Push(new CalculatorActionLog(CalculatorAction.Divide, value));

            if (value == 0)
            {                
                throw new CalculatorDivideByZeroException("Операция деления на 0", _actionsStack);
            }

            if (Args.Result / value == double.NegativeInfinity)
                throw new CalculateOperationCauseOverflowException("Операция переполнения", _actionsStack);

            _stackValues.Push(Args.Result);            
            Args.Result /= value;
            RaiseEvent(Args);            
        }

        public void Divide(double value)
        {
            _actionsStack.Push(new CalculatorActionLog(CalculatorAction.Divide, value));

            if (value == 0.0)
            {
                throw new CalculatorDivideByZeroException("Операция деления на 0", _actionsStack);
            }

            if (Args.Result / value == double.NegativeInfinity)
                throw new CalculateOperationCauseOverflowException("Операция переполнения", _actionsStack);


            _stackValues.Push(Args.Result);
            Args.Result /= value;
            RaiseEvent(Args);
        }

        public void Multiply(int value)
        {
            _actionsStack.Push(new CalculatorActionLog(CalculatorAction.Multiply, value));

            if (Args.Result * value == double.PositiveInfinity || Args.Result * value == double.NegativeInfinity)
                throw new CalculateOperationCauseOverflowException("Операция переполнения", _actionsStack);

            _stackValues.Push(Args.Result);            
            Args.Result *= value;
            RaiseEvent(Args);            
        }

        public void Multiply(double value)
        {           
            _actionsStack.Push(new CalculatorActionLog(CalculatorAction.Multiply, value));

            if (Args.Result * value == double.PositiveInfinity || Args.Result * value == double.NegativeInfinity)
                throw new CalculateOperationCauseOverflowException("Операция переполнения", _actionsStack);            

            _stackValues.Push(Args.Result);
            Args.Result *= value;
            RaiseEvent(Args);
        }
        
        public void Subtract(int value)
        {            
            _actionsStack.Push(new CalculatorActionLog(CalculatorAction.Subtract, value));

            if (Args.Result - value == double.PositiveInfinity || Args.Result - value == double.NegativeInfinity)
                throw new CalculateOperationCauseOverflowException("Операция переполнения", _actionsStack);

            _stackValues.Push(Args.Result);            
            Args.Result -= value;
            RaiseEvent(Args);            
        }

        public void Subtract(double value)
        {            
            _actionsStack.Push(new CalculatorActionLog(CalculatorAction.Subtract, value));

            if (Args.Result - value == double.PositiveInfinity || Args.Result - value == double.NegativeInfinity)
                throw new CalculateOperationCauseOverflowException("Операция переполнения", _actionsStack);

            _stackValues.Push(Args.Result);
            Args.Result -= value;
            RaiseEvent(Args);
        }

        public void CancelLast()
        {
            if (this._stackValues.Count > 0) this.Args.Result = _stackValues.Pop();
            RaiseEvent(Args);
        }

        private void RaiseEvent(EventArgs args)
        {
            GotResult?.Invoke(this, args);
        }
    }
}
