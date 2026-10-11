/*
Rules: E15-5-1-grammar-field-modifier-form-5; E15-5-1-field-accessibility
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private int Code = 709;
Into: private int Other = 709;
*/
using System;
class Holder
{
    private int Code = 709;
    public int Read() { return Code; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Read() == 709, "private-field-in-own-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
