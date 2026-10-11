/*
Rules: E20-1-instance-callable-entity; E20-5-instance-target; E20-5-nonnull-instance-target
Authority: ECMA-334 7th ed 20.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operation = first.Touch
Into: operation = second.Touch
*/
using System;
delegate void Operation();
class Counter { public int Value; public void Touch() { Value++; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter first = new Counter(); Counter second = new Counter();
        Operation operation = first.Touch; operation();
        Check(first.Value == 1, "captured-receiver");
        Check(second.Value == 0, "other-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
