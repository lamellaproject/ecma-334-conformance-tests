/*
Rules: E12-6-6-1-other-instance-evaluation; E12-6-6-1-other-arguments; E12-6-6-1-object-invoke; E12-6-6-1-member-result
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Receiver().Pick(Argument())
Into: original.Pick(Argument())
*/
using System;
class Worker
{
    public Worker seen;
    public int Pick(int amount) { Program.trace = Program.trace * 10 + 3; seen = this; return amount + 3; }
}
class Program
{
    static int checks, failures;
    public static int trace;
    static Worker original = new Worker();
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Worker Receiver() { trace = trace * 10 + 1; return original; }
    static int Argument() { trace = trace * 10 + 2; return 4; }
    static void Main()
    {
        int result = Receiver().Pick(Argument());
        Check(trace == 123, "class-receiver-before-argument-before-body");
        Check(result == 7, "class-member-result");
        Check(original.seen == original, "this-aliases-receiver-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
