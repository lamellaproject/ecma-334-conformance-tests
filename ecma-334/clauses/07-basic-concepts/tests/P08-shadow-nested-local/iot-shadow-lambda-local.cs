/*
Rules: P08-shadow-nested-local
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: int load = 19;
Into: int cargo = 19;
*/
using System;
// Draft-v8 7.3 L85 and alpha-v13 7.2 L161 retain the old nested-name ban.
// The registered csc implements the C#8 exception for nested functions.
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
        int load = 3;
        Func<int> read = () => { int load = 19; return load; };
        Check(read() == 19, "inner-lambda-local");
        Check(load == 3, "outer-local-preserved");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
