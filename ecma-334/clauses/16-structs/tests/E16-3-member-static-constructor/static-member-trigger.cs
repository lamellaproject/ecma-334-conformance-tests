/*
Rules: E16-3-member-static-constructor; E16-4-10-first-trigger; E16-4-10-static-reference-trigger
Authority: ECMA-334 7th ed 16.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: static Entry()
Into: static void Initialize()
*/
using System;
class Trace { public static int Calls; }
struct Entry
{
    public static int Value;
    static Entry() { Trace.Calls++; Value = 103; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Trace.Calls == 0, "before-trigger");
        int first = Entry.Value;
        Check(first == 103, "static-initialized-value");
        Check(Trace.Calls == 1, "first-reference-trigger");
        int second = Entry.Value;
        Check(second == 103 && Trace.Calls == 1, "no-second-initialization");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
