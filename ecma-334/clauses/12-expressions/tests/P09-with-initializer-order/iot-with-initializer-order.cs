/*
Rules: P09-with-initializer-order; P09-with-member-assignment
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
Mutate: Settings changed = Receiver() with { A = Read(2, "X"), B = Read(5, "Y") };
Into: Settings changed = Receiver() with { B = Read(5, "Y"), A = Read(2, "X") };
*/
using System;
record Settings
{
    int a, b;
    public int SeenA;
    public Settings() { a = 7; b = 9; }
    protected Settings(Settings source) : base() { Program.Trace += "C"; a = source.a; b = source.b; SeenA = source.SeenA; }
    public int A { get { return a; } init { Program.Trace += "A"; a = value; } }
    public int B { get { return b; } init { Program.Trace += "B"; SeenA = a; b = value; } }
}
class Program
{
    public static string Trace = "";
    static Settings original = new Settings();
    static int checks, failures, receivers, reads;
    static Settings Receiver() { receivers++; Trace += "R"; return original; }
    static int Read(int value, string marker) { reads++; Trace += marker; return value; }
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        Settings changed = Receiver() with { A = Read(2, "X"), B = Read(5, "Y") };
        Check(Trace == "RCXAYB", "receiver-copy-and-assignment-order");
        Check(receivers == 1 && reads == 2, "expressions-once");
        Check(changed.A == 2 && changed.B == 5, "assigned-values");
        Check(changed.SeenA == 2, "later-accessor-sees-earlier-assignment");
        Check(original.A == 7 && original.B == 9, "original-state-preserved");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
