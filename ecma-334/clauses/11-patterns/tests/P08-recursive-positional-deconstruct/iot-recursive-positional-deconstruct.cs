/*
Rules: P08-recursive-positional-deconstruct
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: Probe(13, var tail)
Into: Probe(14, var tail)
*/
using System;
class Probe
{
    public int Calls;
    public void Deconstruct(out int head, out int tail) { Calls++; head = 13; tail = 29; }
    public void Deconstruct(out int head, out int middle, out int tail)
    { Calls += 100; head = 1; middle = 2; tail = 3; }
}
class Program
{
    static int checks, failures, inputs;
    static object source;
    static object Take() { inputs++; return source; }
    static bool Matches()
    {
        return Take() is Probe(13, var tail) && tail == 29;
    }
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Probe probe = new Probe(); source = probe; inputs = 0;
        Check(Matches() && inputs == 1 && probe.Calls == 1, "deconstruct-selected-outputs");
        Check(!(probe is Probe(13, 30)) && probe.Calls == 2, "output-subpattern-mismatch");
        source = new object(); inputs = 0;
        Check(!Matches() && inputs == 1 && probe.Calls == 2, "wrong-type-no-deconstruct");
        source = null; inputs = 0;
        Check(!Matches() && inputs == 1 && probe.Calls == 2, "null-no-deconstruct");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
