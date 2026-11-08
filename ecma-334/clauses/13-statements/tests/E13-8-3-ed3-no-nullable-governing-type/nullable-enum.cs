/*
Rules: E13-8-3-ed3-no-nullable-governing-type
Authority: ECMA-334 3rd ed 15.7.2
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E13-8-3-ed3-no-nullable-governing-type/nullable-enum.cs.part
Mutate: switch (selector)
Into: switch (selector.Value)
*/
// ECMA-334 3rd ed 15.7.2, p. 228 (PDF p. 248).
using System;
enum Position { Low = 3, High = 9 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        Position? selector = Position.High;
        int observed = 0;
        switch (selector)
        {
            case Position.High: observed = 9; break;
            default: observed = -1; break;
        }
        Check(observed == 9, "enum-switch-construct");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
