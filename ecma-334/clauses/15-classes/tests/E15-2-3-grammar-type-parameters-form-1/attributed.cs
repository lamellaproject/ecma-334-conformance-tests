/*
Rules: E15-2-3-grammar-type-parameters-form-1; E15-2-3-grammar-type-parameter-list
Authority: ECMA-334 7th ed 15.2.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Packet<[Stamp] T>
Into: class Packet<[Stamp]>
*/
using System;
class StampAttribute : Attribute { }
class Packet<[Stamp] T> { public T Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet<int> packet = new Packet<int>();
        packet.Value = 173;
        Check(packet.Value == 173, "attributed-single-type-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
