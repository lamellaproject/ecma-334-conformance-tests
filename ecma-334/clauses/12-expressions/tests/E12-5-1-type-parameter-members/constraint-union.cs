/*
Rules: E12-5-1-type-parameter-members; E12-5-1-interface-hiding-context
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: where T : Base, IProbe
Into: where T : Base
*/
using System;
interface IProbe { int Read(string text); }
class Base { public int Read(int value) { return value + 10; } }
class Derived : Base, IProbe { public int Read(string text) { return 31; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Invoke<T>(T receiver) where T : Base, IProbe
    {
        Check(receiver.Read(7) == 17, "primary-constraint-members");
        Check(receiver.Read("teal") == 31, "secondary-constraint-members");
        Check(receiver.Equals(receiver), "constraint-object-members");
    }
    static void Main()
    {
        Invoke<Derived>(new Derived());
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
