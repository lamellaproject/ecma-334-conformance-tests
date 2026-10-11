/*
Rules: E8-2-4-dynamic-invalid-operation-compiles; E8-2-4-dynamic-runtime-resolution-failure
Authority: ECMA-334 7th ed 8.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: receiver.Missing()
Into: receiver.Known()
*/
using System;
public class Receiver { public int Known() { return 8; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic receiver = new Receiver(); bool caught = false;
        try { int ignored = receiver.Missing(); }
        catch (Exception) { caught = true; }
        Check(caught, "invalid-operation-fails-at-runtime");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
