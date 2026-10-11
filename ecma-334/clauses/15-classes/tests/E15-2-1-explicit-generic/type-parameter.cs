/*
Rules: E15-2-1-explicit-generic
Authority: ECMA-334 7th ed 15.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Packet<T>
Into: class Packet
*/
using System;
class Packet<T> { public T Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet<int> packet = new Packet<int>();
        packet.Value = 53;
        Check(packet.Value == 53, "generic-class-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
