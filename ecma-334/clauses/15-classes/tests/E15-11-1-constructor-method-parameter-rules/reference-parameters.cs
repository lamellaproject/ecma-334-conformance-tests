/*
Rules: E15-11-1-constructor-method-parameter-rules
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Gauge(ref int source, out int result, in int step)
Into: Gauge(int source, out int result, in int step)
*/
using System;
class Gauge { public int N; public Gauge(ref int source, out int result, in int step) { N = source + step; source++; result = N + 2; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int source = 3;
        int step = 13;
        int output;
        Gauge item = new Gauge(ref source, out output, in step);
        Check(item.N == 16, "constructor-reference-inputs");
        Check(source == 4 && output == 18 && step == 13, "constructor-reference-outputs");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
