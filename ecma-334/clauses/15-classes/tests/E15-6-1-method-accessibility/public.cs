/*
Rules: E15-6-1-method-accessibility; E15-6-1-grammar-ref-method-modifier-form-2
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Read() { return 23; }
Into: private int Read() { return 23; }
*/
using System;
class Holder { public int Read() { return 23; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Read() == 23, "public-method-access-outside-declaring-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
