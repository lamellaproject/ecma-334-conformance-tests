/*
Rules: P09-pattern-not
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Mutate: value is not null
Into: value is null
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
    static bool Present(object value) { return value is not null; }
    static int Main()
    {
        Check(Present(new object()), "reference-input");
        Check(Present(0), "boxed-value-input");
        Check(!Present(null), "complement-of-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
