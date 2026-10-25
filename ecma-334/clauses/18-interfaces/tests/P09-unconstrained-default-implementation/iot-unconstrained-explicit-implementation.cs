/*
Rules: P09-unconstrained-default-implementation
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: T? IRelay.Read<T>(T? input) where T : default
Into: T? Alternate<T>(T? input)
*/
#nullable enable
using System;

interface IRelay
{
    T? Read<T>(T? input);
}
class Relay : IRelay
{
    public int ExplicitCalls;
    public T? Read<T>(T? input) { return input; }
    T? IRelay.Read<T>(T? input) where T : default
    {
        ExplicitCalls++;
        return input;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool good, string name)
    {
        checks++;
        if (!good) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Relay relay = new Relay();
        IRelay view = relay;
        string? text = view.Read<string>(null);
        int value = view.Read<int>(59);
        int? empty = view.Read<int?>(null);
        Check(text == null, "explicit-reference-null");
        Check(value == 59, "explicit-value-not-wrapped");
        Check(!empty.HasValue, "explicit-nullable-value");
        Check(relay.ExplicitCalls == 3, "default-explicit-method-selection");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
