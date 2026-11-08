/*
Rules: E15-11-2-ed1-direct-constructor-recursion-only
Authority: ECMA-334 1st ed 17.10.1
Version: ISO-1
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E15-11-2-ed1-direct-constructor-recursion-only/three-constructor-cycle.cs.part
Mutate: public Ring(long key) : this()
Into: public Ring(long key) : this(key)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    class Ring
    {
        public Ring() : this(0) { }
        public Ring(int key) : this(0L) { }
        public Ring(long key) : this() { }
    }
    class Control
    {
        public int Value;
        public Control(int value) { Value = value; }
    }
    static int Main()
    {
        Check(new Control(17).Value == 17, "acyclic-construction-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
