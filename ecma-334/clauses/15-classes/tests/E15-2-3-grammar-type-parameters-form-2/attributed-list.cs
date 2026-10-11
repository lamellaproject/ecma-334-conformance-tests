/*
Rules: E15-2-3-grammar-type-parameters-form-2
Authority: ECMA-334 7th ed 15.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Packet<T, [Stamp] U>
Into: class Packet<T [Stamp] U>
*/
using System;
class StampAttribute : Attribute { }
class Packet<T, [Stamp] U> { public T First; public U Second; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet<int, object> packet = new Packet<int, object>();
        object token = new object();
        packet.First = 179;
        packet.Second = token;
        Check(packet.First == 179, "first-parameter-in-list");
        Check(packet.Second == token, "attributed-following-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
