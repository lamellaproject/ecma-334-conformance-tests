/*
Rules: E12-8-7-1-instance-method-group; E12-8-7-1-instance-lookup
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Pick call = first.Read;
Into: Pick call = second.Read;
*/
using System;
delegate int Pick();
class Worker
{
    public int value, calls;
    public int Read() { calls++; return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Worker first = new Worker { value = 3 }, second = new Worker { value = 8 };
        Pick call = first.Read;
        Check(call.Target == first, "instance-method-group-captures-receiver");
        Check(call() == 3, "captured-instance-method-group-returns-receiver-value");
        Check(first.calls == 1 && second.calls == 0, "captured-method-modifies-selected-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
