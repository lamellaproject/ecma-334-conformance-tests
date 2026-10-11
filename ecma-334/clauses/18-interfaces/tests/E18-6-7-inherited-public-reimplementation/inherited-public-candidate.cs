/*
Rules: E18-6-7-inherited-public-reimplementation
Authority: ECMA-334 7th ed 18.6.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public new int Read()
Into: private new int Read()
*/
using System;
interface IRead { int Read(); }
class Root : IRead { public int Read() { return 439; } }
class Middle : Root { public new int Read() { return 443; } }
class Branch : Middle, IRead { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(((IRead)new Branch()).Read() == 443, "inherited-public-member-in-fresh-mapping");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
