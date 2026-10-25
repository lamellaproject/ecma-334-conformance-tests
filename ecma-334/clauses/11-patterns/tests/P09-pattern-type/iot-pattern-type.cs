/*
Rules: P09-pattern-type
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: case Beacon:
Into: case Decoy:
*/
using System;
class Beacon { }
class SmallBeacon : Beacon { }
class Decoy { }
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static bool Match(object value)
    {
        switch (value) { case Beacon: return true; default: return false; }
    }
    static int Main()
    {
        Check(Match(new Beacon()), "exact-type");
        Check(Match(new SmallBeacon()), "derived-type");
        Check(!Match(new Decoy()), "unrelated-type");
        Check(!Match(null), "null-input");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
