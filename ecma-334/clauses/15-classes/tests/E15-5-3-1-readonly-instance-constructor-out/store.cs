/*
Rules: E15-5-3-1-readonly-instance-constructor-out
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
    public readonly int Code;
    public Holder() { Store(out Code); }
    static void Store(out int value) { value = 67; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Code == 67, "readonly-out-in-declaring-instance-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
