/*
Rules: E9-4-4-5-initialized-declaration-transfer
Authority: ECMA-334 7th ed 9.4.4.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int first = (cell = 28), second = cell + 3;
Into: int first = 28, second = cell + 3;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        int first = (cell = 28), second = cell + 3;
        Check(first == 28, "first-initializer-assigns-outer-variable");
        Check(second == 31, "later-initializer-sees-assignment");
        Check(cell == 28, "declaration-end-preserves-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
