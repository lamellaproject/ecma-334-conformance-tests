/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public abstract override int this[int index]
Into: public abstract new int this[int index]
*/
using System;
class Grid { public virtual int this[int index] => index + 1; }
abstract class Middle : Grid { public abstract override int this[int index] { get; } }
class Derived : Middle { public override int this[int index] => index + 7; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grid grid = new Derived();
        Check(grid[3] == 10, "abstract-override-indexer-slot");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
