/*
Rules: E12-8-16-6-value-copy-source; E12-8-16-6-value-result; E12-8-16-6-value-evaluate; E12-8-16-6-value-allocation; E12-8-16-6-value-invocation-list; E12-8-16-6-invocation-list-fixed
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: Callback copy = new Callback(Read(combined));
Into: Callback copy = Read(combined);
*/
using System;
delegate void Callback();
class Program
{
    static string trace = "";
    static int reads;
    static void First() { trace += "A"; }
    static void Second() { trace += "B"; }
    static void Third() { trace += "C"; }
    static Callback Read(Callback value) { reads++; trace += "R"; return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Callback combined = First;
        combined += Second;
        Callback copy = new Callback(Read(combined));
        Check(reads == 1 && trace == "R", "source-evaluated-once-before-copy-invocation");
        Check(!object.ReferenceEquals(copy, combined), "copy-is-new-delegate-instance");
        bool listSizes = combined.GetInvocationList().Length == 2 && copy.GetInvocationList().Length == 1;
        Check(listSizes, "copy-wraps-source-in-one-entry");
        combined = Third;
        copy();
        Check(trace == "RAB", "copy-invokes-original-multicast-source");
        combined();
        Check(trace == "RABC" && reads == 1, "copy-list-fixed-after-source-reassignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
