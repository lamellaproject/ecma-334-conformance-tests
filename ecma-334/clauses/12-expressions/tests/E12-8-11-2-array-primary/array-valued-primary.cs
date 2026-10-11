/*
Rules: E12-8-11-2-array-primary; E12-8-11-1-array-classification
Authority: ECMA-334 7th ed 12.8.11.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (new int[] { 29 })[0]
Into: (new Cell())[0]
*/
using System;
class Cell { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((new int[] { 29 })[0] == 29, "array-value-primary-permits-array-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
