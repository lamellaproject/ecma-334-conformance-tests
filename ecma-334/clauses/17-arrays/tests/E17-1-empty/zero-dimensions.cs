/*
Rules: E17-1-empty; E17-1-total-elements
Authority: ECMA-334 7th ed 17.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new int[0, 3]
Into: new int[1, 3]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,] leftEmpty = new int[0, 3];
        int[,] rightEmpty = new int[2, 0];
        Check(leftEmpty.Length == 0 && leftEmpty.GetLength(1) == 3, "zero-left");
        Check(rightEmpty.Length == 0 && rightEmpty.GetLength(0) == 2, "zero-right");
        bool rejected = false;
        try { int item = leftEmpty[0, 0]; }
        catch (IndexOutOfRangeException) { rejected = true; }
        catch (Exception) { }
        Check(rejected, "empty-no-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
