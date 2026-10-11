/*
Rules: E12-8-6-positional-name-conflict; E12-8-6-inferred-element-name
Authority: ECMA-334 7th ed 12.8.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (Item0, Item01)
Into: (Item0 + 0, Item01)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int Item0 = 3, Item01 = 8;
        var result = (Item0, Item01);
        Check(result.Item0 == 3 && result.Item01 == 8, "zero-starting-suffix-does-not-suppress-name-inference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
