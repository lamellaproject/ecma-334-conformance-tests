/*
Rules: P08-recursive-positional-tuples
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: (17, var text, (3, 8))
Into: (18, var text, (3, 8))
*/
using System;
class Program
{
    static int checks, failures, calls;
    static (int, string, (int, int)) Take() { calls++; return (17, "birch", (3, 8)); }
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        calls = 0;
        Check(Take() is (17, var text, (3, 8)) && text == "birch" && calls == 1, "nested-tuple-single-input");
        (int key, int value) pair = (31, 9);
        Check(pair is (key: 31, value: 9), "tuple-corresponding-names");
        Check(!(pair is (31, 10)), "tuple-element-mismatch");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
