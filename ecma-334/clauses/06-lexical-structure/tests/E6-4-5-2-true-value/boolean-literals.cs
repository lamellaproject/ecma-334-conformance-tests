/*
Rules: E6-4-5-2-true-value; E6-4-5-2-false-value; E6-4-5-2-grammar-boolean-literal-1; E6-4-5-2-grammar-boolean-literal-2; E6-4-5-2-boolean-type; E6-4-5-1-grammar-literal-1; E6-3-1-grammar-true-1; E6-3-1-grammar-false-1
Authority: ECMA-334 7th ed 6.4.5.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: bool enabled = true;
Into: bool enabled = false;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Tag(bool value) { return 1; }
    static int Tag(object value) { return 2; }
    static void Main()
    {
        bool enabled = true;
        bool disabled = false;
        Check(enabled, "true-value");
        Check(!disabled, "false-value");
        Check(Tag(true) == 1 && Tag(false) == 1, "bool-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
