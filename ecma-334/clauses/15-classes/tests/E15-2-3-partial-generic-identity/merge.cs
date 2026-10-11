/*
Rules: E15-2-3-partial-generic-identity
Authority: ECMA-334 7th ed 15.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: partial class Packet<T> { public T Value; }
Into: class Packet<T> { public T Value; }
*/
using System;
partial class Packet<T> { public T Value; }
partial class Packet<T> { public T Read() { return Value; } }
partial class Packet<T, U> { public int Read() { return 191; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet<int> packet = new Packet<int>();
        packet.Value = 181;
        Check(packet.Read() == 181, "same-name-and-arity-merge");
        Check(new Packet<int, object>().Read() == 191, "different-arity-is-distinct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
