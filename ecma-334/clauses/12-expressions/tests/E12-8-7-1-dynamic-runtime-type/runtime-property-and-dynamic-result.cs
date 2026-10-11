/*
Rules: E12-8-7-1-dynamic-runtime-type; E12-8-7-1-dynamic-binding; E12-8-7-1-dynamic-classification; E12-8-7-1-primary-member-form
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: dynamic source = new Worker();
Into: dynamic source = new Other();
*/
using System;
class Worker { public int Value { get { return 3; } } }
class Other { public string Value { get { return "other"; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Pick(int value) { return 3; }
    static int Pick(object value) { return 8; }
    static void Main()
    {
        dynamic source = new Worker();
        var result = source.Value;
        Check(result == 3, "dynamic-property-uses-runtime-receiver-type");
        Check(Pick(result) == 3, "var-preserves-dynamic-type-of-property-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
