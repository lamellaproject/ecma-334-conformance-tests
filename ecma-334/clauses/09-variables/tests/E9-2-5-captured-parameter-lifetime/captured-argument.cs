/*
Rules: E9-2-5-captured-parameter-lifetime
Authority: ECMA-334 7th ed 9.2.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return () => ++value;
Into: return () => value;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Func<int> Capture(int value) { return () => ++value; }
    static void Main()
    {
        Func<int> a = Capture(10), b = Capture(30);
        Check(a() == 11, "parameter-survives-first-return");
        Check(b() == 31, "different-invocation-parameter");
        Check(a() == 12, "parameter-persists-through-another-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
