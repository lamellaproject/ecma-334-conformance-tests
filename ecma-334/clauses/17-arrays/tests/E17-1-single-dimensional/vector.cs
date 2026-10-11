/*
Rules: E17-1-single-dimensional; E17-1-rank
Authority: ECMA-334 7th ed 17.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Array values = new int[4]
Into: Array values = new int[2, 2]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Array values = new int[4];
        Check(values.Rank == 1, "vector-rank");
        Check(values.GetLength(0) == 4, "vector-dimension");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
