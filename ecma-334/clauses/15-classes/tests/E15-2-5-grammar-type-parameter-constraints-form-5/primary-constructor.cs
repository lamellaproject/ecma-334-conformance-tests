/*
Rules: E15-2-5-grammar-type-parameter-constraints-form-5
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : class, new()
Into: where T : class
*/
using System;
class Record { public int Number = 97; }
class Program
{
    static T Make<T>() where T : class, new() { return new T(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Make<Record>().Number == 97, "primary-and-constructor-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
