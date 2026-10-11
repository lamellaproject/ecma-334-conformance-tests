/*
Rules: E18-6-5-shared-implementation
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int Next() { return ++calls; }
Into: public int Next() { return calls; }
*/
using System;
interface IFirst { int Next(); }
interface ISecond { int Next(); }
class Counter : IFirst, ISecond
{
    int calls;
    public int Next() { return ++calls; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter counter = new Counter();
        IFirst first = counter;
        ISecond second = counter;
        Check(first.Next() == 1, "first-interface-shared-member");
        Check(second.Next() == 2, "second-interface-shared-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
