/*
Rules: E23-6-6-decrement-operator; E23-6-6-decrement-address
Authority: ECMA-334 7th ed 23.6.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: int* previous = pointer--;
Into: int* previous = pointer++;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int* storage = stackalloc int[4];
        int* pointer = storage + 2;
        byte* start = (byte*)pointer;
        int* previous = pointer--;
        Check((byte*)previous == start, "postdecrement-result");
        Check(start - (byte*)pointer == sizeof(int), "postdecrement-scale");
        int* current = --pointer;
        Check(current == pointer, "predecrement-result");
        Check(start - (byte*)pointer == 2 * sizeof(int), "predecrement-scale");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
