/*
Rules: E12-5-1-exclude-overrides; E12-5-1-ordinary-members
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: receiver.Pick(5L)
Into: receiver.Pick(5)
*/
using System;
class Base
{
    public virtual int Pick(int value) { return 11; }
    public int Pick(long value) { return 17; }
}
class Derived : Base { public override int Pick(int value) { return 23; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived(); int result = receiver.Pick(5L);
        Check(result == 17, "override-does-not-remove-inherited-overload");
        Check(receiver.Pick(3) == 23, "base-selected-virtual-dispatch");
        Check(receiver.Equals(receiver), "object-member-included");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
