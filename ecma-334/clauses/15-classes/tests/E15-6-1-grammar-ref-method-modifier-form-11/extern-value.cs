/*
Rules: E15-6-1-grammar-ref-method-modifier-form-11; E15-6-1-grammar-method-body-form-4
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: public static extern int Read();
Into: public static extern void Read();
*/
using System;
class External { public static extern int Read(); }
class Program
{
    static int Bind() { return External.Read(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
