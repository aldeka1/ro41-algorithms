Check(3, 1, 2);
Check(1, 2, 3);
Check(3, 2, 1);
Check(2, 2, 1);
Check(5, 5, 5);

// Сортирует тройку и печатает строку вида "3 1 2 -> 1 2 3"
static void Check(int a, int b, int c)
{
    string before = $"{a} {b} {c}";
    Order.Sort3(ref a, ref b, ref c);
    Console.WriteLine($"{before} -> {a} {b} {c}");
}

static class Order
{
    // Меняет местами значения двух переменных.
    public static void Swap(ref int x, ref int y)
    {
        int t = x;
        x = y;
        y = t;
    }

    // Упорядочивает три числа по возрастанию, используя только Swap.
    public static void Sort3(ref int a, ref int b, ref int c)
    {
        if (a > b) Swap(ref a, ref b);
        if (b > c) Swap(ref b, ref c);
        if (a > b) Swap(ref a, ref b);
    }
}
