/*
Rules: E15-9-1-indexer-signature-types
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int this[string index] => 19;
Into: public int this[int index] => 19;
*/
using System;
class Grid { public int this[int index] => 11; public int this[string index] => 19; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Grid();
        Check(grid[2] == 11, "int-signature");
        Check(grid["east"] == 19, "string-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
