/*
Rules: E15-6-2-1-params-after-optional
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int prefix = 5, params int[] items
Into: params int[] items, int prefix = 5
*/
using System;
class Program
{
    static int Read(int prefix = 5, params int[] items) { return prefix * 10 + items.Length; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read() == 50, "optional-and-params-arguments-both-omitted");
        Check(Read(7) == 70, "optional-supplied-and-params-omitted");
        Check(Read(7, 11, 13) == 72, "optional-supplied-and-params-expanded");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
