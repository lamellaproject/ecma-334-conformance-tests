/*
Rules: E6-4-4-grammar-keyword-35
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: interface ICounter
Into: class ICounter
*/
using System;
interface ICounter { int Read(); }
class Counter : ICounter { public int Read() { return 61; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ICounter item = new Counter();
        Check(item.Read() == 61, "interface-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
