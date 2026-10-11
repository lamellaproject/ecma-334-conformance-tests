/*
Rules: E15-10-1-grammar-overloadable-unary-operator-not
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int operator !(Gauge a)
Into: int operator +(Gauge a)
*/
using System;
class Gauge { public int Value = 13; public static int operator !(Gauge a) { return a.Value + 9; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(!item == 22, "unary-not");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
