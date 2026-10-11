/*
Rules: E15-1-constant-members
Authority: ECMA-334 7th ed 15.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const int Limit = 29;
Into: public static int Limit = 29;
*/
using System;
class Meter
{
    public const int Limit = 29;
}
class Program
{
    const int Copied = Meter.Limit;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Copied == 29, "class-constant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
