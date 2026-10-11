/*
Rules: E15-2-4-3-constructed-interface-substitution; E15-2-4-3-constructed-interface; E15-2-4-3-interface-in-scope-parameters
Authority: ECMA-334 7th ed 15.2.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Packet<T> : IView<T>
Into: class Packet<T>
*/
using System;
interface IView<T> { T Read(); }
class Packet<T> : IView<T> { public T Value; public T Read() { return Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet<int> packet = new Packet<int>();
        packet.Value = 241;
        IView<int> view = packet;
        Check(view.Read() == 241, "constructed-interface-substitutes-type-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
