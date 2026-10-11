/*
Rules: E12-9-6-shared-implementation; E12-9-6-same-update
Authority: ECMA-334 7th ed 12.9.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: ++first
Into: first++
*/
using System;
struct Counter
{
    public int Value;
    public static Counter operator ++(Counter c) { Program.Calls++; c.Value += 5; return c; }
}
class Program
{
    public static int Calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter first = new Counter(); Counter second = new Counter(); first.Value = second.Value = 2;
        Counter before = ++first; Counter after = second++;
        Check(before.Value == 7 && after.Value == 2, "different-result-timing");
        Check(first.Value == 7 && second.Value == 7, "same-stored-update"); Check(Calls == 2, "same-implementation-both-times");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
