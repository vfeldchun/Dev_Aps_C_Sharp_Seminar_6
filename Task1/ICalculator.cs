

namespace Task1
{
    internal interface ICalculator
    {
        event EventHandler<EventArgs> GotResult;

        public void Add(int value);
        public void Add(double value);
        public void Subtract(int value);
        public void Subtract(double value);
        public void Multiply(int value);
        public void Multiply(double value);
        public void Divide(int value);
        public void Divide(double value);
        public void CancelLast();

    }
}
