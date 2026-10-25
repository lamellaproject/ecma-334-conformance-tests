/*
Rules: P08-shadow-nested-local
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: item is int code
Into: item is int other
*/
using System;
// Draft-v8 7.3 L85 and alpha-v13 7.2 L161 retain the old prohibition.
// Csc is the authority for the C#8 nested-function exception.
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int code = 3;
        int Read(object item) { if (item is int code) return code; return 0; }
        Check(Read(17) == 17, "pattern-variable-hides-outer");
        Check(Read("x") == 0, "nonmatching-input");
        Check(code == 3, "outer-value-preserved");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
