/*
Rules: E20-2-modifier-unsafe
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unsafe delegate int Read(int* value);
Into: delegate int Read(int* value);
*/
using System;
unsafe delegate int Read(int* value);
class Program
{
    static int checks, failures;
    static unsafe int Dereference(int* value) { return *value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 43;
        Read reader = Dereference;
        Check(reader(&value) == 43, "unsafe-delegate-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
