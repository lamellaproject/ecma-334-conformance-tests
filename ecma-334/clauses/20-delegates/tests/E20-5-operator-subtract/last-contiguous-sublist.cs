/*
Rules: E20-5-operator-subtract; E20-5-removal-creation; E20-5-immutable-invocation-list
Authority: ECMA-334 7th ed 20.5
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: Notice removed = whole - part;
Into: Notice removed = whole - c;
*/
using System;
delegate void Notice();
class Program
{
    static int checks, failures;
    static string trace;
    static void A() { trace += "A"; }
    static void B() { trace += "B"; }
    static void C() { trace += "C"; }
    static string Call(Notice notice) { trace = ""; notice(); return trace; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Notice a = A, b = B, c = C;
        Notice part = a + b;
        Notice whole = part + c + part;
        Notice alias = whole;
        Notice removed = whole - part;
        Check(Call(removed) == "ABC", "last-matching-contiguous-sublist-removed");
        Check(Call(whole) == "ABCAB" && Call(alias) == "ABCAB", "removal-does-not-change-source");
        Check(Call(part) == "AB", "removal-does-not-change-subtrahend");
        Check((object)(a - b) == (object)a, "absent-sublist-preserves-left");
        Check((object)(whole - null) == (object)whole, "null-right-removal");
        Check(null - part == null, "null-left-removal");
        Check(whole - whole == null, "equal-lists-remove-to-null");
        Check(Call((a + b + a) - a) == "AB", "last-matching-single-entry-removed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
