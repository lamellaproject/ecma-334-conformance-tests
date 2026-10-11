/*
Rules: E12-9-8-4-critical-check-dynamic; E12-9-8-2-dynamic-awaitable
Authority: ECMA-334 7th ed 12.9.8.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: dynamic carrier = new Carrier()
Into: Carrier carrier = new Carrier()
*/
using System;
using System.Runtime.CompilerServices;
public class Carrier
{
    public Ordinary GetAwaiter() { return Program.CriticalMode ? new Critical() : new Ordinary(); }
}
public class Ordinary : INotifyCompletion
{
    public bool IsCompleted { get { return false; } }
    public void OnCompleted(Action continuation) { Program.Trace += "C"; Program.Continuation = continuation; }
    public int GetResult() { Program.Trace += "R"; return 13; }
}
public class Critical : Ordinary, ICriticalNotifyCompletion
{
    public void UnsafeOnCompleted(Action continuation) { Program.Trace += "U"; Program.Continuation = continuation; }
}
class Program
{
    public static string Trace = "";
    public static bool CriticalMode;
    public static Action Continuation;
    static int result;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static async void Worker() { dynamic carrier = new Carrier(); result = await carrier; }
    static void Main()
    {
        Worker(); Check(Trace == "C", "runtime-noncritical-choice");
        if (Continuation != null) Continuation();
        Check(Trace == "CR" && result == 13, "runtime-noncritical-result");
        Trace = ""; result = 0; Continuation = null; CriticalMode = true;
        Worker(); Check(Trace == "U", "runtime-critical-choice");
        if (Continuation != null) Continuation();
        Check(Trace == "UR" && result == 13, "runtime-critical-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
