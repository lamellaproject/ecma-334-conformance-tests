/*
Rules: E15-10-2-unary-complement-parameter-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator ~(Gauge? x) { return x.HasValue ? x.Value.N + 7 : 3; }
Into: operator ~(Gauge? x) { return x.HasValue ? x.Value.N + 7 : 4; }
*/
using System;
struct Gauge { public int N; public Gauge(int n) { N = n; } public static int operator ~(Gauge? x) { return x.HasValue ? x.Value.N + 7 : 3; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge? present = new Gauge(11);
        Gauge? absent = null;
        Check(~present == 18, "nullable-unary-complement-present");
        Check(~absent == 3, "nullable-unary-complement-null-operand-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
