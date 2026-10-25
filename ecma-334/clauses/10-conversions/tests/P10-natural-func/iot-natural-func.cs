/*
Rules: P10-natural-func; P10-natural-lambda; P10-natural-var
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 4
Mutate: var measure = (short step) =>
Into: var measure = (int step) =>
*/
using System;
class Program
{
    static int checks, failures;
    static bool IsShortIntFunc<T>(T function) { return typeof(T) == typeof(Func<short, int>); }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int calls = 0, bias = 13;
        var measure = (short step) => { calls++; return bias + step; };
        Check(IsShortIntFunc(measure), "natural-func-parameter-and-return-type");
        Check(calls == 0, "func-body-deferred");
        int result = measure((short)4);
        Check(result == 17 && calls == 1, "inferred-return-and-single-invocation");
        bias = 20;
        Check(measure((short)(-2)) == 18 && calls == 2, "func-sees-current-capture");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
