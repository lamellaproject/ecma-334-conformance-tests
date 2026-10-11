/*
Rules: E15-7-1-grammar-property-modifier-form-11; E15-7-1-external-property-classification
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: get;
Into: get { return 3; }
*/
using System;
class Box { public extern int Token { get; set; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
