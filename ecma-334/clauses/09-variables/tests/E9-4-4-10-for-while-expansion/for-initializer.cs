/*
Rules: E9-4-4-10-for-while-expansion
Authority: ECMA-334 7th ed 9.4.4.10
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: for (cell = 7; cell < 9; cell++)
Into: for (; cell < 9; cell++)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell, expected = 7;
        for (cell = 7; cell < 9; cell++)
        {
            Check(cell == expected, "for-body-after-initializer");
            expected++;
        }
        Check(cell == 9, "for-end-state");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
