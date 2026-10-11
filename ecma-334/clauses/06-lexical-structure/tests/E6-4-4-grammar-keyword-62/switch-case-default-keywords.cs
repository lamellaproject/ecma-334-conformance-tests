/*
Rules: E6-4-4-grammar-keyword-62; E6-4-4-grammar-keyword-7; E6-4-4-grammar-keyword-15; E6-3-1-grammar-default-1
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: case 2:
Into: 2:
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 0, input = 2;
        switch (input)
        {
            case 2: value = 67; break;
            default: value = 71; break;
        }
        Check(value == 67, "switch-case-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
