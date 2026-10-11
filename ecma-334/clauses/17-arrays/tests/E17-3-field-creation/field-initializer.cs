/*
Rules: E17-3-field-creation; E17-7-field-context; E17-7-declaration-type; E17-7-declaration-shorthand
Authority: ECMA-334 7th ed 17.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: static long[] field = { 11, 23 }
Into: static long[] field = new long[2]
*/
using System;
class Program
{
    static long[] field = { 11, 23 };
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        long[] explicitCreation = new long[] { 11, 23 };
        Check(field.Length == 2, "field-creates-array");
        Check(field[0] == explicitCreation[0] && field[1] == explicitCreation[1], "declaration-shorthand-values");
        Check(field != explicitCreation, "separate-creation-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
