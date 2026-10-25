/*
Rules: P10-natural-var; P10-natural-action; E10-7-2-capture
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Mutate: (int amount) => { state += amount; Seen = state; }
Into: (int amount) => { state -= amount; Seen = state; }
*/
using System;
class Program
{
    static int Seen, checks, failures;
    static Action<int> Create()
    {
        int state = 8;
        var update = (int amount) => { state += amount; Seen = state; };
        state = 12;
        return update;
    }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Action<int> action = Create();
        Check(Seen == 0, "escaped-creation-defers-effects");
        action(3);
        Check(Seen == 15, "escaped-capture-current-state");
        action(2);
        Check(Seen == 17, "escaped-capture-persists-mutation");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
