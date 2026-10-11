/*
Rules: E12-9-8-3-void-classification; E12-9-8-4-void-result
Authority: ECMA-334 7th ed 12.9.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: await new Carrier()
Into: new Carrier().GetAwaiter().GetResult()
*/
using System;
using System.Runtime.CompilerServices;
struct Carrier { public Waiter GetAwaiter() { Program.Trace += "G"; return new Waiter(); } }
struct Waiter : INotifyCompletion
{
    public bool IsCompleted { get { Program.Trace += "I"; return true; } }
    public void OnCompleted(Action continuation) { Program.Registrations++; Program.Trace += "C"; }
    public void GetResult() { Program.Trace += "R"; }
}
class Program
{
    public static string Trace = "";
    public static int Registrations;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static async void Worker() { await new Carrier(); Trace += "Z"; }
    static void Main()
    {
        Worker(); Trace += "X";
        Check(Trace == "GIRZX", "void-await-is-statement"); Check(Registrations == 0, "no-continuation-for-complete-task");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
