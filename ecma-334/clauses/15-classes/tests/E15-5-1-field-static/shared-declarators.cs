/*
Rules: E15-5-1-field-static; E15-5-1-grammar-field-modifier-form-6; E15-5-1-field-shared-modifiers; E15-5-1-field-variable
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static int First = 919, Second = 929;
Into: public int First = 919, Second = 929;
*/
using System;
class Holder { public static int First = 919, Second = 929; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.First == 919, "static-modifier-first-field");
        Check(Holder.Second == 929, "static-modifier-second-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
