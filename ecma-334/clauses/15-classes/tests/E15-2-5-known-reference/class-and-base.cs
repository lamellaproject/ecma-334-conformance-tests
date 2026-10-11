/*
Rules: E15-2-5-known-reference
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: where T : Record
Into: 
*/
using System;
class Record { }
class Program
{
    static T ReferenceNull<T>() where T : class { return null; }
    static T BaseNull<T>() where T : Record { return null; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(ReferenceNull<Record>() == null, "class-constraint-is-known-reference");
        Check(BaseNull<Record>() == null, "nonobject-effective-base-is-known-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
