using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для расчета арифметических операций для двух чисел");
            Console.WriteLine("1 - Сложить");
            Console.WriteLine("2 - Вычесть");
            Console.WriteLine("3 - Умножить");
            Console.WriteLine("4 - Поделить");

            Console.Write("\nВыберите вариант: ");
            char option = Convert.ToChar(Console.ReadLine());

            Console.Write("\n\nВведите число A: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число B: ");
            int b = Convert.ToInt32(Console.ReadLine());

            if (option == '1')
            {
                Console.WriteLine("A + B = " + (a + b));
            }

            if (option == '2')
            {
                Console.WriteLine("A - B = " + (a - b));
            }

            if (option == '3')
            {
                Console.WriteLine("A * B = " + (a * b));
            }

            if (option == '4')
            {
                Console.WriteLine("A / B = " + (a / b));
            }
        }
    }
}
