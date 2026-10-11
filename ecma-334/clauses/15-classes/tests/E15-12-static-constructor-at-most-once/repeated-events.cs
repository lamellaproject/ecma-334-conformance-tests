/*
Rules: E15-12-static-constructor-at-most-once
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: static Gauge()
Into: private Gauge()
*/
using System;
class Gauge
{
    public int Snapshot;
    public static int N;
    static Gauge() { N = 13; Program.Calls++; }
    public Gauge(int n) { Snapshot = Program.Calls; Program.InstanceCalls++; }
    public static int Read() { return N; }
}
class Program
{
    static int checks, failures;
    public static int Calls;
    public static int InstanceCalls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge first = new Gauge(3);
        Gauge second = new Gauge(7);
        Check(first.Snapshot == 1 && second.Snapshot == 1, "static-constructor-before-both-instances");
        Check(Gauge.Read() == 13 && Gauge.N == 13 && Calls == 1, "static-constructor-not-repeated-for-member-references");
        Check(InstanceCalls == 2, "both-instance-constructors-executed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
