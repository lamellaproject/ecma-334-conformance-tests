/*
Rules: E15-9-1-grammar-indexer-modifier-form-9
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public abstract int this[int index]
Into: public virtual int this[int index]
*/
using System;
abstract class Grid { public abstract int this[int index] { get; set; } }
class Derived : Grid { int stored; public override int this[int index] { get { return stored + index; } set { stored = value; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Derived();
        grid[2] = 14;
        Check(grid[2] == 16, "abstract-indexer-implemented");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
