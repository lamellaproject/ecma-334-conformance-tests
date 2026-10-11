/*
Rules: E8-3-4-struct-property-members
Authority: ECMA-334 7th ed 8.3.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: stored = value;
Into: stored = value + 1;
*/
using System;
struct Sample { int stored; public int Value { get { return stored; } set { stored = value; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Sample sample = new Sample(); sample.Value = 17;
        Check(sample.Value == 17, "struct-property");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
