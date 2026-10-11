/*
Rules: E15-2-5-constructor-new; E15-2-5-constructor-class-argument; E15-2-5-grammar-constructor-constraint; E15-2-5-grammar-type-parameter-constraints-form-3
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: where T : new()
Into: 
*/
using System;
class Record { public static int Created; public int Number; public Record() { Number = ++Created; } }
class Program
{
    static T Make<T>() where T : new() { return new T(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Record first = Make<Record>(), second = Make<Record>();
        Check(first.Number == 1, "constructor-constraint-invokes-first-constructor");
        Check(second.Number == 2, "constructor-constraint-invokes-second-constructor");
        Check(first != second && Record.Created == 2, "constructor-constraint-creates-distinct-instances");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
