/*
Rules: E8-1-reference-aliasing; E8-1-reference-variable-storage; E8-1-type-form-reference; E8-2-1-reference-value-instance; E8-2-1-reference-form-class; E8-2-1-class-form-name; E8-3-1-reference-assignment-copy
Authority: ECMA-334 7th ed 8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Packet
Into: struct Packet
*/
using System;
class Packet { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet first = new Packet(); first.Value = 14;
        Packet second = first;
        second.Value = 29;
        Check(first.Value == 29, "shared-object-data");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
