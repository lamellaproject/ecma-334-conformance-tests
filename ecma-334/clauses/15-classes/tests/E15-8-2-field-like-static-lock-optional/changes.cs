/*
Rules: E15-8-2-field-like-static-lock-optional
Authority: ECMA-334 7th ed 15.8.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Source.Signal -= handler;
Into: Source.Signal += handler;
*/
using System;
class Source { public static event Action Signal; public static Action Read() { return Signal; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Action handler = () => { };
        // Both permitted implementation strategies must complete these operations.
        Source.Signal += handler;
        Check(Source.Read() == handler, "static-add-with-either-lock-strategy");
        Source.Signal -= handler;
        Check(Source.Read() == null, "static-remove-with-either-lock-strategy");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
