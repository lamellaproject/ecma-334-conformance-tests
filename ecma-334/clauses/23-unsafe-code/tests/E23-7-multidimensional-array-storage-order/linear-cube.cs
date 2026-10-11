/*
Rules: E23-7-multidimensional-array-storage-order; E23-7-array-linear-access; E23-7-array-pointer-addresses; E23-7-array-pointer-elements
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 9
Mutate: fixed (int* pointer = items)
Into: fixed (int* pointer = other)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int[,,] items = new int[2, 2, 2], other = new int[2, 2, 2];
        for (int row = 0; row < 2; row++)
            for (int column = 0; column < 2; column++)
                for (int depth = 0; depth < 2; depth++)
                    items[row, column, depth] = 10 + row * 4 + column * 2 + depth;
        fixed (int* pointer = items)
        {
            for (int index = 0; index < 8; index++)
                Check(pointer[index] == 10 + index, "cube-linear-order");
            pointer[6] = 47;
            Check(items[1, 1, 0] == 47, "cube-linear-write");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
