/*
Rules: E15-10-3-left-shift-first-type
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator <<(Gauge? x, int n) { return x.HasValue ? x.Value.N + n : 7; }
Into: operator <<(Gauge? x, int n) { return x.HasValue ? x.Value.N + n : 8; }
*/
using System;
struct Gauge { public int N; public Gauge(int n) { N = n; } public static int operator <<(Gauge? x, int n) { return x.HasValue ? x.Value.N + n : 7; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge? item = new Gauge(13);
        Check((item << 3) == 16, "nullable-left-shift-first-present");
        item = null;
        Check((item << 3) == 7, "nullable-left-shift-first-null-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
