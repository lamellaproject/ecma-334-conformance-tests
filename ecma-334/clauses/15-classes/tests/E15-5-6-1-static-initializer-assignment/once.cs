/*
Rules: E15-5-6-1-static-initializer-assignment
Authority: ECMA-334 7th ed 15.5.6.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public static int Value = Counter.Next();
Into: public static int Value = 9;
*/
using System;
class Counter
{
    public static int Calls;
    public static int Next() { Calls++; return 9; }
}
class Holder
{
    public static int Value = Counter.Next();
    static Holder() { }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.Value == 9, "static-initializer-assigned-value");
        Check(Counter.Calls == 1, "static-initializer-executed-once");
        new Holder();
        new Holder();
        Check(Holder.Value == 9, "instances-preserve-static-value");
        Check(Counter.Calls == 1, "instances-do-not-repeat-static-initializer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
