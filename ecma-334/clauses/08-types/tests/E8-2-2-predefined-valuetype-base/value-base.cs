/*
Rules: E8-2-2-predefined-valuetype-base
Authority: ECMA-334 7th ed 8.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ValueType boxed = 41;
Into: ValueType boxed = 42;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ValueType boxed = 41;
        Check((int)boxed == 41, "predefined-valuetype-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
