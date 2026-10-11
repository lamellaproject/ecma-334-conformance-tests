/*
Rules: E9-4-4-23-later-subexpression-entry; E9-4-4-23-last-subexpression-exit
Authority: ECMA-334 7th ed 9.4.4.23
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (cell = 14) * cell
Into: 14 * cell
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        int product = (cell = 14) * cell;
        Check(product == 196, "earlier-assignment-reaches-later-operand");
        Check(cell == 14, "last-operand-state-reaches-expression-exit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
