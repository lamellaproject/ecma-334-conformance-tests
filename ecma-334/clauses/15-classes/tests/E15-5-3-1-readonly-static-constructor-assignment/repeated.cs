/*
Rules: E15-5-3-1-readonly-static-constructor-assignment; E15-5-3-1-readonly-multiple-assignments
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: static Holder()
Into: static void Reset()
*/
using System;
class Holder
{
    public static readonly int Code = 43;
    public static int Initial, Intermediate;
    static Holder()
    {
        Initial = Code;
        Code = 61;
        Intermediate = Code;
        Code = 79;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.Initial == 43, "readonly-value-before-static-constructor-assignment");
        Check(Holder.Intermediate == 61, "readonly-value-after-first-static-constructor-assignment");
        Check(Holder.Code == 79, "readonly-value-after-second-static-constructor-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
