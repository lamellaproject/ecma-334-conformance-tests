/*
Rules: E15-9-2-overridden-indexer-base-access; E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: base[first, second] = value + 3;
Into: base[second, first] = value + 3;
*/
using System;
class Grid
{
    public int First, Second, Stored;
    public virtual int this[int first, int second]
    {
        get { First = first; Second = second; return Stored + first * 10 + second; }
        set { First = first; Second = second; Stored = value; }
    }
}
class Derived : Grid
{
    public override int this[int first, int second]
    {
        get { return base[first, second] + 5; }
        set { base[first, second] = value + 3; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Derived();
        grid[2, 8] = 17;
        Check(grid.Stored == 20 && grid.First == 2 && grid.Second == 8, "base-indexer-set-arguments");
        Check(grid[3, 7] == 62 && grid.First == 3 && grid.Second == 7, "base-indexer-get-arguments");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
