/*
Rules: E16-1-value-type; E16-1-direct-data; E16-4-2-independent-values; E16-4-2-independent-value-updates; E16-4-4-assignment-copy
Authority: ECMA-334 7th ed 16.1
Version: 7.3
Expected: run
Stdout: OK 2
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
        Packet second = first; second.Value = 29;
        Check(first.Value == 14, "source-copy");
        Check(second.Value == 29, "destination-copy");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
