/*
Rules: E12-9-8-2-pattern-getawaiter; E12-9-8-4-getawaiter; E12-9-8-4-iscompleted; E12-9-8-4-completed-getresult
Authority: ECMA-334 7th ed 12.9.8.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: await Operand()
Into: Operand().GetAwaiter().GetResult()
*/
using System;
using System.Runtime.CompilerServices;
struct Parcel
{
    public int Value;
    public Parcel(int value) { Value = value; }
}
static class ParcelAccess
{
    public static Waiter GetAwaiter(this Parcel value)
    {
        Program.Calls++; Program.Trace += "G";
        return new Waiter(value.Value);
    }
}
struct Waiter : INotifyCompletion
{
    int value;
    public Waiter(int value) { this.value = value; }
    public bool IsCompleted { get { Program.Trace += "I"; return true; } }
    public void OnCompleted(Action continuation) { Program.Trace += "C"; }
    public int GetResult() { Program.Trace += "R"; return value; }
}
class Program
{
    public static string Trace = "";
    public static int Calls;
    static int source, result, checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static Parcel Operand() { Trace += "E"; return new Parcel(source); }
    static async void Worker() { result = await Operand(); Trace += "Z"; }
    static void Main()
    {
        source = 23; Worker(); Trace += "X";
        Check(Trace == "EGIRZX", "extension-await-order");
        Check(result == 23, "extension-await-result");
        Check(Calls == 1, "extension-getawaiter-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
