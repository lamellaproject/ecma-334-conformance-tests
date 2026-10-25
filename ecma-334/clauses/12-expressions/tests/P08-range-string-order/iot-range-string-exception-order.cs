/*
Rules: P08-range-string-order
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 6
Mutate: string slice = Receiver()[Start(true)..End(false)];
Into: string slice = Receiver()[Start(false)..End(false)];
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
    static string Receiver() { trace += "r"; return "LAMPERA"; }
    static string BadReceiver() { trace += "r"; throw marker; }
    static int Start(bool fail) { trace += "s"; if (fail) throw marker; return 1; }
    static int End(bool fail) { trace += "e"; if (fail) throw marker; return 5; }
    static int Main()
    {
        bool caught = false;
        try { string slice = BadReceiver()[Start(false)..End(false)]; if (slice.Length == 0) trace += "unexpected"; }
        catch (MarkerException value) { caught = object.ReferenceEquals(value, marker); }
        Check(caught, "receiver-exception-identity");
        Check(trace == "r", "receiver-throw-skips-bounds");
        trace = "";
        caught = false;
        try
        {
            string slice = Receiver()[Start(true)..End(false)];
            if (slice.Length == 0) trace += "unexpected";
        }
        catch (MarkerException value) { caught = object.ReferenceEquals(value, marker); }
        Check(caught, "start-exception-identity");
        Check(trace == "rs", "start-throw-skips-end");
        trace = "";
        caught = false;
        try { string slice = Receiver()[Start(false)..End(true)]; if (slice.Length == 0) trace += "unexpected"; }
        catch (MarkerException value) { caught = object.ReferenceEquals(value, marker); }
        Check(caught, "end-exception-identity");
        Check(trace == "rse", "end-throw-after-receiver-and-start");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
