/*
Rules: P08-range-string-bounds
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 6
Mutate: string slice = text[2..1];
Into: string slice = text[2..3];
*/
using System;
class Test
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static bool Invalid(Range range)
    {
        try { string value = "LAMPERA"[range]; return value.Length < 0; }
        catch (ArgumentOutOfRangeException) { return true; }
    }
    static int Main()
    {
        string text = "LAMPERA";
        bool reversed = false;
        try { string slice = text[2..1]; reversed = slice.Length < 0; }
        catch (ArgumentOutOfRangeException) { reversed = true; }
        Check(reversed, "direct-reversed-range");
        Check(Invalid(8..8), "start-past-length");
        Check(Invalid(1..8), "end-past-length");
        Check(Invalid(^8..), "from-end-start-before-zero");
        Check(Invalid(..^8), "from-end-end-before-zero");
        Check(Invalid(^1..^3), "stored-reversed-from-end-range");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
