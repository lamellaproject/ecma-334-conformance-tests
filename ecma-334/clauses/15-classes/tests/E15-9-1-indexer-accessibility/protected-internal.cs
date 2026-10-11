/*
Rules: E15-9-1-indexer-accessibility
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected internal int this[int index]
Into: protected int this[int index]
*/
using System;
class Grid { protected internal int this[int index] => index + 2; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Grid()[5] == 7, "protected-internal-indexer-assembly-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
