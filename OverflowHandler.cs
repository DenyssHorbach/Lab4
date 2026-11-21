using System;

namespace Lab3_4
{
    public class OverflowHandler
    {
        public void HandleOverflow(object? sender, OverflowEventArgs e)
        {
            string senderName = (sender is IntegerArithmetic calc) ? calc.CalculatorName : "Невідоме джерело";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[ПОДІЯ ПЕРЕПОВНЕННЯ] Ініціатор: {senderName}");
            Console.WriteLine($"Операція: {e.OperationName} (операнди: {e.FirstOperand} та {e.SecondOperand})");
            Console.WriteLine($"Деталі: {e.Message}");
            Console.ResetColor();
        }
    }
}