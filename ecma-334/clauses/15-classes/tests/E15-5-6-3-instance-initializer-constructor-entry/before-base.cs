/*
Rules: E15-5-6-3-instance-initializer-constructor-entry
Authority: ECMA-334 7th ed 15.5.6.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public int Value = Trace.Mark(6);
Into: public int Value;
*/
using System;
class Trace
{
    public static int Digits;
    public static int Mark(int digit) { Digits = Digits * 10 + digit; return digit; }
}
class Parent
{
    public int AtBaseEntry;
    public Parent() { AtBaseEntry = Trace.Digits; Trace.Mark(7); }
}
class Holder : Parent
{
    public int Value = Trace.Mark(6);
    public int AtBodyEntry;
    public Holder() : base() { AtBodyEntry = Trace.Digits; Trace.Mark(8); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Value == 6, "derived-field-initializer-assignment");
        Check(value.AtBaseEntry == 6, "field-initializer-runs-before-base-invocation");
        Check(value.AtBodyEntry == 67, "derived-body-follows-base-constructor");
        Check(Trace.Digits == 678, "initializer-base-and-body-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
