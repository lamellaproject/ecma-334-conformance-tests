/*
Rules: E13-6-4-null-invocation-parse-priority; E13-6-4-form-function-null-invocation
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: receiver?.Touch();
Into: receiver.Touch();
*/
using System;
class Program
{
    static int checks, failures, touches;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Receiver { public void Touch() { touches++; } }
    static void Main()
    {
        Receiver receiver = null;
        void Maybe() => receiver?.Touch();
        bool completed = true;
        try { Maybe(); } catch (Exception) { completed = false; }
        Check(completed && touches == 0, "null-invocation-is-void-body");
        receiver = new Receiver();
        Maybe();
        Check(touches == 1, "nonnull-invocation-executes");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
