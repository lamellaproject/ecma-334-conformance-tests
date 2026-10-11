/*
Rules: E9-6-read-modify-write-atomicity
Authority: ECMA-334 7th ed 9.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: shared--;
Into: shared = -1;
*/
using System;
using System.Threading;
class Program
{
    static int checks, failures, shared;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Increment() { for (int i = 0; i < 20000; i++) shared++; }
    static void Main()
    {
        Thread a = new Thread(Increment), b = new Thread(Increment);
        a.Start(); b.Start();
        a.Join(); b.Join();
        shared--;
        // Lost updates and a fully atomic implementation are both permitted.
        Check(shared >= 0 && shared < 40000, "read-modify-write-allows-any-count-within-operation-bounds");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
