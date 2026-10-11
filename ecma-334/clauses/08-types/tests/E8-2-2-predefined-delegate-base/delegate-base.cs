/*
Rules: E8-2-2-predefined-delegate-base
Authority: ECMA-334 7th ed 8.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Delegate view = action;
Into: Delegate view = null;
*/
using System;
delegate void Callback();
class Signals { public static void Signal() { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Callback action = Signals.Signal;
        Delegate view = action;
        Check(view == action, "predefined-delegate-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
