/*
Rules: E15-2-5-struct-satisfies-new; E15-2-5-constructor-parameter-argument
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where U : struct
Into: 
*/
using System;
struct Record { public int Number; }
class Program
{
    static T Make<T>() where T : new() { return new T(); }
    static U Relay<U>() where U : struct { return Make<U>(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Relay<Record>().Number == 0, "struct-constrained-argument-satisfies-new");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
