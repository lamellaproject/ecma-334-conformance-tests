/*
Rules: E8-1-value-copy-independence; E8-1-value-variable-storage; E8-1-type-form-value; E8-3-1-value-assignment-copy; E8-3-4-struct-value-type; E8-3-1-value-form-nonnullable; E8-3-1-nonnullable-form-struct; E8-3-1-struct-form-name
Authority: ECMA-334 7th ed 8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: struct Packet
Into: class Packet
*/
using System;
struct Packet { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet first = new Packet(); first.Value = 14;
        Packet second = first;
        second.Value = 29;
        Check(first.Value == 14 && second.Value == 29, "independent-data-copies");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
