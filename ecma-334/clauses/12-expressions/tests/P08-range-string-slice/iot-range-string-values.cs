/*
Rules: P08-range-string-slice
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 10
Mutate: string suffix = text[^3..];
Into: string suffix = text[^2..];
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
    static int Main()
    {
        string text = "LAMPERA";
        string suffix = text[^3..];
        Range stored = 1..^2;
        Check(suffix == "ERA", "hat-start-omitted-end");
        Check(text[stored] == "AMPE", "stored-range");
        Check(text[1..5] == "AMPE", "exclusive-from-start-end");
        Check(text[..3] == "LAM", "omitted-start");
        Check(text[^5..^1] == "MPER", "both-from-end");
        Check(text[..] == text, "both-omitted");
        Check(text[3..3] == "", "interior-empty");
        Check(text[7..] == "", "past-end-empty");
        Check(text[^0..] == "", "from-end-zero-empty");
        Check(""[..] == "", "empty-receiver-empty-range");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
