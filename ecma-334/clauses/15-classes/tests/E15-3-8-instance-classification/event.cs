/*
Rules: E15-3-8-instance-classification; E15-3-8-separate-instance-storage
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: private Signal listener;
Into: private static Signal listener;
*/
using System;
class Packet
{
    public delegate void Signal();
    private Signal listener;
    public event Signal Changed { add { listener += value; } remove { listener -= value; } }
    public void Fire() { if (listener != null) listener(); }
}
class Program
{
    static int checks, failures, firstCalls, secondCalls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void OnFirst() { firstCalls++; }
    static void OnSecond() { secondCalls++; }
    static void Main()
    {
        Packet first = new Packet();
        Packet second = new Packet();
        first.Changed += OnFirst;
        second.Changed += OnSecond;
        first.Fire();
        Check(firstCalls == 1 && secondCalls == 0, "first-event-uses-first-instance");
        second.Fire();
        Check(firstCalls == 1 && secondCalls == 1, "second-event-uses-second-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
