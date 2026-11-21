using System;

namespace Lab3_4
{    public class OverflowEventArgs : EventArgs
    {
        public string OperationName { get; }
        public int FirstOperand { get; }
        public int SecondOperand { get; }
        public string Message { get; }

        public OverflowEventArgs(string operationName, int a, int b, string message)
        {
            OperationName = operationName;
            FirstOperand = a;
            SecondOperand = b;
            Message = message;
        }
    }
}