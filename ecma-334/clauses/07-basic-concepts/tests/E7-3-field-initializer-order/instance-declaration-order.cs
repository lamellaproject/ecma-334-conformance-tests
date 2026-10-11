/*
Rules: E7-3-field-initializer-order
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int First = Mark(1); public int Second = Mark(2);
Into: public int Second = Mark(2); public int First = Mark(1);
*/
using System;
class Trace { public static int Value; }
class Holder
{
    public int First = Mark(1); public int Second = Mark(2);
    static int Mark(int value) { Trace.Value = Trace.Value * 10 + value; return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var value = new Holder();
        Check(value.First == 1 && value.Second == 2, "instance-initializer-values");
        Check(Trace.Value == 12, "instance-initializers-follow-declaration-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
