/*
Rules: E15-3-8-instance-this-receiver; E15-3-8-instance-classification
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return this;
Into: return new Packet();
*/
using System;
class Packet { public Packet this[int index] { get { return this; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet first = new Packet();
        Packet second = new Packet();
        Check(first[0] == first, "indexer-this-is-first-receiver");
        Check(second[1] == second, "indexer-this-is-second-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
