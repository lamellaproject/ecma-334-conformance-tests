/*
Rules: P09-conditional-target; E12-18-value-condition-first; E12-18-value-true-arm; E12-18-value-false-arm
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: Flag(true) ? Left() : Right()
Into: Flag(false) ? Left() : Right()
*/
using System;
class Root { }
sealed class LeafA : Root { }
sealed class LeafB : Root { }
class Program
{
    static int checks, failures, trace;
    static readonly LeafA a = new LeafA();
    static readonly LeafB b = new LeafB();
    static bool Flag(bool value) { trace = trace * 10 + 1; return value; }
    static LeafA Left() { trace = trace * 10 + 2; return a; }
    static LeafB Right() { trace = trace * 10 + 3; return b; }
    static Root Relay(Root value) { return value; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Root first = Flag(true) ? Left() : Right();
        Check(object.ReferenceEquals(first, a), "true-identity");
        Check(trace == 12, "condition-before-true-only");
        trace = 0;
        Root second = Relay(Flag(false) ? Left() : Right());
        Check(object.ReferenceEquals(second, b), "false-argument-identity");
        Check(trace == 13, "condition-before-false-only");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
