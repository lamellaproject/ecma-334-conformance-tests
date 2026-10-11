/*
Rules: E15-2-5-struct-constraint-parameters
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where U : struct
Into: 
*/
using System;
class Program
{
    static T Echo<T>(T value) where T : struct { return value; }
    static U Relay<U>(U value) where U : struct { return Echo<U>(value); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Relay(149) == 149, "value-constrained-parameter-satisfies-struct-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
