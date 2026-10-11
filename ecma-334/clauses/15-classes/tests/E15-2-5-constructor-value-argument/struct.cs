/*
Rules: E15-2-5-constructor-value-argument
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: where T : new()
Into: 
*/
using System;
struct Record { public int Number; public object Value; }
class Program
{
    static T Make<T>() where T : new() { return new T(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Record item = Make<Record>();
        Check(item.Number == 0, "value-argument-new-zero-initializes-number");
        Check(item.Value == null, "value-argument-new-zero-initializes-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
