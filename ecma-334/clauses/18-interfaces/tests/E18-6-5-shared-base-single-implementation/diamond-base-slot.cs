/*
Rules: E18-6-5-shared-base-single-implementation
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int IRoot.Next() { return ++calls; }
Into: int IRoot.Next() { return 1; }
*/
using System;
interface IRoot { int Next(); }
interface ILeft : IRoot { }
interface IRight : IRoot { }
class Counter : ILeft, IRight
{
    int calls;
    int IRoot.Next() { return ++calls; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter counter = new Counter();
        ILeft left = counter;
        IRight right = counter;
        Check(left.Next() == 1, "root-member-through-left");
        Check(right.Next() == 2, "same-root-member-through-right");
        Check(((IRoot)counter).Next() == 3, "single-root-implementation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
