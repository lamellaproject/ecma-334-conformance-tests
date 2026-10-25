/*
Rules: E23-2-ed1-static-constructor-modifier-order
Authority: ECMA-334 1st ed 25.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E23-2-ed1-static-constructor-modifier-order/static-unsafe-order.witness.cs.part
Mutate: static unsafe Entry()
Into: unsafe static Entry()
*/
// ECMA-334 1st ed 25.1, p. 322 (PDF p. 336), lines 31-33. The unsafe static-constructor
// productions place unsafe before static (with the specified optional extern orders).
using System;
class Entry
{
    static unsafe Entry() { }
    static int Main()
    {
        Console.WriteLine("OK 0");
        return 0;
    }
}
