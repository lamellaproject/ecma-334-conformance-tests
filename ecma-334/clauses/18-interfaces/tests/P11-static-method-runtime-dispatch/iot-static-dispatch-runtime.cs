/*
Rules: P11-static-method-runtime-dispatch; E12-6-2-3-argument-order; E12-6-6-1-static-arguments; E12-6-6-1-static-invoke
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 5
Mutate: return T.Combine(second: Stamp(2), first: Stamp(1));
Into: return Envelope.Combine(second: Stamp(2), first: Stamp(1));
*/
using System;
// Proposal L187: actual type selects the static method after lexical arguments.
interface ICombiner { static abstract int Combine(int first, int second); }
struct Parcel : ICombiner
{
    public static int Combine(int first, int second) { Program.trace = Program.trace * 10 + 3; return first * 10 + second; }
}
class Envelope : ICombiner
{
    public static int Combine(int first, int second) { Program.trace = Program.trace * 10 + 4; return first + second; }
}
struct Broken : ICombiner
{
    public static int Combine(int first, int second) { Program.trace = Program.trace * 10 + 5; throw Program.marker; }
}
class Program
{
    static int checks, failures;
    internal static int trace;
    internal static readonly InvalidOperationException marker = new InvalidOperationException();
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Stamp(int value) { trace = trace * 10 + value; return value; }
    static int Combine<T>() where T : ICombiner { return T.Combine(second: Stamp(2), first: Stamp(1)); }
    static int Main()
    {
        trace = 0; int parcel = Combine<Parcel>();
        Check(parcel == 12 && trace == 213, "struct-selection-after-arguments");
        trace = 0; int envelope = Combine<Envelope>();
        Check(envelope == 3 && trace == 214, "class-selection-after-arguments");
        trace = 0; bool caught = false, same = false;
        try { Combine<Broken>(); }
        catch (InvalidOperationException error) { caught = true; same = ReferenceEquals(error, marker); }
        Check(caught, "typed-exception");
        Check(same, "exception-identity");
        Check(trace == 215, "throwing-implementation-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
