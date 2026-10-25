/*
Rules: P08-range-string-null; P08-range-string-order
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: string slice = Receiver()[Read(1)..Read(2)];
Into: string slice = "LAMPERA"[Read(1)..Read(2)];
*/
using System;
sealed class MarkerException : Exception { }
class Test
{
    static int checks, failures;
    static string trace = "";
    static MarkerException marker = new MarkerException();
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static string Receiver() { trace += "r"; return null; }
    static int Read(int value) { trace += value == 1 ? "s" : "e"; return value; }
    static int BadEnd() { trace += "e"; throw marker; }
    static int Main()
    {
        bool caught = false;
        try { string slice = Receiver()[Read(1)..Read(2)]; if (slice.Length == 0) trace += "unexpected"; }
        catch (NullReferenceException) { caught = true; }
        Check(caught, "null-receiver-exception");
        Check(trace == "rse", "null-checked-after-both-bounds");
        trace = "";
        caught = false;
        try { string slice = Receiver()[Read(1)..BadEnd()]; if (slice.Length == 0) trace += "unexpected"; }
        catch (MarkerException value) { caught = object.ReferenceEquals(value, marker); }
        Check(caught, "bound-exception-precedes-null-check");
        Check(trace == "rse", "throwing-bound-evaluated-on-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
