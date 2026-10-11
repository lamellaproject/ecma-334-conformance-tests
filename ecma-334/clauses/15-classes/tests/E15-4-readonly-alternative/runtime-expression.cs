/*
Rules: E15-4-readonly-alternative
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public static readonly int Code = Compute();
Into: public const int Code = Compute();
*/
using System;
class Limits
{
    public static readonly int Code = Compute();
    static int Compute() { return 113; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Limits.Code == 113, "readonly-value-from-runtime-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
