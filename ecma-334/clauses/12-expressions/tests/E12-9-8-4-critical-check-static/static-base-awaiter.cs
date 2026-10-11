/*
Rules: E12-9-8-4-critical-check-static
Authority: ECMA-334 7th ed 12.9.8.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public Ordinary GetAwaiter()
Into: public Critical GetAwaiter()
*/
using System;
using System.Runtime.CompilerServices;
struct Carrier { public Ordinary GetAwaiter() { return new Critical(); } }
class Ordinary : INotifyCompletion
{
    public bool IsCompleted { get { return false; } }
    public void OnCompleted(Action continuation) { Program.Trace += "C"; Program.Continuation = continuation; }
    public int GetResult() { Program.Trace += "R"; return 7; }
}
class Critical : Ordinary, ICriticalNotifyCompletion
{
    public void UnsafeOnCompleted(Action continuation) { Program.Trace += "U"; Program.Continuation = continuation; }
}
class Program
{
    public static string Trace = "";
    public static Action Continuation;
    static int result;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static async void Worker() { result = await new Carrier(); }
    static void Main()
    {
        Worker();
        Check(Trace == "C", "statically-noncritical-even-if-runtime-critical");
        Check(Continuation != null && result == 0, "suspended");
        if (Continuation != null) Continuation();
        Check(Trace == "CR" && result == 7, "resumed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
