/*
Rules: E15-6-1-grammar-ref-method-modifier-form-11; E15-6-1-grammar-ref-method-body-form-3
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: public static extern ref int Cell();
Into: public static extern int Cell();
*/
using System;
class External { public static extern ref int Cell(); }
class Program
{
    static void Bind() { ref int alias = ref External.Cell(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
