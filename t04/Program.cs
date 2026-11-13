using System.Globalization;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

int count = 0;
int sum = 0;
int fives = 0;

Console.WriteLine($"Введите оценки ({Grades.Min}-{Grades.Max}), {Grades.Stop} - конец:");

int g = Grades.Read();
while (g != Grades.Stop)
{
    bool ok = Grades.IsValid(g);
    if (ok)
    {
        count++;
        sum += g;
        if (g == Grades.Max)
        {
            fives++;
        }
    }
    else
    {
        Console.WriteLine($"Некорректная оценка, нужно число от {Grades.Min} до {Grades.Max}.");
    }
    g = Grades.Read();
}

Grades.PrintStats(count, sum, fives);

static class Grades
{
    public const int Min = 2;
    public const int Max = 5;
    public const int Stop = 0;

    // Читает оценку. Нечисловой ввод возвращает как -1.
    // Конец входного потока (null) считаем сигналом остановки.
    public static int Read()
    {
        string? line = Console.ReadLine();
        if (line == null)
        {
            return Stop;
        }
        return int.TryParse(line.Trim(), out int value) ? value : -1;
    }

    // Оценка допустима, если она от Min до Max.
    public static bool IsValid(int g)
    {
        return g >= Min && g <= Max;
    }

    // Выводит итог или "Оценок нет".
    public static void PrintStats(int count, int sum, int fives)
    {
        if (count == 0)
        {
            Console.WriteLine("Оценок нет");
            return;
        }
        double avg = (double)sum / count;
        string avgText = avg.ToString("F2", CultureInfo.InvariantCulture);
        Console.WriteLine($"Оценок: {count}, средний балл: {avgText}, пятёрок: {fives}");
    }
}
