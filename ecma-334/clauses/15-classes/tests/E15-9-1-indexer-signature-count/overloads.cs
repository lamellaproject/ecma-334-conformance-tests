/*
Rules: E15-9-1-indexer-signature-count
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int this[int first, int second] => first * 10 + second;
Into: public int this[int first] => first * 10;
*/
using System;
class Grid { public int this[int first] => first + 3; public int this[int first, int second] => first * 10 + second; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Grid();
        Check(grid[2] == 5, "one-index-parameter");
        Check(grid[2, 7] == 27, "two-index-parameters");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
