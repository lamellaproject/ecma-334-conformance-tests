/*
Rules: E12-8-22-alias-target-form; E12-8-22-entity-form; E12-8-22-last-identifier
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: nameof(PortAlias::Slot.Inner<int>)
Into: nameof(PortAlias::Slot)
*/
using System;
using PortAlias = Ports;
namespace Ports
{
    class Slot { public class Inner<T> { public class Leaf<U> { } } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(nameof(PortAlias::Slot.Inner<int>) == "Inner", "alias-target-final-generic-identifier");
        Check(nameof(global::Ports.Slot.Inner<int>.Leaf<byte>) == "Leaf", "multiple-dotted-type-arguments");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
