/*
Rules: E15-3-8-separate-instance-storage; E15-3-8-instance-classification; E15-3-8-static-or-instance
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: private int stored;
Into: private static int stored;
*/
using System;
class Counter
{
    private int stored;
    public void Set(int value) { stored = value; }
    public int Read() { return stored; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter first = new Counter();
        Counter second = new Counter();
        first.Set(199);
        Check(first.Read() == 199, "first-instance-has-value");
        Check(second.Read() == 0, "second-instance-not-written");
        second.Set(211);
        Check(first.Read() == 199 && second.Read() == 211, "instance-writes-independent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
