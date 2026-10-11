/*
Rules: E9-4-4-24-object-initializer-state
Authority: ECMA-334 7th ed 9.4.4.24
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: First = (cell = 9)
Into: First = 9
*/
using System;
class Holder { public int First, Second; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        Holder value = new Holder { First = (cell = 9), Second = cell + 2 };
        Check(value.First == 9 && value.Second == 11, "object-initializer-order-propagates-assignment");
        Check(cell == 9, "object-initializer-exit-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
