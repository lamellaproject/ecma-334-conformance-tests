/*
Rules: E9-4-4-24-anonymous-object-initializer-state
Authority: ECMA-334 7th ed 9.4.4.24
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: First = (cell = 21)
Into: First = 21
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        var value = new { First = (cell = 21), Second = cell + 4 };
        Check(value.First == 21 && value.Second == 25, "anonymous-initializer-order-propagates-assignment");
        Check(cell == 21, "anonymous-initializer-exit-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
