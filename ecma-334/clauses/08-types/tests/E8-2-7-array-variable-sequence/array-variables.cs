/*
Rules: E8-2-7-array-variable-sequence; E8-2-7-array-index-access; E8-2-7-array-uniform-element-type
Authority: ECMA-334 7th ed 8.2.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: cells[index] = 47;
Into: cells[index] = 48;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] empty = new int[0]; int[] cells = new int[3]; int index = 2;
        cells[index] = 47;
        Check(empty.Length == 0 && cells[2] == 47 && cells[0] == 0, "computed-index-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
