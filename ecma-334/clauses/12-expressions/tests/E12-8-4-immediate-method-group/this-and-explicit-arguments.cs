/*
Rules: E12-8-4-immediate-method-group; E12-8-4-method-type-arguments; E12-8-4-member-lookup; E12-8-4-syntax
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Pick<int>()
Into: Pick<string>()
*/
using System;
class Worker
{
    public int calls;
    object Pick<T>() { calls++; return default(T); }
    public object Resolve() { return Pick<int>(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Worker worker = new Worker();
        object result = worker.Resolve();
        Check(result is int && (int)result == 0, "simple-method-group-uses-explicit-type-arguments");
        Check(worker.calls == 1, "simple-method-group-has-current-this-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
