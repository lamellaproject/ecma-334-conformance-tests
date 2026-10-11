/*
Rules: E12-6-6-1-virtual-dispatch; E12-6-6-1-instance-virtuality; E12-6-6-1-object-invoke
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Root receiver = actual;
Into: Root receiver = new Root();
*/
using System;
class Root
{
    public object seen;
    public virtual int Pick() { seen = this; return 3; }
}
class Middle : Root { public override int Pick() { seen = this; return 5; } }
class Leaf : Middle { public override int Pick() { seen = this; return 8; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf actual = new Leaf();
        Root receiver = actual;
        int result = receiver.Pick();
        Check(result == 8, "virtual-call-uses-most-derived-override");
        Check(actual.seen == actual, "virtual-implementation-this-is-runtime-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
