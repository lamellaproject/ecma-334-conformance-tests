/*
Rules: E8-4-5-struct-constraint-value-type; E8-4-5-struct-constraint-parameter
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : struct
Into: where T : class
*/
using System;
enum Mode { Ready = 8 }
class Gate<U> where U : struct { public U Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static T Relay<T>(T input) where T : struct { Gate<T> gate = new Gate<T>(); gate.Value = input; return gate.Value; }
    static void Main()
    {
        Check(Relay(18) == 18 && Relay(Mode.Ready) == Mode.Ready, "struct-and-enum-parameters-satisfy-value-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
