/*
Rules: E7-3-class-finalizer-declaration; E7-4-5-class-finalizer-declaration
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: ~Holder()
Into: ~Renamed()
*/
using System;
class Holder { ~Holder() { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { new Holder(); if (failures == 0) Console.WriteLine("OK " + checks); }
}
