/*
Rules: E15-12-static-constructor-trigger-instance
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static Gauge()
Into: private Gauge()
*/
using System;
class Gauge { public int Snapshot; static Gauge() { Program.Calls++; } public Gauge(int n) { Snapshot = Program.Calls; } }
class Program
{
    static int checks, failures;
    public static int Calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Calls == 0, "instance-trigger-not-earlier");
        Gauge item = new Gauge(13);
        Check(item.Snapshot == 1 && Calls == 1, "first-instance-triggers-before-instance-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
