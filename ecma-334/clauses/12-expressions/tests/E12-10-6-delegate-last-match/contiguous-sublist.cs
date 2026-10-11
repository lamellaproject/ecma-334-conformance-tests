/*
Rules: E12-10-6-delegate-last-match; E12-10-6-delegate-remove-sublist; E12-10-6-delegate-sublist-equality; E12-10-6-delegate-no-match; E12-10-6-delegate-inputs-unchanged
Authority: ECMA-334 7th ed 12.10.6
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: left - right
Into: left
*/
using System;
delegate void D();
class Receiver { public void B() { Program.Trace += "B"; } }
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void A() { Trace += "A"; }
    static void C() { Trace += "C"; }
    static void Main()
    {
        Receiver receiver = new Receiver(); D a = A, b = receiver.B, c = C;
        D left = a + b + c + a + b;
        // New but equal entries prove sublist matching uses delegate equality, rather than instance identity.
        D right = new D(A) + new D(receiver.B); D result = left - right;
        result(); Check(Trace == "ABC", "remove-last-contiguous-match");
        Trace = ""; left(); Check(Trace == "ABCAB", "left-input-unchanged");
        Trace = ""; right(); Check(Trace == "AB", "right-input-unchanged");
        D noncontiguous = a + c;
        Check((object)(left - noncontiguous) == (object)left, "noncontiguous-is-not-sublist");
        D otherTarget = new Receiver().B;
        Check((object)(left - otherTarget) == (object)left, "target-identity-part-of-entry-equality");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
