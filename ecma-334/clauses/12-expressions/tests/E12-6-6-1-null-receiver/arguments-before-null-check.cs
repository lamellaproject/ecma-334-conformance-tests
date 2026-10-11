/*
Rules: E12-6-6-1-null-receiver; E12-6-6-1-other-arguments; E12-6-6-1-other-instance-evaluation
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return null;
Into: return new Worker();
*/
using System;
class Worker
{
    public int Pick(int amount) { Program.trace = Program.trace * 10 + 3; return amount; }
}
class Program
{
    static int checks, failures;
    public static int trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Worker Receiver() { trace = trace * 10 + 1; return null; }
    static int Argument() { trace = trace * 10 + 2; return 4; }
    static void Main()
    {
        bool caught = false;
        try { Receiver().Pick(Argument()); }
        catch (NullReferenceException) { caught = true; }
        catch (Exception) { }
        Check(caught, "null-receiver-throws-null-reference-exception");
        Check(trace == 12, "null-check-follows-arguments-and-skips-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
