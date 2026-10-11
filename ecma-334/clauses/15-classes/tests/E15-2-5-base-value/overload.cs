/*
Rules: E15-2-5-base-value; E15-2-5-base-is-class
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : struct
Into: 
*/
using System;
class Program
{
    static int Pick(object value) { return 1; }
    static int Pick(ValueType value) { return 2; }
    static int Read<T>(T value) where T : struct { return Pick(value); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read(233) == 2, "value-constraint-has-valuetype-class-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
