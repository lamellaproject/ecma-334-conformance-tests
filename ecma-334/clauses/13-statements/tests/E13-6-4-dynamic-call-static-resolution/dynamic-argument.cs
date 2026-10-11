/*
Rules: E13-6-4-dynamic-call-static-resolution
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Observe(input);
Into: ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic input = new object();
        int calls = 0;
        void Observe(dynamic value) { if (object.ReferenceEquals((object)value, (object)input)) calls++; }
        Observe(input);
        Check(calls == 1, "dynamic-argument-statically-calls-local-function");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
