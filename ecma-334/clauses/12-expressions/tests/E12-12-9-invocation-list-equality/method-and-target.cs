/*
Rules: E12-12-9-invocation-list-equality; E12-12-9-predefined-equality; E12-12-9-predefined-inequality; E12-12-9-null-comparison; E12-12-9-different-runtime-types; E12-12-9-static-entry-equality; E12-12-9-instance-entry-equality
Authority: ECMA-334 7th ed 12.12.9
Version: 7.3
Expected: run
Stdout: OK 9
Mutate: left == equal
Into: left != equal
*/
using System;
delegate void D();
delegate void Other();
class Receiver { public void Touch() { } public void Different() { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void A() { }
    static void B() { }
    static void Main()
    {
        D a = new D(A), sameA = new D(A), b = new D(B), none = null;
        Check(a == sameA && !(a != sameA), "same-static-method"); Check(a != b, "different-static-method");
        Check(none == null && a != none && none != a, "null-operands");
        Delegate x = a, y = new Other(A); Check(x != y && !(x == y), "different-runtime-delegate-type");
        Receiver receiver = new Receiver(); D instance = receiver.Touch, equalInstance = new D(receiver.Touch);
        Check(instance == equalInstance, "same-instance-method-and-target");
        Check(instance != new D(new Receiver().Touch) && instance != new D(receiver.Different), "different-target-or-method");
        D left = a + instance + b, equal = sameA + equalInstance + new D(B);
        Check(left == equal && !(left != equal), "equal-lists-in-order");
        Check(left != a + b + instance, "list-order-matters"); Check(left != a + instance, "list-length-matters");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
