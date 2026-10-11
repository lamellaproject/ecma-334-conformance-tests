/*
Rules: E9-4-4-9-body-entry-transfer; E9-4-4-9-condition-entry; E9-4-4-9-assigned-end-transfer
Authority: ECMA-334 7th ed 9.4.4.9
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int cell = 4;
Into: int cell;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell = 4;
        int expected = 7;
        do
        {
            cell += 3;
            Check(cell == expected, "body-entry-and-condition-entry-state");
            expected += 3;
        } while (cell < 9);
        Check(cell == 10, "condition-state-transferred-to-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
