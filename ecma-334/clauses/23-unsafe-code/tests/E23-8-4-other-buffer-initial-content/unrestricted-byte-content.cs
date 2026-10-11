/*
Rules: E23-8-4-other-buffer-initial-content
Authority: ECMA-334 7th ed 23.8.4
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: byte last = value.Values[2];
Into: byte last = value.Values;
*/
using System;
unsafe struct Item { public fixed byte Values[3]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value;
        // These bytes are in allocated storage; their initial contents are undefined, so only completion is checked.
        byte first = value.Values[0];
        byte last = value.Values[2];
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
