/*
Rules: E15-5-3-1-readonly-instance-constructor-ref
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public Holder()
Into: public void Reset()
*/
using System;
class Holder
{
    public readonly int Code = 49;
    public Holder() { Add(ref Code); }
    static void Add(ref int value) { value += 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Code == 51, "readonly-ref-in-declaring-instance-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
