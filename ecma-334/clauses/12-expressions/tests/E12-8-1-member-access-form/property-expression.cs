/*
Rules: E12-8-1-member-access-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: worker.Value
Into: 3
*/
using System;
class Worker
{
    public int calls;
    public int Value { get { calls++; return 3; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Worker worker = new Worker();
        int result = worker.Value;
        Check(result == 3, "member-access-is-primary-expression");
        Check(worker.calls == 1, "member-access-invokes-accessor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
