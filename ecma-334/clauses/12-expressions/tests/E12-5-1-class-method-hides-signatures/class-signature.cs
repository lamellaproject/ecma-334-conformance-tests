/*
Rules: E12-5-1-class-method-hides-signatures
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : Base, IProbe
Into: where T : IProbe
*/
using System;
interface IProbe { int Pick(int value); }
class Base { public int Pick(int value) { return value + 10; } }
class Derived : Base, IProbe { int IProbe.Pick(int value) { return value + 20; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Invoke<T>(T receiver) where T : Base, IProbe { return receiver.Pick(7); }
    static void Main()
    {
        Check(Invoke<Derived>(new Derived()) == 17, "class-method-hides-interface-same-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
