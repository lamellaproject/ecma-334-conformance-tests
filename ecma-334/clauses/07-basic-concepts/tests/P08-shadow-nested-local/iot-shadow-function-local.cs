/*
Rules: P08-shadow-nested-local
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: int load = 23;
Into: int cargo = 23;
*/
using System;
// The C#8 nested-function exception is absent from draft-v8 7.3 L85 and
// alpha-v13 7.2 L161. This later-feature test follows registered csc.
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
        int load = 5;
        int Read() { int load = 23; return load; }
        Check(Read() == 23, "inner-function-local");
        Check(load == 5, "outer-function-local");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
