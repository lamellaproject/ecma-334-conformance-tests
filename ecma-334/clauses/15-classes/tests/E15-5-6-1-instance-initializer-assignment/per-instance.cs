/*
Rules: E15-5-6-1-instance-initializer-assignment
Authority: ECMA-334 7th ed 15.5.6.1
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: public int Value = Counter.Next();
Into: public int Value = 1;
*/
using System;
class Counter
{
    public static int Calls;
    public static int Next() { return ++Calls; }
}
class Holder { public int Value = Counter.Next(); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder first = new Holder();
        Check(first.Value == 1, "first-instance-initializer-value");
        Check(Counter.Calls == 1, "first-instance-initializer-side-effect");
        Holder second = new Holder();
        Check(second.Value == 2, "second-instance-initializer-value");
        Check(Counter.Calls == 2, "initializer-executed-per-instance");
        Check(first.Value == 1, "second-initialization-preserves-first-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
