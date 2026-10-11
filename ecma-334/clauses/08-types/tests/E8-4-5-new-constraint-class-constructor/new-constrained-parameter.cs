/*
Rules: E8-4-5-new-constraint-class-constructor; E8-4-5-new-constraint-new-parameter
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : new()
Into: where T : class
*/
using System;
class Receiver { public int Value; public Receiver() { Value = 38; } }
class Gate<U> where U : new() { public static U Build() { return new U(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static T Build<T>() where T : new() { return Gate<T>.Build(); }
    static void Main()
    {
        Receiver value = Build<Receiver>();
        Check(value.Value == 38, "explicit-public-constructor-and-new-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
