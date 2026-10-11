/*
Rules: E15-4-constant-expression-use
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const int Width = 17;
Into: public static readonly int Width = 17;
*/
using System;
class Limits
{
    public const int Width = 17;
    public const int Area = Width * Width;
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Limits.Area == 289, "constant-used-in-constant-initializer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
