/*
Rules: E12-8-9-1-dynamic-primary; E12-8-9-1-dynamic-value; E12-8-9-1-dynamic-runtime-types
Authority: ECMA-334 7th ed 12.8.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: primary(7)
Into: primary(8)
*/
using System;
public delegate int Operation(int value);
class Program
{
    static int checks, failures;
    static int Triple(int value) { return value * 3; }
    static int Kind(int value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic primary = (Operation)Triple;
        var result = primary(7);
        Check(result == 21, "dynamic-primary-invokes-runtime-delegate");
        Check(Kind(result) == 1, "dynamic-invocation-result-uses-runtime-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
