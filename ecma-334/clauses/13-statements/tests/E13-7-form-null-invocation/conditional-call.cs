/*
Rules: E13-7-form-null-invocation
Authority: ECMA-334 7th ed 13.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: absent?.Touch();
Into: new Receiver()?.Touch();
*/
using System;
class Receiver { public int Touch() { Program.calls++; return 19; } }
class Program
{
    public static int calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver absent = null;
        absent?.Touch();
        Check(calls == 0, "null-receiver-skips-call");
        Receiver present = new Receiver();
        present?.Touch();
        Check(calls == 1, "present-receiver-calls-and-discards-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
