/*
Rules: E8-2-1-nonarray-form-class; E8-2-1-nonarray-form-interface; E8-2-1-nonarray-form-delegate
Authority: ECMA-334 7th ed 8.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Receiver[] receivers = new Receiver[2];
Into: Receiver[] receivers = new Receiver[3];
*/
using System;
class Receiver { }
interface ITag { }
delegate void Callback();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver[] receivers = new Receiver[2]; ITag[] interfaces = new ITag[2]; Callback[] callbacks = new Callback[2];
        Check(receivers.Length == 2 && interfaces[0] == null && callbacks[1] == null, "reference-array-elements");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
