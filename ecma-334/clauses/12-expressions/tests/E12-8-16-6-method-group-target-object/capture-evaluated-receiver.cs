/*
Rules: E12-8-16-6-method-group-target-object; E12-8-16-6-method-group-target; E12-8-16-6-method-group-binding; E12-8-16-6-method-group-evaluation; E12-8-16-6-syntax; E12-8-16-6-delegate-instance; E12-8-16-6-static-binding; E12-8-16-1-delegate-form
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new Callback(Read().Work)
Into: new Callback(other.Work)
*/
using System;
delegate void Callback();
class Receiver
{
    public int Calls;
    public void Work() { Calls++; }
}
class Program
{
    static Receiver current;
    static int reads;
    static Receiver Read() { reads++; return current; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver first = new Receiver(), other = new Receiver();
        current = first;
        Callback callback = new Callback(Read().Work);
        Check(reads == 1 && first.Calls == 0 && other.Calls == 0, "receiver-evaluated-without-method-call");
        current = other;
        callback();
        Check(first.Calls == 1 && other.Calls == 0, "delegate-keeps-original-receiver");
        Check(reads == 1, "receiver-not-reevaluated-on-invocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
