/*
Rules: E15-10-4-conversion-nullable-target-underlying
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: operator Gauge?(int n) { return new Gauge(n + 7); }
Into: operator Gauge?(int n) { return new Gauge(n + 8); }
*/
using System;
struct Gauge { public int N; public Gauge(int n) { N = n; } public static implicit operator Gauge?(int n) { return new Gauge(n + 7); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge? result = 13;
        Check(result.HasValue && result.Value.N == 20, "nullable-target-underlying-instance-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
