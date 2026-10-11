/*
Rules: E15-7-1-grammar-property-modifier-form-2; E15-7-1-property-accessibility
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Token
Into: private int Token
*/
using System;
class Box { public int Token => 33; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Check(new Box().Token == 33, "public-property"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
