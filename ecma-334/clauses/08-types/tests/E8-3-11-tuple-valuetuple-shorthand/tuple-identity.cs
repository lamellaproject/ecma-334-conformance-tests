/*
Rules: E8-3-11-tuple-valuetuple-shorthand; E8-3-11-tuple-valuetuple-identity-conversion; E8-3-11-tuple-identity-conversion; E8-3-11-tuple-names-not-in-type; E8-3-11-tuple-names-not-stored; E8-3-11-tuple-valuetuple-construction
Authority: ECMA-334 7th ed 8.3.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new ValueTuple<int, string>(48, "value")
Into: new ValueTuple<int, string>(49, "value")
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Take(ref ValueTuple<int, string> value) { }
    static void Main()
    {
        ValueTuple<int, string> raw = new ValueTuple<int, string>(48, "value");
        (int left, string right) named = raw;
        (int first, string second) renamed = named;
        Take(ref raw); Take(ref named); Take(ref renamed);
        Check(named.left == 48 && renamed.second == "value", "tuple-names-do-not-change-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
