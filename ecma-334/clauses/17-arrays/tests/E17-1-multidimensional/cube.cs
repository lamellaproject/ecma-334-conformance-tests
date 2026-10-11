/*
Rules: E17-1-multidimensional; E17-1-rank; E17-2-1-comma-rank; E17-1-total-elements; E17-5-inherited-members
Authority: ECMA-334 7th ed 17.1
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: new int[2, 3, 4]
Into: new int[2, 3, 5]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,,] values = new int[2, 3, 4];
        values[1, 2, 3] = 41;
        Check(values.Rank == 3, "three-indices");
        Check(values.GetLength(0) == 2, "left-length");
        Check(values.GetLength(1) == 3, "middle-length");
        Check(values.GetLength(2) == 4, "right-length");
        Check(values.Length == 24 && values[1, 2, 3] == 41, "product-and-address");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
