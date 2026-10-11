/*
Rules: E12-6-6-1-constructor-instance; E12-6-6-1-constructor-result; E12-6-6-1-instance-category; E12-6-6-1-instance-this
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new Worker(Argument())
Into: new Worker(8)
*/
using System;
class Worker
{
    public static Worker seen;
    public int value;
    public Worker(int value) { seen = this; this.value = value; Program.trace = Program.trace * 10 + 2; }
}
class Program
{
    static int checks, failures;
    public static int trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Argument() { trace = trace * 10 + 1; return 3; }
    static void Main()
    {
        Worker result = new Worker(Argument());
        Check(trace == 12, "constructor-arguments-precede-constructor-body");
        Check(result == Worker.seen, "constructed-result-is-constructor-this");
        Check(result.value == 3, "constructor-writes-new-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
