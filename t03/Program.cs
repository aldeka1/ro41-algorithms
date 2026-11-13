using System;
using System.Text;

namespace Gcd
{
    internal static class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Блок "Ввод a, b"
            Console.WriteLine("Введите a:");
            string? sa = Console.ReadLine();
            Console.WriteLine("Введите b:");
            string? sb = Console.ReadLine();

            // Решение 1: a и b - целые числа?
            if (!long.TryParse(sa?.Trim(), out long a) || !long.TryParse(sb?.Trim(), out long b))
            {
                Console.WriteLine("Ошибка: введены не целые числа.");
                return;
            }

            // Решение 2: a >= 0 и b >= 0?
            if (a < 0 || b < 0)
            {
                Console.WriteLine("Ошибка: числа должны быть неотрицательными.");
                return;
            }

            // Решение 3: a = 0 и b = 0?
            if (a == 0 && b == 0)
            {
                Console.WriteLine("Ошибка: оба числа равны нулю.");
                return;
            }

            // Решение 4 (цикл с предусловием): b != 0?
            while (b != 0)
            {
                long r = a % b;
                a = b;
                b = r;
            }

            // Блок "Вывод a"
            Console.WriteLine($"НОД = {a}");
        }
    }
}
