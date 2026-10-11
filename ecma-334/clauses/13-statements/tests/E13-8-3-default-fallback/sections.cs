/*
Rules: E13-8-3-default-fallback; E13-8-3-form-switch; E13-8-3-form-switch-block; E13-8-3-form-switch-section; E13-8-3-form-case-label; E13-8-3-form-default-label; E13-8-1-form-switch-selection
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: case 5:
Into: case 6:
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Choose(int value)
    {
        switch (value)
        {
            default: return 9;
            case 2:
            case 5: return 4;
        }
    }
    static void Main()
    {
        Check(Choose(2) == 4, "first-label-of-shared-section");
        Check(Choose(5) == 4, "second-label-of-shared-section");
        Check(Choose(8) == 9, "default-before-cases-still-is-fallback");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
