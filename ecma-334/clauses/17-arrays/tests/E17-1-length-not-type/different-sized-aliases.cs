/*
Rules: E17-1-length-not-type; E17-3-fixed-lengths; E17-3-fixed-rank
Authority: ECMA-334 7th ed 17.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: selected = larger
Into: selected = original
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,] original = new int[1, 2];
        int[,] selected = original;
        int[,] larger = new int[3, 4];
        selected = larger;
        selected[2, 3] = 29;
        Check(selected == larger && selected.Length == 12, "length-is-not-type");
        Check(original.GetLength(0) == 1, "old-left-fixed");
        Check(original.GetLength(1) == 2, "old-right-fixed");
        Check(original.Rank == 2 && original.Length == 2, "old-rank-fixed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
