/*
Rules: E15-5-3-1-readonly-static-constructor-out
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static Holder()
Into: static void Reset()
*/
using System;
class Holder
{
    public static readonly int Code;
    static Holder() { Store(out Code); }
    static void Store(out int value) { value = 89; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.Code == 89, "readonly-out-in-declaring-static-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
