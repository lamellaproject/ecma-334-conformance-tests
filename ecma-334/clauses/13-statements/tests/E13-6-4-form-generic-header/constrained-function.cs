/*
Rules: E13-6-4-form-generic-header; E13-6-4-form-function-expression; E13-6-4-method-semantics
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: => item;
Into: => null;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        T Identity<T>(T item) where T : class => item;
        object marker = new object();
        Check(object.ReferenceEquals(Identity(marker), marker), "generic-constraint-inference-and-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
