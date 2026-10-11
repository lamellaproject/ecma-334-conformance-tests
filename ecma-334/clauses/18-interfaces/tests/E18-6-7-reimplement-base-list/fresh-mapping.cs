/*
Rules: E18-6-7-reimplement-base-list; E18-6-7-mapping-rules
Authority: ECMA-334 7th ed 18.6.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Branch : Root, IRead
Into: class Branch : Root
*/
using System;
interface IRead { int Read(); }
class Root : IRead { int IRead.Read() { return 431; } }
class Branch : Root, IRead { public int Read() { return 433; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(((IRead)new Root()).Read() == 431, "original-explicit-mapping");
        Check(((IRead)new Branch()).Read() == 433, "fresh-map-selects-derived-public-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
