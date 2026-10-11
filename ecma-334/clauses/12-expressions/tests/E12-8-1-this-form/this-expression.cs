/*
Rules: E12-8-1-this-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return this;
Into: return new Worker();
*/
using System;
class Worker { public Worker Self() { return this; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Worker worker = new Worker();
        Worker result = worker.Self();
        Check(result == worker, "this-is-primary-expression-for-current-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
