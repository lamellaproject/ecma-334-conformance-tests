/*
Rules: E9-4-4-24-array-initializer-state
Authority: ECMA-334 7th ed 9.4.4.24
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: cell = 7, cell + 4
Into: 7, cell + 4
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        int[] values = new int[] { cell = 7, cell + 4 };
        Check(values[0] == 7 && values[1] == 11, "initializer-order-propagates-assignment");
        Check(cell == 7, "array-initializer-exit-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
