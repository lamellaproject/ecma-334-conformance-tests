/*
Rules: E8-2-8-delegate-method-sequence; E8-2-8-delegate-instance-receiver
Authority: ECMA-334 7th ed 8.2.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Callback pair = left.Touch;
Into: Callback pair = right.Touch;
*/
using System;
delegate void Callback();
class Receiver { public int Count; public void Touch() { Count++; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver left = new Receiver(); Receiver right = new Receiver();
        Callback pair = left.Touch; pair += right.Touch;
        pair();
        Check(left.Count == 1 && right.Count == 1, "delegate-methods-and-receivers");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
