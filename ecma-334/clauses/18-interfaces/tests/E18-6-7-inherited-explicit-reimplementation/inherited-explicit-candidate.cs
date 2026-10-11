/*
Rules: E18-6-7-inherited-explicit-reimplementation
Authority: ECMA-334 7th ed 18.6.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int IRead.Read() { return 449; }
Into: int IRead.Read() { return Read(); }
*/
using System;
interface IRead { int Read(); }
class Root : IRead
{
    int IRead.Read() { return 449; }
    public int Read() { return 457; }
}
class Branch : Root, IRead { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(((IRead)new Branch()).Read() == 449, "inherited-explicit-before-inherited-public");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
