/*
Rules: E8-3-3-integral-default
Authority: ECMA-334 7th ed 8.3.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: byte constructed = new byte();
Into: byte constructed = 1;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        byte constructed = new byte();
        byte expression = default(byte);
        Check(constructed == 0, "byte-default-constructor-zero");
        Check(expression == 0, "byte-default-expression-zero");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
