/*
Rules: P08-switch-common; P08-switch-target; P08-switch-selected
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Mutate: selector switch { 0 => Unselected(), _ => 229L }
Into: selector switch { 0 => Unselected(), _ => 0L }
*/
using System;
class Program
{
    static int checks, failures;
    static int wrongCalls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static byte Unselected() { wrongCalls++; return 17; }
    static void Main()
    {
        int selector = 2;
        long result = selector switch { 0 => Unselected(), _ => 229L };
        Check(result == 229L, "selected-arm/value");
        Check(wrongCalls == 0, "selected-arm/unselected-not-evaluated");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
