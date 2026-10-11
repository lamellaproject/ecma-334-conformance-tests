/*
Rules: E15-12-closed-type-static-fields-new; E15-12-static-constructor-closed-class-initialization; E15-12-static-constructor-at-most-once
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public static int N;
Into: public int N;
*/
using System;
class Gauge<T> { public static int N; static Gauge() { N = ++Program.Calls; } public static void Touch() { } }
class Program
{
    static int checks, failures;
    public static int Calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int first = Gauge<int>.N;
        int second = Gauge<string>.N;
        Check(first == 1 && second == 2, "each-closed-type-initialized");
        Gauge<int>.N = 13;
        Check(Gauge<string>.N == 2, "closed-type-static-fields-separate");
        new Gauge<int>();
        new Gauge<string>();
        Gauge<int>.Touch();
        Check(Calls == 2, "closed-type-constructors-not-repeated");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
