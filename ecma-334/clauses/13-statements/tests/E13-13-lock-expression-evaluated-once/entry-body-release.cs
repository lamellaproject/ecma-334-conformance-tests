/*
Rules: E13-13-lock-expression-evaluated-once; E13-13-form-lock; E13-13-lock-monitor-entry; E13-13-lock-body-execution; E13-13-lock-monitor-release
Authority: ECMA-334 7th ed 13.13
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: lock (Evaluate())
Into: if (Evaluate() != null)
*/
using System;
using System.Threading;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static object gate = new object(), other = new object();
    static int evaluated;
    static object Evaluate() { evaluated++; return evaluated == 1 ? gate : other; }
    static void Main()
    {
        bool bodyHeld = false;
        lock (Evaluate()) { bodyHeld = Monitor.IsEntered(gate); }
        Check(evaluated == 1, "lock-expression-evaluated-once");
        Check(bodyHeld, "monitor-enter-before-body");
        Check(!Monitor.IsEntered(gate) && !Monitor.IsEntered(other), "monitor-exit-after-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
