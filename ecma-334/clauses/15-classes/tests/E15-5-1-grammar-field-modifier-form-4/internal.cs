/*
Rules: E15-5-1-grammar-field-modifier-form-4; E15-5-1-field-accessibility
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal int Code = 613;
Into: private int Code = 613;
*/
using System;
class Holder { internal int Code = 613; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Code == 613, "internal-field-in-same-program");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
