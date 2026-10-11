/*
Rules: E11-3-subsumed-case
Authority: ECMA-334 7th ed 11.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: case int first when first < 0:
Into: case int first:
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Select(object input)
    {
        switch (input)
        {
            case int first when first < 0: return 1;
            case int second: return 2;
            default: return 3;
        }
    }
    static void Main()
    {
        Check(Select(-29) == 1, "guard-match");
        Check(Select(29) == 2, "guard-false-later-pattern");
        Check(Select("harbor") == 3, "different-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
