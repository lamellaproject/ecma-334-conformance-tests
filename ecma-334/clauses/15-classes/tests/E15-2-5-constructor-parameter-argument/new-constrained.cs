/*
Rules: E15-2-5-constructor-parameter-argument
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where U : new()
Into: 
*/
using System;
class Record { public int Number = 181; }
class Program
{
    static T Make<T>() where T : new() { return new T(); }
    static U Relay<U>() where U : new() { return Make<U>(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Relay<Record>().Number == 181, "new-constrained-parameter-satisfies-constructor-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
