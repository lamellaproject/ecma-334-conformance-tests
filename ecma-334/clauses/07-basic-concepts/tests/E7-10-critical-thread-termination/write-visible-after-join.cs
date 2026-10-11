/*
Rules: E7-10-critical-thread-termination; E7-10-side-effect-nonvolatile-write
Authority: ECMA-334 7th ed 7.10
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: payload = 191;
Into: payload = 0;
*/
using System;
using System.Threading;
class Program
{
    static int checks, failures, payload;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Write() { payload = 191; }
    static void Main()
    {
        Thread child = new Thread(Write); child.Start(); child.Join();
        Check(payload == 191, "terminated-thread-effects-visible-after-join");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
