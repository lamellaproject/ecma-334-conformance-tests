/*
Rules: E20-5-concatenate-lists; E20-5-combination-creation; E20-5-operator-add; E20-5-immutable-invocation-list
Authority: ECMA-334 7th ed 20.5
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: Notice joined = left + a;
Into: Notice joined = a + left;
*/
using System;
delegate void Notice();
class Program
{
    static int checks, failures;
    static string trace;
    static void A() { trace += "A"; }
    static void B() { trace += "B"; }
    static string Call(Notice notice) { trace = ""; notice(); return trace; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Notice a = A, b = B;
        Notice left = a + b;
        Notice saved = left;
        Notice joined = left + a;
        Check(Call(joined) == "ABA", "left-list-before-right-list");
        Check(Call(left) == "AB" && Call(saved) == "AB", "existing-combination-unchanged");
        Check(Call(a) == "A" && Call(b) == "B", "operand-invocation-lists-unchanged");
        Check(a + null == a, "null-right-combination");
        Check(null + b == b, "null-left-combination");
        Notice none = null;
        Check(none + none == null, "both-null-combination");
        Check(joined.GetInvocationList().Length == 3, "concatenated-entry-count");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
