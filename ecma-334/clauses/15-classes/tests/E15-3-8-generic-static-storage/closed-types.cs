/*
Rules: E15-3-8-generic-static-storage
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: private static int stored;
Into: private int stored;
*/
using System;
class Slot<T>
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
        Slot<int> first = new Slot<int>();
        Slot<int> second = new Slot<int>();
        Slot<string> other = new Slot<string>();
        first.Set(131);
        Check(second.Read() == 131, "same-closed-type-shares-storage");
        Check(other.Read() == 0, "different-closed-type-starts-separate");
        other.Set(137);
        Check(first.Read() == 131 && second.Read() == 131 && other.Read() == 137, "closed-type-writes-independent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
