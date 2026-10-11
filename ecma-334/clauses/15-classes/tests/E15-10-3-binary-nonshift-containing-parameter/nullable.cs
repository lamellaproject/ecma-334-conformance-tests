/*
Rules: E15-10-3-binary-nonshift-containing-parameter
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator *(int n, Gauge? x) { return x.HasValue ? x.Value.N + n : 7; }
Into: operator *(int n, Gauge? x) { return x.HasValue ? x.Value.N + n : 8; }
*/
using System;
struct Gauge { public int N; public Gauge(int n) { N = n; } public static int operator *(int n, Gauge? x) { return x.HasValue ? x.Value.N + n : 7; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge? item = new Gauge(13);
        Check(3 * item == 16, "nullable-binary-present");
        item = null;
        Check(3 * item == 7, "nullable-binary-null-operand-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
