/*
Rules: E15-6-ed1-abstract-sealed-override
Authority: ECMA-334 1st ed 17.5
Version: ISO-1
Expected: run
Stdout: OK 0
Version-Witness: tests/E15-6-ed1-abstract-sealed-override/abstract-sealed-override.witness.cs.part
Mutate: public abstract sealed override int Tick();
Into: public abstract sealed int Tick();
*/
// ECMA-334 1st ed 17.5, p. 230 (PDF p. 244), lines 13-23. An abstract sealed override
// method is a valid modifier combination when the enclosing class is abstract and the
// overridden method is virtual.
using System;
class Meter
{
    public virtual int Tick() { return 197; }
}
abstract class LockedMeter : Meter
{
    public abstract sealed override int Tick();
}
class Entry
{
    static int Main()
    {
        Console.WriteLine("OK 0");
        return 0;
    }
}
