/*
Rules: E7-7-1-switch-local-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int value = 151;
Into: int renamed = 151;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        for (int input = 1; input <= 2; input++)
        {
            switch (input)
            {
                case 1:
                    int value = 151;
                    Check(value == 151, "local-in-declaring-switch-section");
                    break;
                case 2:
                    value = 157;
                    Check(value == 157, "local-in-another-switch-section-after-assignment");
                    break;
            }
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
