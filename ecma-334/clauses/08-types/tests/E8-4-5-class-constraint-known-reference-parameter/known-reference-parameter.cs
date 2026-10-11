/*
Rules: E8-4-5-class-constraint-known-reference-parameter
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : class
Into: where T : struct
*/
using System;
class Receiver { }
class Gate<U> where U : class { public U Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static T Relay<T>(T input) where T : class { Gate<T> gate = new Gate<T>(); gate.Value = input; return gate.Value; }
    static void Main()
    {
        Receiver value = new Receiver();
        Check(Relay(value) == value, "known-reference-parameter-satisfies-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
