/*
Rules: E15-10-4-conversion-nullable-source-underlying
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator int(Gauge? x) { return x.HasValue ? x.Value.N + 7 : 3; }
Into: operator int(Gauge? x) { return x.HasValue ? x.Value.N + 7 : 4; }
*/
using System;
struct Gauge { public int N; public Gauge(int n) { N = n; } public static implicit operator int(Gauge? x) { return x.HasValue ? x.Value.N + 7 : 3; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge? present = new Gauge(13);
        int first = present;
        Check(first == 20, "nullable-source-present");
        Gauge? absent = null;
        int second = absent;
        Check(second == 3, "nullable-source-null-invokes-declared-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
