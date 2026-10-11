/*
Rules: E15-5-6-3-instance-initializer-constructor-entry
Authority: ECMA-334 7th ed 15.5.6.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public Holder() : this(0) { Trace.Mark(3); }
Into: public Holder() { Trace.Mark(3); }
*/
using System;
class Trace
{
    public static int Digits, Initializations;
    public static int Initialize() { Initializations++; Mark(1); return 17; }
    public static void Mark(int digit) { Digits = Digits * 10 + digit; }
}
class Holder
{
    public int Value = Trace.Initialize();
    public Holder() : this(0) { Trace.Mark(3); }
    public Holder(int ignored) { Trace.Mark(2); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Value == 17, "delegated-constructor-has-initialized-field");
        Check(Trace.Initializations == 1, "this-delegation-does-not-repeat-field-initialization");
        Check(Trace.Digits == 123, "initializer-precedes-target-and-delegating-bodies");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
