/*
Rules: E12-6-6-1-instance-this; E12-6-6-1-instance-category; E12-6-6-1-object-invoke
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: first.Self
Into: second.Self
*/
using System;
class Worker
{
    public int calls;
    public Worker Self { get { calls++; return this; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Worker first = new Worker(), second = new Worker();
        Worker result = first.Self;
        Check(result == first, "property-this-is-receiver-object");
        Check(first.calls == 1 && second.calls == 0, "property-writes-only-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
