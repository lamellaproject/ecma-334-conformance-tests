/*
Rules: E15-5-6-1-instance-initializer-textual-order
Authority: ECMA-334 7th ed 15.5.6.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public int First = Trace.Mark(4), Second = Trace.Mark(5);
Into: public int Second = Trace.Mark(5), First = Trace.Mark(4);
*/
using System;
class Trace
{
    public static int Digits;
    public static int Mark(int digit) { Digits = Digits * 10 + digit; return Digits; }
}
class Holder
{
    public int First = Trace.Mark(4), Second = Trace.Mark(5);
    public int Third = Trace.Mark(6);
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.First == 4, "first-instance-declarator-assigned-first");
        Check(value.Second == 45, "second-instance-declarator-assigned-second");
        Check(value.Third == 456, "later-instance-declaration-assigned-third");
        Check(Trace.Digits == 456, "instance-initializer-side-effect-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
