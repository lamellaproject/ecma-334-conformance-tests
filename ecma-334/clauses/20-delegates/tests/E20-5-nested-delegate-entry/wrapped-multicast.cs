/*
Rules: E20-5-nested-delegate-entry; E20-5-delegate-target
Authority: ECMA-334 7th ed 20.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Notice wrapper = new Notice(source);
Into: Notice wrapper = source;
*/
using System;
delegate void Notice();
class Program
{
    static int checks, failures;
    static string trace = "";
    static void A() { trace += "A"; }
    static void B() { trace += "B"; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Notice source = (Notice)A + B;
        Notice wrapper = new Notice(source);
        Check(source.GetInvocationList().Length == 2, "source-multicast-entry-count");
        Check(wrapper.GetInvocationList().Length == 1, "wrapper-has-one-delegate-entry");
        Check(wrapper.Target == (object)source, "wrapper-target-is-source-delegate");
        wrapper();
        Check(trace == "AB", "wrapper-invokes-source-list-in-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
