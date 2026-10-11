/*
Rules: E12-5-2-delegate-bases
Authority: ECMA-334 7th ed 12.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Action action = Handler;
Into: Action action = Handler; action += Handler;
*/
using System;
class Program
{
    static int checks, failures;
    static void Handler() { }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Action action = Handler; Delegate function = action; object boxed = function;
        Check(action.GetInvocationList().Length == 1, "delegate-base-invocation-list");
        Check(action.Equals(boxed), "delegate-object-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
