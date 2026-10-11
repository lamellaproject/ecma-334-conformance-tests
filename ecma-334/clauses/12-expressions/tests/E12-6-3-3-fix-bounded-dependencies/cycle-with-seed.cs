/*
Rules: E12-6-3-3-fix-bounded-dependencies; E12-6-3-6-direct-dependence
Authority: ECMA-334 7th ed 12.6.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: RoundTrip(11,
Into: RoundTrip(11L,
*/
using System;
class Stamp { public int value; }
class Program
{
    static int checks, failures;
    static T RoundTrip<T, U>(T seed, Func<T, U> forward, Func<U, T> back) { return back(forward(seed)); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = RoundTrip(11, x => new Stamp { value = x }, s => s.value);
        Check(result == 11, "cycle-broken-by-nonempty-seed-bounds");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
