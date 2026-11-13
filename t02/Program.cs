using System;

namespace DigitsCounter
{
    internal static class Program
    {
        private static void Main()
        {
            Console.Write("Введите целое число n (n >= 0): ");
            string? input = Console.ReadLine();

            // Проверка: введено ли целое число
            if (!long.TryParse(input?.Trim(), out long n))
            {
                Console.WriteLine("Ошибка: введено не целое число.");
                return;
            }

            // Проверка: число не отрицательное
            if (n < 0)
            {
                Console.WriteLine("Ошибка: число не может быть отрицательным.");
                return;
            }

            long original = n;
            long sum = 0;
            int count = 0;

            // do-while: тело выполняется минимум один раз, поэтому у числа 0 одна цифра
            do
            {
                long digit = n % 10;
                sum += digit;
                count++;
                n /= 10;
            } while (n > 0);

            Console.WriteLine($"Число {original}: цифр = {count}, сумма цифр = {sum}");
        }
    }
}
