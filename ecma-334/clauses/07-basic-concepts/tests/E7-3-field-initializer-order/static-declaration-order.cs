/*
Rules: E7-3-field-initializer-order
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static int First = Mark(1); public static int Second = Mark(2);
Into: public static int Second = Mark(2); public static int First = Mark(1);
*/
using System;
class Trace { public static int Value; }
class Holder
{
    public static int First = Mark(1); public static int Second = Mark(2);
    static int Mark(int value) { Trace.Value = Trace.Value * 10 + value; return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.First == 1 && Holder.Second == 2, "static-initializer-values");
        Check(Trace.Value == 12, "static-initializers-follow-declaration-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
