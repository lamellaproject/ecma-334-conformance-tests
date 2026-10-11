/*
Rules: E16-4-10-explicit-constructor-trigger
Authority: ECMA-334 7th ed 16.4.10
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: static Entry()
Into: static void Initialize()
*/
using System;
class Trace { public static int Order; }
struct Entry
{
    public int Value;
    static Entry() { Trace.Order = Trace.Order * 10 + 1; }
    public Entry(int value) { Trace.Order = Trace.Order * 10 + 2; Value = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry empty = new Entry();
        Check(empty.Value == 0 && Trace.Order == 0, "default-not-a-trigger");
        Entry first = new Entry(107);
        Check(first.Value == 107, "instance-constructor-value");
        Check(Trace.Order == 12, "static-before-instance");
        Entry second = new Entry(23);
        Check(second.Value == 23 && Trace.Order == 122, "static-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
