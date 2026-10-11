/*
Rules: E15-9-1-grammar-indexer-modifier-form-1
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new int this[int index]
Into: public override int this[int index]
*/
using System;
class Grid { public int this[int index] => index + 3; }
class Derived : Grid { public new int this[int index] => index + 8; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived grid = new Derived();
        Check(grid[4] == 12, "new-indexer");
        Check(((Grid)grid)[4] == 7, "hidden-base-indexer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
