/*
Rules: P10-struct-constructor-create
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 4
Mutate: public Signal() { Calls++; Code = 43; }
Into: public Signal() { Calls++; Code = 0; }
*/
using System;
readonly record struct Signal
{
    public static int Calls;
    public readonly int Code;
    public Signal() { Calls++; Code = 43; }
}
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Signal a = new Signal();
        Check(a.Code == 43, "parameterless-body-value");
        Check(Signal.Calls == 1, "first-constructor-once");
        Signal b = new Signal();
        Check(b.Code == 43, "second-body-value");
        Check(Signal.Calls == 2, "second-constructor-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
