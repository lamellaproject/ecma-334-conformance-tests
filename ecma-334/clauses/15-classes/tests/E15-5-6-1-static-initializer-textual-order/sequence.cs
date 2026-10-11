/*
Rules: E15-5-6-1-static-initializer-textual-order
Authority: ECMA-334 7th ed 15.5.6.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public static int First = Trace.Mark(1), Second = Trace.Mark(2);
Into: public static int Second = Trace.Mark(2), First = Trace.Mark(1);
*/
using System;
class Trace
{
    public static int Digits;
    public static int Mark(int digit) { Digits = Digits * 10 + digit; return Digits; }
}
class Holder
{
    public static int First = Trace.Mark(1), Second = Trace.Mark(2);
    public static int Third = Trace.Mark(3);
    static Holder() { }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.First == 1, "first-declarator-assigned-first");
        Check(Holder.Second == 12, "second-declarator-assigned-second");
        Check(Holder.Third == 123, "later-declaration-assigned-third");
        Check(Trace.Digits == 123, "static-initializer-side-effect-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
