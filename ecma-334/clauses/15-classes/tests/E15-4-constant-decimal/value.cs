/*
Rules: E15-4-constant-decimal
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const decimal Amount = 135.625m;
Into: public const decimal Amount = 135.626m;
*/
using System;
class Limits { public const decimal Amount = 135.625m; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(decimal value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Amount) == 1, "decimal-constant-type");
        Check(Limits.Amount == 135.625m, "decimal-constant-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
