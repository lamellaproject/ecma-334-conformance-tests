/*
Rules: P09-with-null-receiver; P09-with-initializer-order
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Mutate: return null;
Into: return new Packet();
*/
using System;
record Packet { public int Value { get; init; } }
class Program
{
    static int checks, failures, receivers, initializers;
    static Packet Receiver() { receivers++; return null; }
    static int Next() { initializers++; return 4; }
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        bool caught = false;
        try { Packet changed = Receiver() with { Value = Next() }; }
        catch (NullReferenceException) { caught = true; }
        Check(caught, "null-clone-exception");
        Check(receivers == 1, "null-receiver-once");
        Check(initializers == 0, "no-initializer-after-null-clone");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
