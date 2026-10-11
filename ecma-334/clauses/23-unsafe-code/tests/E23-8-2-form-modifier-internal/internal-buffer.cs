/*
Rules: E23-8-2-form-modifier-internal; E23-8-2-buffer-accessibility
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal fixed int Values[2];
Into: private fixed int Values[2];
*/
using System;
unsafe struct Item { internal fixed int Values[2]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        value.Values[1] = 53;
        Check(value.Values[1] == 53, "internal-buffer-same-assembly");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
