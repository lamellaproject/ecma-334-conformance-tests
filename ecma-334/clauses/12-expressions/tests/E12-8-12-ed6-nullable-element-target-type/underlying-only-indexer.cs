/*
Rules: E12-8-12-ed6-nullable-element-target-type
Authority: ECMA-334 6th ed 11.7.11
Version: 6
Expected: reject
Version-Witness: tests/E12-8-12-ed6-nullable-element-target-type/underlying-only-indexer.witness.cs.part
Mutate: receiver?[index]
Into: receiver.Value[index]
*/
using System;

struct Rack
{
    readonly int start;
    public Rack(int start) { this.start = start; }
    public int this[int index] { get { return start + index; } }
}

class Program
{
    static int? Read(Rack? receiver, int index) { return receiver?[index]; }

    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Rack? rack = new Rack(20);
        Check(Read(rack, 3) == 23, "present-index");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
