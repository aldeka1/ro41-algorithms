using System;

namespace SecondsConverter
{
    internal static class Program
    {
        private static void Main()
        {
            Console.Write("Введите количество секунд: ");
            string? input = Console.ReadLine();

            // Блок 1: проверка, что введено целое число
            if (!long.TryParse(input?.Trim(), out long n))
            {
                Console.WriteLine("Ошибка: введено не целое число.");
                return;
            }

            // Блок 2: проверка, что число не отрицательное
            if (n < 0)
            {
                Console.WriteLine("Ошибка: число секунд не может быть отрицательным.");
                return;
            }

            // Блок 3: вычисления
            long hours = n / 3600;
            long minutes = (n % 3600) / 60;
            long seconds = n % 60;

            // Блок 4: вывод результата
            Console.WriteLine($"{n} с = {hours} ч {minutes} мин {seconds} с");
        }
    }
}
