/*
Rules: E23-8-2-form-modifier-unsafe
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public unsafe fixed short Values[2];
Into: public fixed short Values[2];
*/
using System;
struct Item { public unsafe fixed short Values[2]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        value.Values[1] = 59;
        Check(value.Values[1] == 59, "unsafe-modifier-on-buffer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
