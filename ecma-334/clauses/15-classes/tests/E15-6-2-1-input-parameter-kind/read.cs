/*
Rules: E15-6-2-1-input-parameter-kind; E15-6-2-1-grammar-parameter-mode-modifier-form-3
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static int Read(in int value)
Into: static int Read(out int value)
*/
using System;
class Program
{
    static int Read(in int value) { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 23;
        Check(Read(in value) == 23, "input-parameter-reads-argument");
        Check(value == 23, "input-parameter-preserves-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
