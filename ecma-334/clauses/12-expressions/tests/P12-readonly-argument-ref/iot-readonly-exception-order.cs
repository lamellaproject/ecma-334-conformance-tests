/*
Rules: P12-readonly-argument-ref; E12-6-2-3-argument-order
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 4
Mutate: int observed = Read(ref Pick(true), Next());
Into: int observed = Read(ref Pick(false), Next());
*/
using System;
sealed class MarkerException : Exception { }
class Test
{
    static int checks, failures, cell = 11;
    static string trace = "";
    static MarkerException marker = new MarkerException();
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static ref int Pick(bool fail) { trace += "a"; if (fail) throw marker; return ref cell; }
    static int Next() { trace += "b"; return 5; }
    static int Read(ref readonly int value, int ignored) { trace += "c"; return value; }
    static int Throw(ref readonly int value) { trace += "c"; throw marker; }
    static int Main()
    {
        bool caught = false;
        try { int observed = Read(ref Pick(true), Next()); if (observed == 0) trace += "unexpected"; }
        catch (MarkerException value) { caught = object.ReferenceEquals(value, marker); }
        Check(caught, "argument-exception-identity");
        Check(trace == "a", "first-argument-throw-skips-later-argument-and-body");
        caught = false;
        trace = "";
        try { int observed = Throw(ref Pick(false)); if (observed == 0) trace += "unexpected"; }
        catch (MarkerException value) { caught = object.ReferenceEquals(value, marker); }
        Check(caught, "callee-exception-identity");
        Check(trace == "ac", "callee-throw-after-location-evaluation");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
