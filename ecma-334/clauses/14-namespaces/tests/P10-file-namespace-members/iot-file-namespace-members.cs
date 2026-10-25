/*
Rules: P10-file-namespace-members
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 2
Fixture: {"program":{"units":[{"source":"self"},{"source":"tests/P10-file-namespace-members/iot-file-namespace-counter.cs.part"}]}}
Mutate: namespace Workshop.Deck;
Into: namespace Workshop.Decoy;
*/
using System;
namespace Workshop.Deck;

class Cargo
{
    public static int Read() { return Counter.Marker; }
}

class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Cargo.Read() == 37, "type-relative-lookup");
        Check(Counter.Marker == 37, "same-namespace-contribution");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
