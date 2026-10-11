/*
Rules: E6-3-3-grammar-comment-2; E6-3-3-grammar-delimited-comment-1; E6-3-3-grammar-delimited-comment-section-1; E6-3-3-grammar-delimited-comment-section-2; E6-3-3-grammar-not-slash-or-asterisk-1
Authority: ECMA-334 7th ed 6.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ****
Into: ++++
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int amount = /* / **+ *- / alpha
                         beta ****/ 17;
        Check(amount == 17, "delimited-sections-and-star-terminator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
