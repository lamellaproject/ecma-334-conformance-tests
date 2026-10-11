/*
Rules: E12-6-6-1-instance-category; E12-6-6-1-instance-this; E12-6-6-1-object-invoke
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: first[3]
Into: second[3]
*/
using System;
class Worker
{
    public int seen;
    public Worker this[int index] { get { seen = index; return this; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Worker first = new Worker(), second = new Worker();
        Worker result = first[3];
        Check(result == first, "indexer-this-is-receiver-object");
        Check(first.seen == 3 && second.seen == 0, "indexer-receives-argument-on-selected-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
