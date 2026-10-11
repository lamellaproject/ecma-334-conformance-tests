/*
Rules: E9-4-4-31-outer-variable-body-entry; E9-4-4-31-outer-variable-expression-exit
Authority: ECMA-334 7th ed 9.4.4.31
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int cell = 14;
Into: int cell;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell = 14;
        Func<int> reader = () => cell;
        Check(cell == 14 && reader() == 14, "outer-assignment-preserved-at-body-and-expression");
        cell = 27;
        Check(reader() == 27, "capture-shares-updated-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
