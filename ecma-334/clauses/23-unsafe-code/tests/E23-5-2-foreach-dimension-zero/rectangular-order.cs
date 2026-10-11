/*
Rules: E23-5-2-foreach-dimension-zero; E23-5-2-foreach-inner-dimensions; E23-5-2-foreach-dimension-bounds; E23-5-2-pointer-array-foreach-expansion; E23-5-2-foreach-body-execution
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: foreach (int* current in items)
Into: foreach (int* current in new int*[0, 0])
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int* storage = stackalloc int[6];
        int*[,] items = new int*[2, 3];
        for (int row = 0; row < 2; row++)
            for (int column = 0; column < 3; column++)
                items[row, column] = storage + row * 3 + column;
        int count = 0;
        foreach (int* current in items)
        {
            Check(current == storage + count, "rectangular-order");
            count++;
        }
        Check(count == 6, "rectangular-inclusive-bounds");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
