/*
Rules: E12-9-8-1-suspend-until-complete; E12-9-8-1-form; E12-9-8-1-task-definition; E12-9-8-2-awaiter-definition; E12-9-8-2-oncompleted-role; E12-9-8-3-value-classification; E12-9-8-4-getawaiter; E12-9-8-4-iscompleted; E12-9-8-4-oncompleted; E12-9-8-4-suspend; E12-9-8-4-return-control; E12-9-8-4-resumed-getresult; E12-9-8-4-value-result; E12-9-1-form-await; E12-9-1-unary-operators
Authority: ECMA-334 7th ed 12.9.8.1
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: await Operand()
Into: Operand().GetAwaiter().GetResult()
*/
using System;
using System.Runtime.CompilerServices;
struct Carrier { public Waiter GetAwaiter() { Program.Trace += "G"; return new Waiter(); } }
struct Waiter : INotifyCompletion
{
    public bool IsCompleted { get { Program.Trace += "I"; return false; } }
    public void OnCompleted(Action continuation) { Program.Trace += "C"; Program.Continuation = continuation; }
    public int GetResult() { Program.Trace += "R"; return 17; }
}
class Program
{
    public static string Trace = "";
    public static Action Continuation;
    static int result, completions;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Carrier Operand() { Trace += "E"; return new Carrier(); }
    static async void Worker() { Trace += "B"; result = await Operand(); completions++; Trace += "Z"; }
    static void Main()
    {
        Worker(); Trace += "X";
        Check(Trace == "BEGICX", "suspended-caller-regains-control"); Check(result == 0 && completions == 0, "not-complete-before-callback");
        Check(Continuation != null, "registered-resumption-delegate");
        if (Continuation != null) Continuation();
        Check(Trace == "BEGICXRZ", "getresult-only-after-resumption"); Check(result == 17 && completions == 1, "typed-result-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
