/*
Rules: E6-3-3-grammar-comment-1; E6-3-3-grammar-single-line-comment-1; E6-3-3-grammar-input-character-1; E6-3-3-grammar-new-line-character-2; E6-3-2-line-division; E6-3-2-grammar-new-line-1
Authority: ECMA-334 7th ed 6.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: // amount = 91;
Into: amount = 91;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int amount = 12; // amount = 91;
        //
        Check(amount == 12, "comment-ends-at-lf");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
