/*
Rules: P10-handler-arguments; P10-handler-constructor; P10-handler-result
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 5
Mutate: [InterpolatedStringHandlerArgument("", "right", "left")]
Into: [InterpolatedStringHandlerArgument("", "left", "right")]
*/
using System;
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct Capture
{
    public Receiver Owner;
    public int First, Second, Number;
    public Capture(int length, int holes, Receiver owner, int first, int second)
    {
        Program.Trace += "C"; Owner = owner; First = first; Second = second; Number = 0;
    }
    public void AppendFormatted(int value) { Program.Trace += "F"; Number = value; }
}
class Receiver
{
    public void Accept(int left, int right, [InterpolatedStringHandlerArgument("", "right", "left")] Capture item, int tail)
    {
        Program.Trace += "M"; Program.Observed = item;
        Program.Arguments = left * 100 + right * 10 + tail;
    }
}
class Program
{
    public static string Trace = "";
    public static Capture Observed;
    public static int Arguments;
    static int checks, failures;
    static Receiver owner = new Receiver();
    static Receiver GetReceiver() { Trace += "R"; return owner; }
    static int Read(int value, string marker) { Trace += marker; return value; }
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        GetReceiver().Accept(Read(2, "L"), Read(7, "Q"), $"{Read(4, "H")}", Read(8, "T"));
        Check(Trace == "RLQCHFTM", "lexical-order-before-method");
        Check(ReferenceEquals(Observed.Owner, owner), "receiver-once-and-identical");
        Check(Observed.First == 7 && Observed.Second == 2, "attribute-array-order");
        Check(Observed.Number == 4, "formatted-value");
        Check(Arguments == 278, "ordinary-arguments-reused");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
