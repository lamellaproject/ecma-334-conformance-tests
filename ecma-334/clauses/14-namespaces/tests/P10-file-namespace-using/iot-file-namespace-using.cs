/*
Rules: P10-file-namespace-using
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 1
Fixture: {"program":{"units":[{"source":"self"},{"source":"tests/P10-file-namespace-members/iot-file-namespace-counter.cs.part"}]}}
Mutate: using Dial = Workshop.Decoy.Counter;
Into: using Dial = Workshop.Deck.Counter;
*/
using System;
using Dial = Workshop.Deck.Counter;
namespace Workshop.Decoy;
using Dial = Workshop.Decoy.Counter;

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
        Check(Dial.Marker == -37, "namespace-body-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
