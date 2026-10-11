/*
Rules: E23-5-2-foreach-dimension-zero; E23-5-2-foreach-inner-dimensions; E23-5-2-foreach-dimension-bounds; E23-5-2-pointer-array-foreach-expansion
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: run
Stdout: OK 9
Mutate: foreach (int* current in items)
Into: foreach (int* current in new int*[0, 0, 0])
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int* storage = stackalloc int[8];
        // Array construction with explicit bounds is required to observe nonzero lower bounds.
        int*[,,] items = (int*[,,])Array.CreateInstance(typeof(int*), new int[] { 2, 2, 2 },
                                                        new int[] { -1, 3, 6 });
        for (int row = -1; row <= 0; row++)
            for (int column = 3; column <= 4; column++)
                for (int depth = 6; depth <= 7; depth++)
                    items[row, column, depth] = storage + ((row + 1) * 4 + (column - 3) * 2 + depth - 6);
        int count = 0;
        foreach (int* current in items)
        {
            Check(current == storage + count, "nonzero-bound-order");
            count++;
        }
        Check(count == 8, "nonzero-inclusive-bounds");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
