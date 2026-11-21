using System;

namespace Lab3_4
{
    public class IntegerArithmetic
    {
        public string CalculatorName { get; }

        public event EventHandler<OverflowEventArgs>? GridOverflow;

        public IntegerArithmetic(string name)
        {
            CalculatorName = name;
        }

        protected virtual void OnGridOverflow(OverflowEventArgs e)
        {
            GridOverflow?.Invoke(this, e);
        }

        public int Add(int a, int b)
        {
            try
            {
                // Блок checked змушує C# генерувати OverflowException при виході за межі int
                return checked(a + b);
            }
            catch (OverflowException)
            {
                OnGridOverflow(new OverflowEventArgs("Додавання", a, b, $"Сума {a} + {b} перевищує межі типу int."));
                return 0;
            }
        }

        public int Subtract(int a, int b)
        {
            try
            {
                return checked(a - b);
            }
            catch (OverflowException)
            {
                OnGridOverflow(new OverflowEventArgs("Віднімання", a, b, $"Різниця {a} - {b} виходить за межі типу int."));
                return 0;
            }
        }

        public int Multiply(int a, int b)
        {
            try
            {
                return checked(a * b);
            }
            catch (OverflowException)
            {
                OnGridOverflow(new OverflowEventArgs("Множення", a, b, $"Добуток {a} * {b} перевищує межі типу int."));
                return 0;
            }
        }
    }
}