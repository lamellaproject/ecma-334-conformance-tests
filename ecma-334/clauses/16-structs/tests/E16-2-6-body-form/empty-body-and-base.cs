/*
Rules: E16-2-6-body-form; E16-3-inherited-members; E16-4-3-base-valuetype; E16-4-3-valuetype-object; E16-4-3-not-abstract
Authority: ECMA-334 7th ed 16.2.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: struct Empty { }
Into: class Empty { }
*/
using System;
struct Empty { };
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ValueType baseValue = new Empty(); object root = baseValue;
        Check(root is Empty, "implicit-base-chain");
        Check(new Empty().Equals(new Empty()), "inherited-equals");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
