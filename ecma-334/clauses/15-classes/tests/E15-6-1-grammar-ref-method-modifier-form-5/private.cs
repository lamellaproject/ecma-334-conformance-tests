/*
Rules: E15-6-1-grammar-ref-method-modifier-form-5; E15-6-1-method-accessibility
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private int Read() { return 37; }
Into: private int Read(int unused) { return 37; }
*/
using System;
class Holder
{
    private int Read() { return 37; }
    public int Touch() { return Read(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Touch() == 37, "private-method-call-within-declaring-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
