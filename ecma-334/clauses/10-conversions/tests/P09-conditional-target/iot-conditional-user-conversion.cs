/*
Rules: P09-conditional-target
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: choose ? Alpha() : Beta()
Into: !choose ? Alpha() : Beta()
*/
using System;
struct AlphaValue { public int Value; }
struct BetaValue { public int Value; }
struct Packet
{
    public int Value;
    public static implicit operator Packet(AlphaValue value) { Program.trace = Program.trace * 10 + 4; return new Packet { Value = value.Value }; }
    public static implicit operator Packet(BetaValue value) { Program.trace = Program.trace * 10 + 5; return new Packet { Value = value.Value }; }
}
class Program
{
    static int checks, failures;
    public static int trace;
    static AlphaValue Alpha() { trace = trace * 10 + 2; return new AlphaValue { Value = 61 }; }
    static BetaValue Beta() { trace = trace * 10 + 3; return new BetaValue { Value = 83 }; }
    static Packet Select(bool choose) { return choose ? Alpha() : Beta(); }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Packet first = Select(true);
        Check(first.Value == 61, "true-return-target-value");
        Check(trace == 24, "true-evaluate-then-convert-once");
        trace = 0;
        Packet second = Select(false);
        Check(second.Value == 83, "false-return-target-value");
        Check(trace == 35, "false-evaluate-then-convert-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
