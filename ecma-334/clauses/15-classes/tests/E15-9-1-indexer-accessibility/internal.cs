/*
Rules: E15-9-1-indexer-accessibility; E15-9-1-grammar-indexer-modifier-form-4
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal int this[int index]
Into: private int this[int index]
*/
using System;
class Grid { internal int this[int index] => index + 5; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Grid()[2] == 7, "internal-indexer-assembly-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
