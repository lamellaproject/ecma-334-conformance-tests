/*
Rules: E15-10-2-increment-parameter-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Gauge? operator ++(Gauge? x)
Into: Gauge? operator --(Gauge? x)
*/
using System;
struct Gauge { public int N; public Gauge(int n) { N = n; } public static Gauge? operator ++(Gauge? x) { return new Gauge(x.HasValue ? x.Value.N + (7) : 9); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge? item = null;
        item++;
        Check(item.HasValue && item.Value.N == 9, "nullable-increment-null-operand-invoked");
        item++;
        Check(item.HasValue && item.Value.N == 16, "nullable-increment-present");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
