/*
Rules: P09-pattern-relational
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 7
Mutate: return value is >= 12;
Into: return value is > 12;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static bool AtLeast(int value) { return value is >= 12; }
    static int Main()
    {
        Check(!AtLeast(11), "below-boundary");
        Check(AtLeast(12), "inclusive-boundary");
        Check(AtLeast(13), "above-boundary");
        char letter = 'm';
        Check(letter is < 'n', "character-comparison");
        double number = 2.5;
        Check(number is <= 2.5, "floating-inclusive");
        number = double.NaN;
        Check(!(number is > 0.0), "nan-input");
        long wide = 4000000000L;
        Check(wide is > 3000000000L, "wide-integer");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
