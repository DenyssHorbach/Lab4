using System;

namespace Lab3_4
{
    public delegate long MatrixSumDelegate(int[,] matrix);

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[,] matrix = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            MatrixSumDelegate sumAnonymous = delegate (int[,] arr)
            {
                long sum = 0;
                foreach (int item in arr)
                    sum += item;
                return sum;
            };

            MatrixSumDelegate sumLambda = (arr) =>
            {
                long sum = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        sum += arr[i, j];
                return sum;
            };

            Console.WriteLine("Делегати");
            Console.WriteLine($"Сума елементів матриці: {sumAnonymous(matrix)}");
            Console.WriteLine($"Сума елементів матриці: {sumLambda(matrix)}");

            Console.WriteLine("\nПодії (Арифметика та переповнення)");
            
            IntegerArithmetic calculator = new IntegerArithmetic("Int32_Calculator");
            OverflowHandler handler = new OverflowHandler();

            calculator.GridOverflow += handler.HandleOverflow;


            Console.WriteLine($"100 + 250 = {calculator.Add(100, 250)}");


            calculator.Add(int.MaxValue, 10);
            calculator.Subtract(int.MinValue, 5);
            calculator.Multiply(100_000, 50_000);

            calculator.GridOverflow -= handler.HandleOverflow;
        }
    }
}