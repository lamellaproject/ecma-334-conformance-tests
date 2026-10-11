/*
Rules: E15-2-5-grammar-primary-constraint-form-3; E15-2-5-struct-constraint-structs
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : struct
Into: where T : class
*/
using System;
struct Record { public int Number; }
class Program
{
    static T Echo<T>(T value) where T : struct { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Echo(new Record { Number = 84 }).Number == 84, "struct-argument-satisfies-value-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
