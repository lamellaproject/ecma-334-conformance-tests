/*
Rules: E15-8-1-external-event-classification; E15-8-1-grammar-event-modifier-form-11
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: public extern event Action Signal;
Into: public extern event Action Signal { add { } remove { } }
*/
using System;
class Source { public extern event Action Signal; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
