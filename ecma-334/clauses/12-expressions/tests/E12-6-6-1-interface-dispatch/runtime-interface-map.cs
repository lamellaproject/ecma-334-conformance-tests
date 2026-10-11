/*
Rules: E12-6-6-1-interface-dispatch; E12-6-6-1-instance-virtuality; E12-6-6-1-object-invoke
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: IWorker receiver = actual;
Into: IWorker receiver = new Root();
*/
using System;
interface IWorker { int Pick(); }
class Root : IWorker
{
    public object seen;
    int IWorker.Pick() { seen = this; return 3; }
}
class Leaf : Root, IWorker
{
    int IWorker.Pick() { seen = this; return 8; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf actual = new Leaf();
        IWorker receiver = actual;
        int result = receiver.Pick();
        Check(result == 8, "interface-map-uses-runtime-reimplementation");
        Check(actual.seen == actual, "interface-implementation-this-is-runtime-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
