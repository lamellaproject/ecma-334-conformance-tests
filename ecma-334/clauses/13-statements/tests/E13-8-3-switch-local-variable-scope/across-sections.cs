/*
Rules: E13-8-3-switch-local-variable-scope; E13-8-3-section-declarations
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: case 1: value = 5;
Into: case 1: Program.value = 5;
*/
using System;
class Program
{
    static int checks, failures, value = 9;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int selector = 0;
        switch (selector)
        {
            case 0: int value = 4; goto case 1;
            case 1: value = 5; Check(value == 5, "variable-visible-in-next-section"); break;
        }
        Check(value == 9, "outside-switch-binds-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
