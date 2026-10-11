/*
Rules: E15-6-9-partial-match-constraints; E15-6-9-partial-match-parameter-types
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where Y : X
Into: where Y : class
*/
using System;
class Marker { }
class Rune : Marker { }
partial class Gauge
{
    bool same;
    partial void Record<T, U>(T first, U second) where T : class where U : T;
    partial void Record<X, Y>(X left, Y right) where X : class where Y : X
    {
        same = object.ReferenceEquals(left, right);
    }
    public bool Measure()
    {
        Rune value = new Rune();
        Record<Marker, Rune>(value, value);
        return same;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Gauge().Measure(), "partial-parameter-types-and-dependent-constraints-match-by-position");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
