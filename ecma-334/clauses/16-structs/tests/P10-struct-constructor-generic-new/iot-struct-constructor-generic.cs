/*
Rules: P10-struct-constructor-generic-new
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 4
Mutate: public Measure() { Calls++; Code = 71; }
Into: public Measure() { Calls++; Code = 0; }
*/
using System;
readonly record struct Measure
{
    public static int Calls;
    public readonly int Code;
    public Measure() { Calls++; Code = 71; }
}
class Program
{
    static int checks, failures;
    static T MakeNew<T>() where T : new() { return new T(); }
    static T MakeStruct<T>() where T : struct { return new T(); }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Measure a = MakeNew<Measure>();
        Check(a.Code == 71, "new-constraint-activation");
        Check(Measure.Calls == 1, "new-constraint-once");
        Measure b = MakeStruct<Measure>();
        Check(b.Code == 71, "struct-constraint-activation");
        Check(Measure.Calls == 2, "struct-constraint-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
