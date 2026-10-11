/*
Rules: E12-10-5-delegate-predefined; E12-10-5-delegate-null-left; E12-10-5-delegate-null-right; E12-10-5-delegate-new-instance; E12-10-5-delegate-list-order
Authority: ECMA-334 7th ed 12.10.5
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: left + right
Into: right + left
*/
using System;
delegate void D();
class Program
{
    static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void A() { trace += "A"; }
    static void B() { trace += "B"; }
    static void Main()
    {
        D left = A, right = B, none = null;
        Check((object)(none + left) == (object)left, "null-left-identity");
        Check((object)(left + none) == (object)left, "null-right-identity");
        Check(none + none == null, "both-null");
        D result = left + right;
        Check((object)result != (object)left && (object)result != (object)right, "new-instance");
        result(); Check(trace == "AB", "left-before-right");
        trace = ""; left(); Check(trace == "A", "left-input-unchanged");
        trace = ""; right(); Check(trace == "B", "right-input-unchanged");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
