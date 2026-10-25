/*
Rules: E10-2-4-ed1-decimal-zero-literal-only
Authority: ECMA-334 1st ed 13.1.3
Version: ISO-1
Expected: reject
Version-Witness: tests/E10-2-4-ed1-decimal-zero-literal-only/long-cast-zero-repair.cs.part
Mutate: Marker value = (long)0;
Into: Marker value = (Marker)((long)0);
*/
using System;

// ECMA-334 1st ed 13.1.3, p. 114 (PDF p. 128), line 16. Refuse implicit integer-to-enum
// conversion of a zero expression that is not the decimal-integer-literal 0.

enum Marker
{
    Lower = 11,
    Upper = 29
}

class TestMain
{
    public static void Main()
    {
        Marker value = (long)0;
        if ((int)value != 0)
        {
            throw new Exception("zero-value");
        }
        Console.WriteLine("ZERO");
    }
}
