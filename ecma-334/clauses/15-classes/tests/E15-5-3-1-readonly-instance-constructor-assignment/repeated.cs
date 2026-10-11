/*
Rules: E15-5-3-1-readonly-instance-constructor-assignment; E15-5-3-1-readonly-multiple-assignments
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Code = 31;
Into: Code = 37;
*/
using System;
class Holder
{
    public readonly int Code = 13;
    public int Initial, Intermediate;
    public Holder()
    {
        Initial = Code;
        Code = 17;
        Intermediate = Code;
        Code = 31;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Initial == 13, "readonly-value-before-constructor-assignment");
        Check(value.Intermediate == 17, "readonly-value-after-first-constructor-assignment");
        Check(value.Code == 31, "readonly-value-after-second-constructor-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
