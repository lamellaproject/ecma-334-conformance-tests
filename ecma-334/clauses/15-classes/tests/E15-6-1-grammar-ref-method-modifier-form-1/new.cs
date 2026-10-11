/*
Rules: E15-6-1-grammar-ref-method-modifier-form-1
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new int Read() { return 9; }
Into: public new int Different() { return 9; }
*/
using System;
class Parent { public int Read() { return 4; } }
class Holder : Parent { public new int Read() { return 9; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Parent parent = value;
        Check(value.Read() == 9, "new-method-hides-base-method");
        Check(parent.Read() == 4, "new-method-keeps-base-method-binding");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
