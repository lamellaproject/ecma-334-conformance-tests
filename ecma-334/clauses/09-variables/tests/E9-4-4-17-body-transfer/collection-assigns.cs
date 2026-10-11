/*
Rules: E9-4-4-17-body-transfer; E9-4-4-17-end-transfer
Authority: ECMA-334 7th ed 9.4.4.17
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Elements(empty, out cell)
Into: Elements(empty, out _)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int[] Elements(bool empty, out int cell)
    {
        cell = 57;
        return empty ? new int[0] : new int[] { 9 };
    }
    static void Read(bool empty)
    {
        int cell;
        foreach (int item in Elements(empty, out cell)) Check(cell == 57 && item == 9, "collection-assignment-at-body");
        Check(cell == 57, "collection-assignment-at-end-even-if-empty");
    }
    static void Main()
    {
        Read(false);
        Read(true);
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
