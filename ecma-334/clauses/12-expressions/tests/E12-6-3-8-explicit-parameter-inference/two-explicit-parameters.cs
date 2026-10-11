/*
Rules: E12-6-3-8-explicit-parameter-inference; E12-6-3-2-anonymous-first-phase; E12-6-3-9-exact-bound
Authority: ECMA-334 7th ed 12.6.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (short first, long second) => second + first
Into: (short first, int second) => second + first
*/
using System;
class Program
{
    static int checks, failures;
    static Func<T, U, long> Make<T, U>(Func<T, U, long> f) { return f; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<short, long, long> add = Make((short first, long second) => second + first);
        Check(add(3, 21L) == 24L, "each-explicit-parameter-fixes-its-own-inference-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
