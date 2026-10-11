/*
Rules: E20-5-equality
Authority: ECMA-334 7th ed 20.5
Version: 7.3
Expected: run
Stdout: OK 9
Mutate: Notice same = first.Touch;
Into: Notice same = second.Touch;
*/
using System;
delegate void Notice();
delegate void OtherNotice();
class Counter { public void Touch() { } public void Other() { } }
class Program
{
    static int checks, failures;
    static void A() { }
    static void B() { }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter first = new Counter(), second = new Counter();
        Notice one = first.Touch;
        Notice same = first.Touch;
        Notice otherTarget = second.Touch, otherMethod = first.Other;
        Notice a = A, sameA = A, b = B, none = null;
        OtherNotice otherType = A;
        Check(one == same && !(one != same), "same-instance-and-method");
        Check(one != otherTarget, "different-target-instance");
        Check(one != otherMethod, "different-instance-method");
        Check(a == sameA, "same-static-method");
        Check(a != b, "different-static-method");
        Check((a + b) == (sameA + b), "equal-corresponding-list-entries");
        Check((a + b) != (b + a) && (a + b) != a, "list-order-and-length");
        Check(none == null && one != none, "delegate-null-equality");
        Check((Delegate)a != (Delegate)otherType, "different-runtime-delegate-types");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
