/*
Rules: E6-5-9-unknown-pragma-no-error; E6-5-9-unknown-pragma-warning; E6-5-9-contextual-information; E6-5-9-grammar-pp-pragma-1; E6-5-9-grammar-pp-pragma-text-1; E6-5-9-pragma-preserve-semantics; E6-5-9-pragma-compiler-scope; E6-5-1-grammar-pp-kind-6
Authority: ECMA-334 7th ed 6.5.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: #pragma lexical_unknown_context
Into: #error lexical_unknown_context
*/
#pragma lexical_unknown_context amount = 0; []$?
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int amount = 18;
        amount = amount * 2 + 1;
        Check(amount == 37, "pragma-does-not-change-evaluation");
        Check(amount > 0, "pragma-does-not-change-comparison");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
