/*
Rules: E8-1-type-parameter-designation; E8-1-type-form-parameter; E8-1-type-categories
Authority: ECMA-334 7th ed 8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return value;
Into: return default(T);
*/
using System;
class Program
{
    static T Identity<T>(T value) { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Identity(26) == 26, "value-type-argument");
        Check(Identity("signal") == "signal", "reference-type-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
