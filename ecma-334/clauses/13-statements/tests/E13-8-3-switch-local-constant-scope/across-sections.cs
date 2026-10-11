/*
Rules: E13-8-3-switch-local-constant-scope; E13-8-3-section-declarations
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int observed = value;
Into: int observed = Program.value;
*/
using System;
class Program
{
    const int value = 9;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int selector = 0;
        switch (selector)
        {
            case 0: const int value = 4; goto case 1;
            case 1:
                int observed = value;
                Check(observed == 4, "constant-visible-in-next-section");
                break;
        }
        Check(value == 9, "outside-switch-binds-field-constant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
