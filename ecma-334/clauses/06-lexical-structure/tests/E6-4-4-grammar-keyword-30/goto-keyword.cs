/*
Rules: E6-4-4-grammar-keyword-30
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: goto finish;
Into: value = 11;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 0;
        goto finish;
        value = 7;
        finish:
        Check(value == 0, "goto-label");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
