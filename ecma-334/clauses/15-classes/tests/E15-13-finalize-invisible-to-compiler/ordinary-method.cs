/*
Rules: E15-13-finalize-invisible-to-compiler
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public void Finalize()
Into: protected override void Finalize()
*/
using System;
class Gauge { public int N; public void Finalize() { N += 13; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        item.Finalize();
        Check(item.N == 13, "ordinary-finalize-name-is-available");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
