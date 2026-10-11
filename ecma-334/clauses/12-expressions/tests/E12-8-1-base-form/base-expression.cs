/*
Rules: E12-8-1-base-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return base.Pick();
Into: return Pick();
*/
using System;
class Root { public virtual int Pick() { return 3; } }
class Leaf : Root
{
    public override int Pick() { return 8; }
    public int Parent() { return base.Pick(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = new Leaf().Parent();
        Check(result == 3, "base-access-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
