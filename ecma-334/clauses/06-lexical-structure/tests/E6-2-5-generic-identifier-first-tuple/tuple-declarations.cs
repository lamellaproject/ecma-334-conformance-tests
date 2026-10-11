/*
Rules: E6-2-5-generic-identifier-first-tuple; E6-2-5-generic-identifier-later-tuple
Authority: ECMA-334 7th ed 6.2.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Crate<int> first
Into: Crate<string> first
*/
using System;
class Crate<T> { public int Number; public Crate(int number) { Number = number; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static (Crate<int>, Crate<int>) Pair() { return (new Crate<int>(4), new Crate<int>(6)); }
    static void Main()
    {
        (Crate<int> first, Crate<int> second) = Pair();
        Check(first.Number == 4, "first-tuple-declaration");
        Check(second.Number == 6, "later-tuple-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
