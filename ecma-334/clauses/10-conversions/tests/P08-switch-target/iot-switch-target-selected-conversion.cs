/*
Rules: P08-switch-target; P08-switch-selected
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 5
Mutate: 0 => MakeAmber(37)
Into: 0 => MakeViolet(41)
*/
using System;

// patterns.md L297/L303: each unrelated arm converts to the supplied destination;
// only the selected construction and conversion execute.
class Result
{
    public int Value;
    public Result(int value) { Value = value; }
}
class Amber
{
    public int Value;
    public Amber(int value) { Value = value; }
    public static implicit operator Result(Amber value)
    {
        Program.Conversions++; Program.Trace = Program.Trace * 10 + 4;
        return new Result(value.Value);
    }
}
class Violet
{
    public int Value;
    public Violet(int value) { Value = value; }
    public static implicit operator Result(Violet value)
    {
        Program.Conversions++; Program.Trace = Program.Trace * 10 + 5;
        return new Result(value.Value);
    }
}
class Program
{
    public static int Trace, Conversions;
    static int checks, failures, inputs;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Read(int value) { inputs++; Trace = Trace * 10 + 1; return value; }
    static Amber MakeAmber(int value) { Trace = Trace * 10 + 2; return new Amber(value); }
    static Violet MakeViolet(int value) { Trace = Trace * 10 + 3; return new Violet(value); }
    static int Main()
    {
        Result first = Read(0) switch { 0 => MakeAmber(37), _ => MakeViolet(41) };
        Check(first.Value == 37, "first-arm-converts-to-destination");
        Check(Trace == 124, "first-input-construction-conversion-order");
        Trace = 0;
        Result second = Read(1) switch { 0 => MakeAmber(43), _ => MakeViolet(47) };
        Check(second.Value == 47, "second-arm-converts-to-destination");
        Check(Trace == 135, "second-input-construction-conversion-order");
        Check(inputs == 2 && Conversions == 2, "one-input-and-conversion-per-evaluation");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
