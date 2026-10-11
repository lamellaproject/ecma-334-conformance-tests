/*
Rules: E15-6-2-1-output-parameter-kind; E15-6-2-1-grammar-parameter-mode-modifier-form-2; E15-6-2-1-invocation-argument-assignment
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static void Supply(out int value)
Into: static void Supply(int value)
*/
using System;
class Program
{
    static void Supply(out int value) { value = 19; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value;
        Supply(out value);
        Check(value == 19, "out-parameter-assigns-previously-unassigned-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
