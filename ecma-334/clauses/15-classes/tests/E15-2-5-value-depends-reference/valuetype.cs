/*
Rules: E15-2-5-value-depends-reference
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where S : struct, T
Into: where S : struct
*/
using System;
class Program
{
    static T Up<S,T>(S value) where S : struct, T where T : class { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ValueType item = Up<int,ValueType>(167);
        Check(item.Equals(167), "value-depends-on-reference-valuetype-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
