/*
Rules: E15-3-8-nongeneric-static-storage; E15-3-8-static-modifier-classifies; E15-3-8-static-or-instance
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: private static int stored;
Into: private int stored;
*/
using System;
class Counter
{
    private static int stored;
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
        first.Set(113);
        Check(second.Read() == 113, "first-instance-write-shared");
        second.Set(127);
        Check(first.Read() == 127 && second.Read() == 127, "second-instance-write-shared");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
