/*
Rules: E23-8-4-buffer-no-definite-assignment
Authority: ECMA-334 7th ed 23.8.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public fixed int Values[2];
Into: public int* Values;
*/
using System;
unsafe struct Item { public int Assigned; public fixed int Values[2]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value;
        int* pointer = value.Values;
        pointer[0] = 47;
        Check(value.Values[0] == 47, "buffer-access-without-assignment-prerequisite");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
