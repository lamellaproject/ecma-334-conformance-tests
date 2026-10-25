/*
Rules: E12-8-18-ed1-sizeof-unsafe-context
Authority: ECMA-334 1st ed 25.5
Version: ISO-1
Expected: reject
Version-Witness: tests/E12-8-18-ed1-sizeof-unsafe-context/int-outside-context-repair.cs.part
Mutate: private static int Measure()
Into: private static unsafe int Measure()
*/
using System;

// ECMA-334 1st ed 25.5, p. 328 (PDF p. 342), line 5; context qualification p. 327 (PDF p.
// 341), lines 50-51. A sizeof expression requires an unsafe context even for a predefined
// int operand.

class TestMain
{
    private static int Measure()
    {
        int storage = sizeof(int);
        return storage;
    }

    public static void Main()
    {
        Console.WriteLine(Measure());
    }
}
