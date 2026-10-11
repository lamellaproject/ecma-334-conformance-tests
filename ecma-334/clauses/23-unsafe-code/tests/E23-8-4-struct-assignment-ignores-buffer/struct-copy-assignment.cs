/*
Rules: E23-8-4-struct-assignment-ignores-buffer
Authority: ECMA-334 7th ed 23.8.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public fixed int Values[2];
Into: public int Values;
*/
using System;
unsafe struct Item { public int Assigned; public fixed int Values[2]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(Item value) { return value.Assigned; }
    static unsafe void Main()
    {
        Item value;
        value.Assigned = 37;
        Check(Read(value) == 37, "assigned-struct-ignores-buffer-fields");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
