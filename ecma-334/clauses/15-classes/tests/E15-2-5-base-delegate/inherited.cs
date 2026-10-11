/*
Rules: E15-2-5-base-delegate
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Reader : Basis<Reading<dynamic>>
Into: class Reader : Basis<object>
*/
using System;
delegate A Reading<A>();
abstract class Basis<A> { public abstract int Read<T>(T value) where T : A; }
class Reader : Basis<Reading<dynamic>>
{
    static int Pick(object value) { return 1; }
    static int Pick(int value) { return 2; }
    public override int Read<T>(T value) { return Pick(value.Invoke()); }
}
class Program
{
    static object Number() { return 227; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Reading<dynamic> item = Number;
        Check(new Reader().Read(item) == 1, "substituted-delegate-constraint-is-dynamically-erased");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
