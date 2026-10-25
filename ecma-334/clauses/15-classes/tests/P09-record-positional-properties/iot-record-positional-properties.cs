/*
Rules: P09-record-positional-properties
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Mutate: record Gauge(int Depth, string Name);
Into: record Gauge(int Depth, string Name) { public int Depth { get; init; } = Depth + 1; }
*/
using System;
record Gauge(int Depth, string Name);
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
        Gauge a = new Gauge(23, "east");
        Check(a.Depth == 23, "numeric-parameter");
        Check(a.Name == "east", "reference-parameter");
        Gauge b = new Gauge(4, "west") { Name = "deck" };
        Check(b.Name == "deck" && b.Depth == 4, "init-property");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
