/*
Rules: E15-9-1-indexer-method-parameter-rules
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: this[in int index]
Into: this[ref int index]
*/
using System;
class Grid { public int this[in int index] => index + 7; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Grid()[3] == 10, "in-parameter-permitted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
