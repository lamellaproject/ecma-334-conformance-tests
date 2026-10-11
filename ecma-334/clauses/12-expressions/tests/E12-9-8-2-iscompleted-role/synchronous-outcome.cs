/*
Rules: E12-9-8-2-iscompleted-role; E12-9-8-2-getresult-role; E12-9-8-4-completed-getresult
Authority: ECMA-334 7th ed 12.9.8.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: await new Carrier()
Into: new Carrier().GetAwaiter().GetResult()
*/
using System;
using System.Runtime.CompilerServices;
struct Carrier { public Waiter GetAwaiter() { Program.Trace += "G"; return new Waiter(); } }
struct Waiter : INotifyCompletion
{
    public bool IsCompleted { get { Program.Trace += "I"; return true; } }
    public void OnCompleted(Action continuation) { Program.Trace += "C"; }
    public int GetResult() { Program.Trace += "R"; if (Program.Throw) throw new InvalidOperationException(); return 19; }
}
class Program
{
    public static string Trace = "";
    public static bool Throw;
    static int result;
    static bool caught, wrong;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static async void Worker()
    {
        try { result = await new Carrier(); Trace += "Z"; }
        catch (InvalidOperationException) { caught = true; Trace += "T"; }
        catch (Exception) { wrong = true; }
    }
    static void Main()
    {
        Worker(); Trace += "X";
        Check(result == 19, "completed-value"); Check(Trace == "GIRZX", "completed-inline-no-registration");
        Trace = ""; Throw = true; Worker(); Trace += "X";
        Check(caught && !wrong, "getresult-exception-type"); Check(Trace == "GIRTX", "exception-before-return-to-caller");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
