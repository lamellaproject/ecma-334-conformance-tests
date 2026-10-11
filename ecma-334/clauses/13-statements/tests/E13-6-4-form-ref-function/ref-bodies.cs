/*
Rules: E13-6-4-form-ref-function; E13-6-4-form-ref-function-block; E13-6-4-form-ref-function-expression
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ref int Expression() => ref field;
Into: ref int Expression() => ref other;
*/
using System;
class Program
{
    static int checks, failures, field = 1, other = 2;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ref int Block() { return ref field; }
        ref int Expression() => ref field;
        Block() = 8;
        Check(field == 8, "local-ref-block-body");
        Expression() = 9;
        Check(field == 9 && other == 2, "local-ref-expression-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
