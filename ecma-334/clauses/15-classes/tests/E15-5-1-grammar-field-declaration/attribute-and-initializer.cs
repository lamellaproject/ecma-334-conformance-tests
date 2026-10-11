/*
Rules: E15-5-1-grammar-field-declaration; E15-5-1-field-attributes; E15-5-1-field-accessibility; E15-5-1-grammar-field-modifier-form-2; E15-5-1-optional-initial-value
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Value = 173;
Into: public int Value = 174;
*/
using System;
class Holder
{
    [Obsolete("Old reading")]
    public int Value = 173;
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Value == 173, "attributed-public-field-initializer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
