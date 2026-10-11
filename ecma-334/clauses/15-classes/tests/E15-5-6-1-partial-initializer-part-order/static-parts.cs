/*
Rules: E15-5-6-1-partial-initializer-part-order; E15-5-6-1-static-initializer-textual-order
Authority: ECMA-334 7th ed 15.5.6.1
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: public static int First = Trace.Next(), Second = Trace.Next();
Into: public static int Second = Trace.Next(), First = Trace.Next();
*/
using System;
class Trace
{
    public static int Calls;
    public static int Next() { return ++Calls; }
}
partial class Holder
{
    public static int First = Trace.Next(), Second = Trace.Next();
    static Holder() { }
}
partial class Holder
{
    public static int Third = Trace.Next(), Fourth = Trace.Next();
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int a = Holder.First, b = Holder.Second, c = Holder.Third, d = Holder.Fourth;
        // The order of the parts is unspecified; check the guaranteed order within each part.
        Check(1 <= a && a < b && b <= 4, "first-static-part-textual-order");
        Check(1 <= c && c < d && d <= 4, "second-static-part-textual-order");
        Check(a != c && a != d && b != c && b != d, "each-static-assignment-has-distinct-position");
        Check(a + b + c + d == 10, "all-static-assignments-have-valid-positions");
        Check(Trace.Calls == 4, "each-static-initializer-executed-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
