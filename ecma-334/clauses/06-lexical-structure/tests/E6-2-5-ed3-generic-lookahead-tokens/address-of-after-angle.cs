/*
Rules: E6-2-5-ed3-generic-lookahead-tokens
Authority: ECMA-334 3rd ed 9.2.3
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E6-2-5-ed3-generic-lookahead-tokens/address-of-after-angle.cs.part
Mutate: Pair(first < second, upper > &cells[0])
Into: Pair(first < second, upper > (&cells[0]))
*/
// ECMA-334 3rd ed 9.2.3, p. 66 (PDF p. 86).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static bool Pair(bool one, bool two) { return one && two; }
    static int Main()
    {
        unsafe
        {
            int* cells = stackalloc int[2];
            int* upper = cells + 1;
            int first = 3, second = 9;
            Check(Pair(first < second, upper > &cells[0]), "relational-argument-pair");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
