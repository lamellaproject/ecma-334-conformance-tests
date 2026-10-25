/*
Rules: E23-8-ed1-stackalloc-int-expression
Authority: ECMA-334 1st ed 25.7
Version: ISO-1
Expected: reject
Version-Witness: tests/E23-8-ed1-stackalloc-int-expression/short-stack-size.witness.cs.part
Mutate: stackalloc int[amount]
Into: stackalloc int[(int)amount]
*/
// ECMA-334 1st ed 25.7, p. 336 (PDF p. 350), lines 14-15. The size expression of
// stackalloc T[E] must itself have type int.
using System;
unsafe class Entry
{
    static int checks;
    static int failures;
    static void Check(bool result, string label)
    {
        checks++;
        if (!result)
        {
            failures++;
            Console.WriteLine("FAIL " + label);
        }
    }
    static int Main()
    {
        short amount = 2;
        int* cells = stackalloc int[amount];
        cells[0] = 111;
        cells[1] = 112;
        Check(cells[0] + cells[1] == 223, "int-size-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
