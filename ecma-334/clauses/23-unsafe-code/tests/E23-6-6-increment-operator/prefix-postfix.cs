/*
Rules: E23-6-6-increment-operator; E23-6-6-increment-address
Authority: ECMA-334 7th ed 23.6.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: int* previous = pointer++;
Into: int* previous = pointer--;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int* storage = stackalloc int[4];
        int* pointer = storage + 1;
        byte* start = (byte*)pointer;
        int* previous = pointer++;
        Check((byte*)previous == start, "postincrement-result");
        Check((byte*)pointer - start == sizeof(int), "postincrement-scale");
        int* current = ++pointer;
        Check(current == pointer, "preincrement-result");
        Check((byte*)pointer - start == 2 * sizeof(int), "preincrement-scale");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
