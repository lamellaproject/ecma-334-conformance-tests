/*
Rules: E15-2-5-grammar-primary-constraint-form-2; E15-2-5-class-constraint-classes
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : class
Into: where T : struct
*/
using System;
class Record { }
class Program
{
    static T Echo<T>(T value) where T : class { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Record item = new Record();
        Check(Echo(item) == item, "class-argument-satisfies-reference-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
