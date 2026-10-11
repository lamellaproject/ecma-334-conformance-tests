/*
Rules: E8-3-2-value-type-base; E8-3-2-valuetype-object-base; E8-3-2-valuetype-is-class
Authority: ECMA-334 7th ed 8.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ValueType a = boxed as ValueType;
Into: ValueType a = null;
*/
using System;
struct Sample { public int Count; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object boxed = new Sample(); ValueType a = boxed as ValueType; ValueType b = a;
        Check(a != null && (object)b == boxed, "valuetype-base-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
