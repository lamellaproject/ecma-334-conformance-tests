/*
Rules: E23-8-2-length-meaning
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: const byte Count = 2;
Into: static byte Count = 2;
*/
using System;
unsafe struct Item { const byte Count = 2; public fixed int Values[Count + 1]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        value.Values[0] = 7; value.Values[2] = 43;
        Check(value.Values[0] == 7 && value.Values[2] == 43, "constant-expression-buffer-extent");
        Check(sizeof(Item) >= 3 * sizeof(int), "constant-expression-storage-size");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
