/*
Rules: E15-5-3-1-readonly-static-constructor-ref
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
    public static readonly int Code = 73;
    static Holder() { Add(ref Code); }
    static void Add(ref int value) { value += 3; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.Code == 76, "readonly-ref-in-declaring-static-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
