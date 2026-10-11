/*
Rules: E15-7-1-grammar-property-modifier-form-6
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public static int Token
Into: public int Token
*/
using System;
class Box { public static int Token => 37; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Check(Box.Token == 37, "static-property"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
