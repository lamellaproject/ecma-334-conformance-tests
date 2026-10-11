/*
Rules: E15-4-grammar-constant-declaration; E15-4-constant-attributes; E15-4-constant-value; E15-4-declarator-value; E15-4-constant-accessibility; E15-4-grammar-constant-modifier-form-2
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const int Span = 7 * 13;
Into: public const int Span = 7 * 12;
*/
using System;
class Limits
{
    [Obsolete("Use the next revision")]
    public const int Span = 7 * 13;
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Limits.Span == 91, "attributed-public-constant-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
