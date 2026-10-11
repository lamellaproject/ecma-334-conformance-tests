/*
Rules: E15-6-2-1-this-designates-extension; E15-6-2-1-grammar-parameter-modifier-form-2
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: this int value
Into: int value
*/
using System;
static class Extensions
{
    public static int Offset(this int value, int amount = 3) { return value + amount; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((5).Offset() == 8, "extension-call-uses-this-argument");
        Check((5).Offset(7) == 12, "extension-call-supplies-remaining-argument");
        Check(Extensions.Offset(5, 7) == 12, "extension-method-allows-ordinary-static-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
