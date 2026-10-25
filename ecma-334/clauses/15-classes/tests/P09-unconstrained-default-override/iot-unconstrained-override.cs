/*
Rules: P09-unconstrained-default-override
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: public override T? Read<T>(T? input) where T : default
Into: public new T? Read<T>(T? input)
*/
#nullable enable
using System;

class Reader
{
    public virtual T? Read<T>(T? input) { return input; }
}
class CountingReader : Reader
{
    public int Calls;
    public override T? Read<T>(T? input) where T : default
    {
        Calls++;
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
        CountingReader implementation = new CountingReader();
        Reader reader = implementation;
        string? text = reader.Read<string>(null);
        int value = reader.Read<int>(53);
        int? empty = reader.Read<int?>(null);
        Check(text == null, "override-reference-null");
        Check(value == 53, "override-value-not-wrapped");
        Check(!empty.HasValue, "override-nullable-value");
        Check(implementation.Calls == 3, "default-constraint-preserves-dispatch");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
