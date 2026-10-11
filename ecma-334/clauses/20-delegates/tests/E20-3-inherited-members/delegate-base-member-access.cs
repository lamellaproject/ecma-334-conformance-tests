/*
Rules: E20-3-inherited-members; E20-3-class-operations; E20-3-delegate-member-access; E20-2-system-delegate-class
Authority: ECMA-334 7th ed 20.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Notice notice = first.Touch;
Into: Notice notice = second.Touch;
*/
using System;
delegate void Notice();
class Counter { public int Calls; public void Touch() { Calls++; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter first = new Counter(), second = new Counter();
        Notice notice = first.Touch;
        Delegate baseValue = notice;
        object alias = notice;
        Notice recovered = alias as Notice;
        Check(notice.Target == first && baseValue.Target == first, "inherited-target-member");
        Check(notice.GetInvocationList().Length == 1, "inherited-invocation-list-member");
        Check((object)recovered == (object)notice && alias is Delegate, "class-cast-and-type-test");
        recovered();
        Check(first.Calls == 1 && second.Calls == 0, "ordinary-reference-operations-retain-target");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
