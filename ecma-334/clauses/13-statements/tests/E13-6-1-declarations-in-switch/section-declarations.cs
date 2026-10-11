/*
Rules: E13-6-1-declarations-in-switch; E13-6-1-form-function-declaration
Authority: ECMA-334 7th ed 13.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int value = Local();
Into: int value = 0;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int selector = 1, result = 0;
        switch (selector)
        {
            case 1:
                const int limit = 6;
                int Local() { return limit; }
                int value = Local();
                result = value;
                break;
        }
        Check(result == 6, "variable-constant-function-in-switch-section");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
