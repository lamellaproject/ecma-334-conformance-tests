/*
Rules: E15-2-5-class-constraint-known-parameter
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where U : class
Into: 
*/
using System;
class Record { }
class Program
{
    static T Echo<T>(T value) where T : class { return value; }
    static U Relay<U>(U value) where U : class { return Echo<U>(value); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Record item = new Record();
        Check(Relay(item) == item, "known-reference-parameter-satisfies-class-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
