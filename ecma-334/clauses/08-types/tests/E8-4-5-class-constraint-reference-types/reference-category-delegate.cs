/*
Rules: E8-4-5-class-constraint-reference-types
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Gate<Callback> gate = new Gate<Callback>();
Into: Gate<int> gate = new Gate<int>();
*/
using System;
delegate void Callback();
class Gate<T> where T : class { public bool IsNull(T value) { return value == null; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gate<Callback> gate = new Gate<Callback>();
        Check(gate.IsNull(null), "delegate-satisfies-reference-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
