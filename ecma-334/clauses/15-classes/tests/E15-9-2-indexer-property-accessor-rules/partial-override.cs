/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public override int this[int index]
Into: public new int this[int index]
*/
using System;
class Grid { int stored; public virtual int this[int index] { get { return stored + index; } set { stored = value + index; } } }
class Derived : Grid { public override int this[int index] { get { return base[index] + 6; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Derived();
        grid[3] = 11;
        Check(grid[3] == 23, "get-override-inherited-set");
        grid[5] = 17;
        Check(grid[2] == 30, "inherited-set-index-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
