/*
Rules: E15-6-2-1-reference-parameter-kind; E15-6-2-1-grammar-parameter-modifier-form-1; E15-6-2-1-grammar-parameter-mode-modifier-form-1; E15-6-2-1-invocation-argument-assignment
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static int Add(ref int value)
Into: static int Add(int value)
*/
using System;
class Program
{
    static int Add(ref int value) { int prior = value; value += 13; return prior; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 5;
        Check(Add(ref value) == 5, "ref-parameter-initially-reads-argument-variable");
        Check(value == 18, "ref-parameter-writes-argument-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
