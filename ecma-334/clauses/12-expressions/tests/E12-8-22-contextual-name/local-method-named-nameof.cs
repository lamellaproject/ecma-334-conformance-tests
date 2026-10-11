/*
Rules: E12-8-22-contextual-name; E12-8-22-invocation-priority
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static string nameof(int value)
Into: static string named(int value)
*/
using System;
class Program
{
    static int calls, argument;
    static string nameof(int value) { calls++; argument = value; return "called"; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int count = 7;
        string name = nameof(count);
        Check(name == "called", "successful-name-lookup-is-invocation");
        Check(calls == 1 && argument == 7, "nameof-identifier-method-evaluates-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
