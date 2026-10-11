/*
Rules: E13-10-4-goto-case-target; E13-10-4-form-goto-case; E13-10-4-goto-default-target; E13-10-4-form-goto-default
Authority: ECMA-334 7th ed 13.10.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: goto case 2;
Into: goto default;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 1, trace = 0;
        switch (value)
        {
            case 1:
                switch (value)
                {
                    case 1: trace = trace * 10 + 1; goto case 2;
                    case 2: trace = trace * 10 + 2; goto default;
                    default: trace = trace * 10 + 3; break;
                }
                trace = trace * 10 + 4; break;
            case 2: trace = 9; break;
            default: trace = 8; break;
        }
        Check(trace == 1234, "goto-case-and-default-use-nearest-switch");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
