using System.Text;

Console.OutputEncoding = Encoding.UTF8;

int total = 0;
int failed = 0;

Check("CountWords(\"\")", 0, TextTools.CountWords(""));
Check("CountWords(\"   \")", 0, TextTools.CountWords("   "));
Check("CountWords(\" a  b \")", 2, TextTools.CountWords(" a  b "));
Check("CountWords(\"А роза упала на лапу Азора\")", 6, TextTools.CountWords("А роза упала на лапу Азора"));
Check("CountWords(\"Ахметов Ерлан\")", 2, TextTools.CountWords("Ахметов Ерлан"));
Check("IsPalindrome(\"\")", true, TextTools.IsPalindrome(""));
Check("IsPalindrome(\"   \")", true, TextTools.IsPalindrome("   "));
Check("IsPalindrome(\" a  b \")", false, TextTools.IsPalindrome(" a  b "));
Check("IsPalindrome(\"А роза упала на лапу Азора\")", true, TextTools.IsPalindrome("А роза упала на лапу Азора"));
Check("IsPalindrome(\"Ахметов Ерлан\")", false, TextTools.IsPalindrome("Ахметов Ерлан"));
Check("Initials(\"\")", "", TextTools.Initials(""));
Check("Initials(\"   \")", "", TextTools.Initials("   "));
Check("Initials(\" a  b \")", "A. B.", TextTools.Initials(" a  b "));
Check("Initials(\"А роза упала на лапу Азора\")", "А. Р. У. Н. Л. А.", TextTools.Initials("А роза упала на лапу Азора"));
Check("Initials(\"Ахметов Ерлан\")", "А. Е.", TextTools.Initials("Ахметов Ерлан"));
Check("Initials(\"Ахметов Ерлан Серикұлы\")", "А. Е. С.", TextTools.Initials("Ахметов Ерлан Серикұлы"));
Check("Repeat(\"\", 2)", "", TextTools.Repeat("", 2));
Check("Repeat(\"   \", 2)", "      ", TextTools.Repeat("   ", 2));
Check("Repeat(\" a  b \", 2)", " a  b  a  b ", TextTools.Repeat(" a  b ", 2));
Check("Repeat(\"А роза упала на лапу Азора\", 2)", "А роза упала на лапу АзораА роза упала на лапу Азора", TextTools.Repeat("А роза упала на лапу Азора", 2));
Check("Repeat(\"Ахметов Ерлан\", 2)", "Ахметов ЕрланАхметов Ерлан", TextTools.Repeat("Ахметов Ерлан", 2));
Check("Repeat(\"ab\", 3)", "ababab", TextTools.Repeat("ab", 3));
Check("Repeat(\"ab\", 0)", "", TextTools.Repeat("ab", 0));

Console.WriteLine($"Итого: {total - failed} из {total} OK");

void Check<T>(string call, T expected, T actual)
{
    bool ok = EqualityComparer<T>.Default.Equals(expected, actual);
    total++;
    if (!ok)
    {
        failed++;
    }
    Console.WriteLine($"{call} | ожидается: {Show(expected)} | фактически: {Show(actual)} | {(ok ? "OK" : "FAIL")}");
}

string Show<T>(T value)
{
    if (value is string str)
    {
        return "\"" + str + "\"";
    }
    return value?.ToString() ?? "null";
}

static class TextTools
{
    public static int CountWords(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }
        int count = 0;
        bool inWord = false;
        foreach (char c in s)
        {
            if (char.IsWhiteSpace(c))
            {
                inWord = false;
            }
            else if (!inWord)
            {
                inWord = true;
                count++;
            }
        }
        return count;
    }

    public static bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            while (i < j && char.IsWhiteSpace(s[i]))
            {
                i++;
            }
            while (i < j && char.IsWhiteSpace(s[j]))
            {
                j--;
            }
            if (char.ToLowerInvariant(s[i]) != char.ToLowerInvariant(s[j]))
            {
                return false;
            }
            i++;
            j--;
        }
        return true;
    }

    public static string Initials(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return "";
        }
        StringBuilder sb = new StringBuilder();
        bool inWord = false;
        foreach (char c in fullName)
        {
            if (char.IsWhiteSpace(c))
            {
                inWord = false;
            }
            else if (!inWord)
            {
                inWord = true;
                if (sb.Length > 0)
                {
                    sb.Append(' ');
                }
                sb.Append(char.ToUpperInvariant(c));
                sb.Append('.');
            }
        }
        return sb.ToString();
    }

    public static string Repeat(string s, int n)
    {
        if (string.IsNullOrEmpty(s) || n <= 0)
        {
            return "";
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.Append(s);
        }
        return sb.ToString();
    }
}
