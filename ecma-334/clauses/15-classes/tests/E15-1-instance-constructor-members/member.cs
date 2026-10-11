/*
Rules: E15-1-instance-constructor-members
Authority: ECMA-334 7th ed 15.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: stored = value;
Into: stored = 0;
*/
using System;
class Meter
{
    public int stored;
    public Meter(int value) { stored = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Meter(37).stored == 37, "class-instance-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
