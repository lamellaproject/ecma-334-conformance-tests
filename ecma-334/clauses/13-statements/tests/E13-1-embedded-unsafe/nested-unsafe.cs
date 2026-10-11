/*
Rules: E13-1-embedded-unsafe
Authority: ECMA-334 7th ed 13.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: *pointer = 11;
Into: *pointer = 10;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int mark = 0;
        if (true) unsafe { int value = 4; int* pointer = &value; *pointer = 11; mark = value; }
        Check(mark == 11, "embedded-unsafe-block");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
