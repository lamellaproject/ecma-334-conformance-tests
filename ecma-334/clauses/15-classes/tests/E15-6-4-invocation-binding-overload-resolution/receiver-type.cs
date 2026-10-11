/*
Rules: E15-6-4-invocation-binding-overload-resolution
Authority: ECMA-334 7th ed 15.6.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: view.Read(3)
Into: ((Branch)view).Read(3)
*/
using System;
class Root { public virtual int Read(long value) { return 17; } }
class Branch : Root
{
    public override int Read(long value) { return 23; }
    public int Read(int value) { return 29; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Branch branch = new Branch();
        Root view = branch;
        Check(view.Read(3) == 23, "base-type-binds-long-method-then-dispatches-override");
        Check(branch.Read(3) == 29, "derived-type-includes-better-int-overload");
        Check(branch.Read(3L) == 23, "long-argument-binds-virtual-overload");
        Check(new Root().Read(3) == 17, "base-instance-uses-same-bound-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
