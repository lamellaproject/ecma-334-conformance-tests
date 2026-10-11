/*
Rules: E7-3-class-event-declaration; E7-4-5-class-event-declaration; E7-4-1-member-inheritance; E7-4-5-class-members
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public event Action Signal;
Into: public event int Signal;
*/
using System;
class Holder
{
    public event Action Signal;
    public void Raise() { Signal(); }
}
class Derived : Holder { }
class Program
{
    static int calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Mark() { calls++; }
    static void Main()
    {
        var item = new Derived();
        item.Signal += Mark;
        item.Raise();
        Check(calls == 1, "class-event-declared-and-raised");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
