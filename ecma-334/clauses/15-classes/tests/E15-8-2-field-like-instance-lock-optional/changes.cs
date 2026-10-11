/*
Rules: E15-8-2-field-like-instance-lock-optional
Authority: ECMA-334 7th ed 15.8.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: source.Signal -= handler;
Into: source.Signal += handler;
*/
using System;
class Source { public event Action Signal; public Action Read() { return Signal; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source source = new Source();
        Action handler = () => { };
        // Both permitted implementation strategies must complete these operations.
        source.Signal += handler;
        Check(source.Read() == handler, "instance-add-with-either-lock-strategy");
        source.Signal -= handler;
        Check(source.Read() == null, "instance-remove-with-either-lock-strategy");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
