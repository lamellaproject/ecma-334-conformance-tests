/*
Rules: E12-2-1-void-nothing
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Action action = () => Touch();
Into: Action action = () => { };
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Touch() { calls++; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Touch();
        Action action = () => Touch();
        action();
        Check(calls == 2, "void-expression-contexts");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
