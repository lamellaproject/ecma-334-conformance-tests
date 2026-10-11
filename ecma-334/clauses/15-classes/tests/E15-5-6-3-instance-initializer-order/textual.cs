/*
Rules: E15-5-6-3-instance-initializer-order
Authority: ECMA-334 7th ed 15.5.6.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public int First = Trace.Next(), Second = Trace.Next();
Into: public int Second = Trace.Next(), First = Trace.Next();
*/
using System;
class Trace
{
    public static int Calls;
    public static int Next() { return ++Calls; }
}
class Holder
{
    public int First = Trace.Next(), Second = Trace.Next();
    public int Third = Trace.Next();
    public int AtBodyEntry;
    public Holder() { AtBodyEntry = Trace.Calls; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.First == 1, "first-initializer-first-assignment");
        Check(value.Second == 2, "second-initializer-second-assignment");
        Check(value.Third == 3, "third-initializer-third-assignment");
        Check(value.AtBodyEntry == 3, "body-follows-complete-textual-initializer-sequence");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
