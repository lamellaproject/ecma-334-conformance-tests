/*
Rules: E12-6-6-1-nonvirtual-dispatch; E12-6-6-1-instance-virtuality; E12-6-6-1-object-invoke
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: receiver.Pick()
Into: actual.Pick()
*/
using System;
class Root
{
    public object seen;
    public int Pick() { seen = this; return 3; }
}
class Leaf : Root { public new int Pick() { seen = this; return 8; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf actual = new Leaf();
        Root receiver = actual;
        int result = receiver.Pick();
        Check(result == 3, "nonvirtual-call-invokes-bound-member");
        Check(actual.seen == actual, "nonvirtual-member-this-is-runtime-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
