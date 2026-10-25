/*
Rules: P10-natural-lambda; P10-natural-var; P10-natural-action
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Mutate: (int value) => { calls++; if (value < 0) throw marker; }
Into: (int value) => { calls++; if (value > 0) throw marker; }
*/
using System;
class Signal : Exception { }
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
        int calls = 0;
        Signal marker = new Signal();
        var validate = (int value) => { calls++; if (value < 0) throw marker; };
        Check(calls == 0, "throwing-body-deferred");
        bool caught = false;
        try { validate(-1); }
        catch (Signal value) { caught = Object.ReferenceEquals(value, marker); }
        Check(caught, "invocation-preserves-exception-type-and-identity");
        Check(calls == 1, "throwing-invocation-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
