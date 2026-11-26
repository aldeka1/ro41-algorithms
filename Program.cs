using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("BubbleSort");
Console.WriteLine();

int[][] sortCases =
{
    new int[] { },
    new int[] { 5 },
    new int[] { 1, 2, 3, 4, 5 },
    new int[] { 5, 4, 3, 2, 1 },
    new int[] { 3, 1, 3, 2, 3 }
};

foreach (int[] a in sortCases)
{
    string before = Format(a);
    bool sortedBefore = ArrayAlgos.IsSorted(a);
    int comparisons = ArrayAlgos.BubbleSort(a);
    bool sortedAfter = ArrayAlgos.IsSorted(a);

    Console.WriteLine($"Массив до: {before}");
    Console.WriteLine($"Массив после: {Format(a)}");
    Console.WriteLine($"IsSorted до: {sortedBefore}, после: {sortedAfter}");
    Console.WriteLine($"Сравнений: {comparisons}");
    Console.WriteLine();
}

int[] big = new int[1000];
for (int i = 0; i < big.Length; i++)
{
    big[i] = i;
}
int bigComparisons = ArrayAlgos.BubbleSort(big);
Console.WriteLine($"Отсортированный массив из 1000 элементов: сравнений {bigComparisons}, ожидается 999");
Console.WriteLine();

Console.WriteLine("CountOccurrences");
Console.WriteLine();

int[] sortedA = { 1, 2, 2, 2, 5, 7 };
int[] xs = { 2, 1, 7, 3, 9 };
int[] expected = { 3, 1, 1, 0, 0 };

Console.WriteLine($"Массив: {Format(sortedA)}");
for (int i = 0; i < xs.Length; i++)
{
    int result = ArrayAlgos.CountOccurrences(sortedA, xs[i]);
    Console.WriteLine($"x = {xs[i]}: {result}, ожидается {expected[i]}");
}

static string Format(int[] a)
{
    return "{" + string.Join(", ", a) + "}";
}

static class ArrayAlgos
{
    public static bool IsSorted(int[] a)
    {
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i - 1] > a[i])
            {
                return false;
            }
        }
        return true;
    }

    public static int BubbleSort(int[] a)
    {
        int comparisons = 0;
        for (int pass = 0; pass < a.Length - 1; pass++)
        {
            bool swapped = false;
            for (int j = 0; j < a.Length - 1 - pass; j++)
            {
                comparisons++;
                if (a[j] > a[j + 1])
                {
                    int t = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = t;
                    swapped = true;
                }
            }
            if (!swapped)
            {
                break;
            }
        }
        return comparisons;
    }

    public static int CountOccurrences(int[] sortedA, int x)
    {
        int first = LowerBound(sortedA, x);
        int after = UpperBound(sortedA, x);
        return after - first;
    }

    private static int LowerBound(int[] a, int x)
    {
        int lo = 0;
        int hi = a.Length;
        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (a[mid] >= x)
            {
                hi = mid;
            }
            else
            {
                lo = mid + 1;
            }
        }
        return lo;
    }

    private static int UpperBound(int[] a, int x)
    {
        int lo = 0;
        int hi = a.Length;
        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (a[mid] > x)
            {
                hi = mid;
            }
            else
            {
                lo = mid + 1;
            }
        }
        return lo;
    }
}
