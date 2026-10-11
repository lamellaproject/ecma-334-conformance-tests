/*
Rules: E7-10-critical-thread-creation; E7-10-side-effect-nonvolatile-write
Authority: ECMA-334 7th ed 7.10
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: payload = 181;
Into: payload = 0;
*/
using System;
using System.Threading;
class Program
{
    static int checks, failures, payload, observed;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Read() { observed = payload; }
    static void Main()
    {
        payload = 181;
        Thread child = new Thread(Read); child.Start(); child.Join();
        Check(observed == 181, "new-thread-observes-effects-before-creation-and-start");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
