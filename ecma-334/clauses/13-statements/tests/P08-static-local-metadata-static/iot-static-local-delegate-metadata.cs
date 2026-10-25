/*
Rules: P08-static-local-metadata-static
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: static int Transform(int value) { return value + 7; }
Into: int Transform(int value) { return value + delta; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int delta = 7;
        static int Transform(int value) { return value + 7; }
        Func<int, int> action = Transform;
        Check(delta == 7, "static-local-enclosing-value-retained");
        Check(action(5) == 12, "static-local-delegate-invocation");
        Check(action.Method.IsStatic, "static-local-delegate-method-is-static");
        Check(action.Target == null, "static-local-delegate-has-no-target");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
