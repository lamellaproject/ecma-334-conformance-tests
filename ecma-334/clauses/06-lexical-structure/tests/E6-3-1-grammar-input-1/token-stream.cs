/*
Rules: E6-3-1-grammar-input-1; E6-3-1-grammar-input-section-1; E6-3-1-grammar-input-section-part-1; E6-3-1-grammar-input-element-1; E6-3-1-grammar-input-element-2; E6-3-1-grammar-input-element-3; E6-3-1-only-tokens-syntactic; E6-3-1-lexical-token-sequence; E6-3-1-separators; E6-4-1-comment-separator; E6-1-lexical-analysis; E6-1-syntactic-analysis; E6-2-3-implicit-literal-tokens
Authority: ECMA-334 7th ed 6.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int/* gap
Into: intX/* gap
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }

    static void Main()
    {
        int/* gap */amount
            =
            23
            ;
        Check(amount == 23, "separators-disappear");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
