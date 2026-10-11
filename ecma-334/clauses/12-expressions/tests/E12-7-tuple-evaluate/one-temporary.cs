/*
Rules: E12-7-tuple-evaluate; E12-7-tuple-items; E12-7-temporaries
Authority: ECMA-334 7th ed 12.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: (first, second) = Fetch();
Into: (first, second) = (Fetch().Item1, Fetch().Item2);
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static (int, int) Fetch() { calls++; return (calls * 10 + 3, calls * 10 + 8); }
    static void Main()
    {
        int first = 0, second = 0, __v = 91;
        (first, second) = Fetch();
        Check(calls == 1, "tuple-typed-source-evaluated-once");
        Check(first == 13 && second == 18, "tuple-items-come-from-one-evaluation");
        Check(__v == 91, "tuple-temporary-does-not-reuse-user-local");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
