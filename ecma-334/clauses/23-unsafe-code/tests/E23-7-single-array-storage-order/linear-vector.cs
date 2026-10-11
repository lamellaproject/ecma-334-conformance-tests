/*
Rules: E23-7-single-array-storage-order; E23-7-array-pointer-addresses; E23-7-array-pointer-elements; E23-7-array-linear-access
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int* last = pointer + 2;
Into: int* last = pointer + 1;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int[] items = { 17, 29, 53 };
        fixed (int* pointer = items)
        {
            int* last = pointer + 2;
            Check(pointer[0] == 17 && pointer[1] == 29 && *last == 53, "vector-storage-order");
            pointer[1] = 37;
            Check(items[1] == 37, "vector-pointer-element-write");
            fixed (int* actual = &items[2]) Check(last == actual, "vector-offset-address");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
