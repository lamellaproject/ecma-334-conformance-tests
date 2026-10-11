/*
Rules: E6-3-4-grammar-whitespace-2
Authority: ECMA-334 7th ed 6.3.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: \x09
Into: 
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        // 6.3.4, p. 17: U+0009 is horizontal tab and separates tokens.
        int	amount = 53;
        Check(amount == 53, "tab-separates-tokens");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
