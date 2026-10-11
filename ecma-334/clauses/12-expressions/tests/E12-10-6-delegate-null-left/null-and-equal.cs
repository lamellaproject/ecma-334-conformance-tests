/*
Rules: E12-10-6-delegate-null-left; E12-10-6-delegate-predefined; E12-10-6-delegate-null-right; E12-10-6-delegate-equal-lists; E12-10-6-delegate-nonnull-lists
Authority: ECMA-334 7th ed 12.10.6
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: none - left
Into: left - none
*/
using System;
delegate void D();
class Program
{
    static int calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void A() { calls++; }
    static void Main()
    {
        D left = A, equal = new D(A), none = null;
        Check(none - left == null, "null-left");
        Check(none - none == null, "both-null");
        Check((object)(left - none) == (object)left, "null-right-identity");
        Check(left - equal == null, "equal-lists-become-null");
        left(); equal(); Check(calls == 2, "nonnull-operands-have-invocations");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
