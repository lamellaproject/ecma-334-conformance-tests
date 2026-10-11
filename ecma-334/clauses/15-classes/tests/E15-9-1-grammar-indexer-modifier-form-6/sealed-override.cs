/*
Rules: E15-9-1-grammar-indexer-modifier-form-6; E15-9-1-grammar-indexer-modifier-form-7; E15-9-1-grammar-indexer-modifier-form-8
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public virtual int this[int index]
Into: public int this[int index]
*/
using System;
class Grid { int stored; public virtual int this[int index] { get { return stored + index; } set { stored = value + index; } } }
class Derived : Grid
{
    public sealed override int this[int index] { get { return base[index] + 3; } set { base[index] = value + 5; } }
}
class Leaf : Derived { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Leaf();
        grid[2] = 11;
        Check(grid[2] == 23, "virtual-sealed-get-and-set");
        Check(grid[4] == 25, "virtual-index-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
