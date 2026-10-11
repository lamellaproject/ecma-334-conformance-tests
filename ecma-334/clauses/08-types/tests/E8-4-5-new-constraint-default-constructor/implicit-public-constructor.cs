/*
Rules: E8-4-5-new-constraint-default-constructor
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new T()
Into: default(T)
*/
using System;
class Receiver { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static T Build<T>() where T : new() { return new T(); }
    static void Main()
    {
        Check(Build<Receiver>() != null, "implicit-default-constructor-satisfies-new");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
