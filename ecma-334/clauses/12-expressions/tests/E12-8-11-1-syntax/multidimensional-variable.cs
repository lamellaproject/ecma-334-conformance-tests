/*
Rules: E12-8-11-1-syntax; E12-8-11-1-array-classification; E12-8-11-2-variable-result; E12-8-11-2-selected-element; E12-8-11-2-element-location
Authority: ECMA-334 7th ed 12.8.11
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: ref grid[1, 0]
Into: ref grid[0, 1]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,] grid = new int[,] { { 3, 5 }, { 7, 11 } };
        ref int location = ref grid[1, 0];
        Check(location == 7, "indices-select-corresponding-dimensions");
        location = 19;
        Check(grid[1, 0] == 19 && grid[0, 1] == 5, "element-expression-is-variable-at-selected-location");
        grid[1, 1] = 23;
        Check(grid[1, 1] == 23, "array-element-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
