/*
Rules: E12-5-1-class-hides-interface-members
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : Base, IProbe
Into: where T : IProbe
*/
using System;
interface IProbe { int Value { get; } }
class Base { public int Value { get { return 17; } } }
class Derived : Base, IProbe { int IProbe.Value { get { return 31; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read<T>(T receiver) where T : Base, IProbe { return receiver.Value; }
    static void Main()
    {
        Check(Read<Derived>(new Derived()) == 17, "class-property-hides-interface-property");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
