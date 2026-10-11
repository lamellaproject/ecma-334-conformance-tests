/*
Rules: E6-4-6-grammar-operator-or-punctuator-3; E6-4-6-grammar-operator-or-punctuator-4; E6-4-6-grammar-operator-or-punctuator-8
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: cells[1]
Into: cells(1)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] cells = { 7, 11, 19 };
        int chosen = cells[1];
        Check(cells.Length == 3 && chosen == 11, "array-brackets-and-commas");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
